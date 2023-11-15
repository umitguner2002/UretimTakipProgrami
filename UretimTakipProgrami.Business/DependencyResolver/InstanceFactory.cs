using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UretimTakipProgrami.Business.DependencyResolver
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModel());
            return kernel.Get<T>();
        }
    }
}
