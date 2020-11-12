using Autofac;
using GrupoESIDataAccess.Queries;
using GrupoESIDataAccess.Repository.IRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoESI.DependencyInjection
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ServiceTypeRepository>().As<IServiceTypeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<Queries>().As<IQueries>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceRepository>().As<IServiceRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderDetailsRepository>().As<IOrderDetailsRepository>().InstancePerLifetimeScope();
            builder.RegisterType<QuotationRepository>().As<IQuotationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TaskRepository>().As<ITaskRepository>().InstancePerLifetimeScope();
            builder.RegisterType<MaterialRepository>().As<IMaterialRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationUserRepository>().As<IApplicationUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PictureRepository>().As<IPictureRepository>().InstancePerLifetimeScope();
            builder.RegisterType<PredefinedTaskRepository>().As<IPredefinedTaskRepository>().InstancePerLifetimeScope();
        }
    }
}
