using MoqDemo;
using Moq;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        ATMCashWithDrawal atmcash;

        [SetUp]
        public void Setup()
        {
            var hsmModuleMock = new Mock<IHSMModule>();
            hsmModuleMock.Setup(h => h.ValidatePIN("123456781234", 1234)).Returns(true);

            var hostBankMock = new Mock<IHostBank>();
            hostBankMock.Setup(h => h.Authenticate("123456781234", 500)).Returns(true);

            atmcash = new ATMCashWithDrawal(hsmModuleMock.Object, hostBankMock.Object);
        }
        [TestCase]
        public void WithdrawAmount_ValidTransaction_ReturnsTrue()
        {
            bool result = atmcash.WithdrawAmount("123456781234", 1234, 500);
            // Assert
            Assert.IsTrue(result);
        }
    }
}