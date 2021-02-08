using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using day2;
using Service.Common;
using Service;
using Repository;
using Repository.Common;

namespace Container
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<PepperService>().As<IPepperService>();
            builder.RegisterType<PepperRepository>().As<IPepperRepository>();

            return builder.Build();
        }
    }
}
