using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoqDemo;
using Moq;

namespace ATMSystem.Test
{
    public class UnitTest1
    {
        ATMCashWithDrawal atmcash;

        [SetUp]
        public void Setup()
        {
            var hsmModuleMock = new Mock<IHSMModule>();
            hsmModuleMock.Setup(h => h.ValidatePIN("123456781234", 1234)).Returns(true);

            var hostBankMock = new Mock<IHostBank>();
            hostBankMock.Setup(h => h.AuthenticateAmount("123456781234", 500)).Returns(true);

            atmCash = new ATMCashWithdrawal(hsmModuleMock.Object, hostBankMock.Object);
        }
        [TestCase]
        public void WithdrawAmount_ValidTransaction_ReturnsTrue()
        {
            bool result = atmCash.WithdrawAmount("123456781234", 1234, 500);
            // Assert
            Assert.IsTrue(result);
        }
    }
}
