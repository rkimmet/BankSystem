using BankSystem;
using BankSystem.Controllers;
using BankSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System.Web.Http.Results;

namespace apitests
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public void GetAccount()
        {
            IBanksystem bankSystem = BankSystm.Instance;
            var controller = new BankSystemController(bankSystem);
            var result = controller.Get("234345487") as OkObjectResult;
            Assert.IsNotNull(result);
            var bankresult = (BankSystem.Models.BankAccount)result.Value;
            Assert.AreEqual("234345487", bankresult.number);
        }

        [TestMethod]
        public void GetAccount_AccountNotFound()
        {
            // Arrange
            IBanksystem bankSystem = BankSystm.Instance;
            var controller = new BankSystemController(bankSystem);

            // Act
            var result = controller.Get("23434548734534");

            // Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.NotFoundResult));
        }


        [TestMethod]
        public void CreateAccount()
        {
            //Arrange
            IBanksystem bankSystem = BankSystm.Instance;
            var controller = new BankSystemController(bankSystem);

            //Act
            var response = controller.Create(new BankSystem.Models.BankAccount { owner = "testowner", amount = (decimal)500, type = 1 });
            var createdResult = response as CreatedAtActionResult;
            var responseValue = (BankSystem.BankAccount)createdResult.Value;
            //Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual(201, createdResult.StatusCode);
            Assert.AreEqual("testowner", responseValue.owner);
        }
        [TestMethod]
        public void MakeWithdraw_validamount()
        {
            var controller = new TransactionsController();
            var response = controller.MakeWithdraw(new TransactionModel { Id = "234345487", amount = 200, Date = DateTime.Now, Note = "testnote" });
            var createdresult = response as Microsoft.AspNetCore.Mvc.OkResult;
            Assert.AreEqual(200, createdresult.StatusCode);

        }
        [TestMethod]
        public void MakeWithdraw_invalidamount()
        {
            var controller = new TransactionsController();
            var response = controller.MakeWithdraw(new TransactionModel { Id = "234345487", amount = (decimal).0041, Date = DateTime.Now, Note = "testnote" });
            var createdresult = response as OkObjectResult;
            Assert.IsInstanceOfType(response, typeof(Microsoft.AspNetCore.Mvc.BadRequestResult));

        }
        [TestMethod]
        public void MakeDeposit_invalidamount()
        {
            var controller = new TransactionsController();
            var response = controller.MakeWithdraw(new TransactionModel { Id = "234345487", amount = (decimal).001, Date = DateTime.Now, Note = "testnote" });
            Assert.IsInstanceOfType(response, typeof(Microsoft.AspNetCore.Mvc.BadRequestResult));

        }
        [TestMethod]
        public void TransactionQuery()
        {
            var controller = new TransactionsController();
            var Bank = new SavingsAccount("Jeff", 500);
            var response = controller.GetAccountInquiry("234345489");
            Assert.IsNotNull(response);
            Assert.AreEqual(Bank.AccountReport().Count, response.Value.Count);

        }

    }
}