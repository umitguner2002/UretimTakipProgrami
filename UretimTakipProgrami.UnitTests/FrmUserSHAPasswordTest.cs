using NUnit.Framework;
using UretimTakipProgrami.Forms;

namespace UretimTakipProgrami.UnitTests
{
    public class FrmUserSHAPasswordTest
    {
        [Test]
        public void FrmUser_PasswordSHA_WithAnyText()
        {
            // Arrange
            FrmUser frmUser = new FrmUser();

            // Act
            var passwordSHA = frmUser.SHA256Hash("trialData");

            // Assert
            Assert.NotNull(passwordSHA);
            Assert.Pass(passwordSHA);
        }
    }
}
