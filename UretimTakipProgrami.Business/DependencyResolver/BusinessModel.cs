using Ninject.Modules;
using UretimTakipProgrami.Business.Repositories.Abstractions;
using UretimTakipProgrami.Business.Repositories.Concretes;

namespace UretimTakipProgrami.Business.DependencyResolver
{
    public class BusinessModel : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerRepository>().To<CustomerRepository>().InSingletonScope();
            Bind<IMachineProgramRepository>().To<MachineProgramRepository>().InSingletonScope();
            Bind<IMachineRepository>().To<MachineRepository>().InSingletonScope();
            Bind<IMaterialRepository>().To<MaterialRepository>().InSingletonScope();
            Bind<IMaterialShapeRepository>().To<MaterialShapeRepository>().InSingletonScope();
            Bind<IMaterialTypeRepository>().To<MaterialTypeRepository>().InSingletonScope();
            Bind<IOrderRepository>().To<OrderRepository>().InSingletonScope();
            Bind<IProductionRepository>().To<ProductionRepository>().InSingletonScope();
            Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
        }
    }
}
