using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection service)
        {
            var assm = Assembly.GetExecutingAssembly();
            service.AddMediatR(assm);
        }
    }
}
