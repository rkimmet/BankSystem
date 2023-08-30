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
    public class BankSystemTests
    {
        [TestMethod]
        public void getaccount_validid()
        {
            var BankSystem = BankSystm.Instance;
            var account = BankSystem.GetBankAccount("234345487");
            Assert.IsNotNull(account);
            Assert.AreEqual("234345487", account.number);
        }
        [TestMethod]
        public void getaccount_invalidid()
        {
            var BankSystem = BankSystm.Instance;
            var account = BankSystem.GetBankAccount("23434534543487");
            Assert.IsNull(account);
        }
        [TestMethod]
        public void getaccountinquirytest()
        {
            var Bank = new SavingsAccount("Jeff", 600);
            var BankSystem = BankSystm.Instance;
            var transactions = BankSystem.GetAccountInquiry(Bank);
            Assert.AreEqual(1, transactions.Count);

        }
        [TestMethod]
        public void MakeDepositTest()
        {
            var BankSystem = BankSystm.Instance;
            var bank=BankSystem.MakeAccount("west", 500, 2);
            BankSystem.MakeDeposit(bank.number, 700, DateTime.Now, "test");
            var inquiry=BankSystem.GetAccountInquiry(bank);
            Assert.AreEqual(2, inquiry.Count);
        }
        [TestMethod]
        public void MakeWithdrawTest()
        {
            var BankSystem = BankSystm.Instance;
            var bank = BankSystem.MakeAccount("west", 500, 2);
            BankSystem.MakeWithdraw (bank.number, 200, DateTime.Now, "test");
            var inquiry = BankSystem.GetAccountInquiry(bank);
            Assert.AreEqual(2, inquiry.Count);
        }
        [TestMethod]
        public void MakeWithdraw_InvalidAmount()
        {
            var BankSystem = BankSystm.Instance;
            var bank = BankSystem.MakeAccount("west", 500, 2);
            Assert.ThrowsException<ArgumentException>(()=>BankSystem.MakeWithdraw(bank.number,(decimal).001, DateTime.Now, "test"));
        }
    }
}
