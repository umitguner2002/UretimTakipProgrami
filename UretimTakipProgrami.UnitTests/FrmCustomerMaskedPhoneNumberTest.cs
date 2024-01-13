using NUnit.Framework;
using UretimTakipProgrami.Forms;

namespace UretimTakipProgrami.UnitTests
{
    public class FrmCustomerMaskedPhoneNumberTest
    {
        // FunctionUnderTest_ExpectedResult_UnderCondition
        FrmCustomer frmCustomer = new FrmCustomer();

        [Test]
        public void FrmCustomer_CorrectPhoneNumber_WithTenCharacterPhoneNumber()
        {
            // Arrange
            string phoneNumber = "5356332323";
            var stopwatch = new System.Diagnostics.Stopwatch();


            // Act
            stopwatch.Start();
            var phone = frmCustomer.MaskedPhoneNumber(phoneNumber);
            stopwatch.Stop();

            // Assert
            Assert.IsNotNull(phone);
            Assert.Pass($"Correct Phone Number, Elapsed Time:{stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        }

        [Test]
        public void FrmCustomer_IncorrectPhoneNumber_WithNotTenCharacterPhoneNumber()
        {
            // Arrange
            string phoneNumber = "53563323";
            var stopwatch = new System.Diagnostics.Stopwatch();

            // Act
            stopwatch.Start();
            var phone = frmCustomer.MaskedPhoneNumber(phoneNumber);
            stopwatch.Stop();

            // Assert
            Assert.IsEmpty(phone);
            Assert.Pass($"Incorrect Phone Number, Elapsed Time:{stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        }
    }
}