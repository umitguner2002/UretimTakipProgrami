using NUnit.Framework;
using UretimTakipProgrami.Business.DependencyResolver;
using UretimTakipProgrami.Business.Repositories.Concretes;
using UretimTakipProgrami.Entities;
using UretimTakipProgrami.Forms;

namespace UretimTakipProgrami.UnitTests
{

    public class FrmProductionGetListsTest
    {
        private UserRepository _userRepository;
        private User? _user;
        private FrmProduction _frmProduction;

        public FrmProductionGetListsTest()
        {
            _userRepository = InstanceFactory.GetInstance<UserRepository>();
            _user = _userRepository.GetWhere(u => u.IsAdmin).FirstOrDefault();
            _frmProduction = new FrmProduction(_user);
        }

        [Test]
        public void FrmProduction_GetProductionList_WithOrderId()
        {
            // Arrange
            string orderId = "414f084c-d02f-4aa9-a6df-c76865d2f457";

            // Act
            var production = _frmProduction.GetDailyProductionT(orderId);            

            // Assert
            Assert.IsNotNull(production);
            Assert.Pass(production.Count.ToString());
        }
    }
}
