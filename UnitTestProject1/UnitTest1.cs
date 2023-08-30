using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankSystem.Controllers;
namespace BankSystem.Tests
{
    [TestClass]
    public class BanksystemControllertest
    {
        [TestMethod]
        public void GetBankAccount_shouldreturnBankinfo()
        {
            var controller = new BankSystemController();
        }

    }
}