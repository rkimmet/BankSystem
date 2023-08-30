using BankSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : Controller
    {

        BankSystm database = BankSystm.Instance;

        [HttpPost("deposit")]
        public IActionResult MakeDeposit(TransactionModel Transact)
        {

            if (Transact.amount < (decimal).01)
            {
                return BadRequest();
            }
            database.MakeDeposit(Transact.Id, Transact.amount, Transact.Date, Transact.Note);
            return Ok();
        }
        [HttpPost("Withdraw")]
        public IActionResult MakeWithdraw(TransactionModel Transact)
        {

            if (Transact.amount < (decimal).01)
            {
                return BadRequest();
            }
            database.MakeWithdraw(Transact.Id, Transact.amount, Transact.Date, Transact.Note);
            return Ok();
        }
        [HttpGet("{id}/transactionlist")]
        public ActionResult<List<TransactionModel>> GetAccountInquiry(string id)
        {
            var bank = database.GetBankAccount(id);
            List<Transaction> transactions = bank.AccountReport();
            List<TransactionModel> responselist = new List<TransactionModel>();
            foreach (Transaction transaction in transactions)
            {
                responselist.Add(ToTransactionModel(transaction));
            }
            return responselist;

        }

        private TransactionModel ToTransactionModel(Transaction transaction)
        {
            return new TransactionModel
            {
                Date = transaction.Date,
                amount = transaction.Amount,
                Note = transaction.info,
            };
        }
    }
}
