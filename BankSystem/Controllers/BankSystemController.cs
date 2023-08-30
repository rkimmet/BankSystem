using BankSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankSystemController : ControllerBase
    {

        IBanksystem database = BankSystm.Instance;

        public BankSystemController(IBanksystem bankSystm)
        {
            database = bankSystm;
        }


        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var bank = database.GetBankAccount(id);

            if (bank == null)
            {
                return NotFound();
            }

            var bankaccount = new Models.BankAccount
            {
                owner = bank.owner,
                balance = bank.balance,
                accounttype = bank.GetType().Name,
                number = bank.number,
            };

            return Ok(bankaccount);
        }

        [HttpGet("{id}/info")]
        public ActionResult<Models.BankAccount> GetInfo(string id)
        {
            var bank = database.GetBankAccount(id);
            var bankAccount = new Models.BankAccount
            {
                owner = bank.owner,
                balance = bank.balance,
                accounttype = bank.GetType().Name,
            };
            return bankAccount;
        }
        [HttpPost]
        public IActionResult Create(Models.BankAccount bank)
        {
            var banks = database.MakeAccount(bank.owner, bank.amount, bank.type);
            return CreatedAtAction(nameof(Get), new { id = banks.number }, banks);
        }



    }

}