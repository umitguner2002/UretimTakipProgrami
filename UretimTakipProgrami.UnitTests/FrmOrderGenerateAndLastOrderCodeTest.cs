using NUnit.Framework;
using UretimTakip.Forms;

namespace UretimTakipProgrami.UnitTests
{
    public class FrmOrderGenerateAndLastOrderCodeTest
    {
        // FunctionUnderTest_ExpectedResult_UnderCondition
        FrmOrder frmOrder = new FrmOrder();

        [Test]
        public void FrmOrder_ValidOrderCode_CurrentYearData()
        {
            // Arrange
            int currentYear = DateTime.Now.Year;
            var stopwatch = new System.Diagnostics.Stopwatch();

            // Act
            stopwatch.Start();
            var orderCode = frmOrder.GenerateOrderCode(currentYear);
            stopwatch.Stop();

            // Assert
            Assert.IsNotNull(orderCode);
            Assert.Pass($"Correct OrderCode: { orderCode } \nElapsed Time:{stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        }

        [Test]
        public void FrmOrder_LastOrderCode_NoData()
        {
            // Arrange
            var stopwatch = new System.Diagnostics.Stopwatch();

            // Act
            stopwatch.Start();
            var lastOrder = frmOrder.GetLastProductCodeFromDatabase();
            stopwatch.Stop();

            // Assert
            Assert.IsNotNull(lastOrder);
            Assert.Pass($"Correct LastOrderCode: {lastOrder} \nElapsed Time:{stopwatch.Elapsed.TotalMilliseconds:F4} ms");
        }
    }
}
