using Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganikHaberlesme.Application.Interfaces.Messages;
using OrganikHaberlesme.Application.Interfaces.Messages.AsyncMessage;
using OrganikHaberlesme.Infrastructure.MessageService.AsyncMessage;
using OrganikHaberlesme.Infrastructure.MessageService.EmailMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<EmailMessageSettings>(opt =>
            {
                configuration.GetSection(nameof(EmailMessageSettings)).Bind(opt);
            });

            services.Configure<RabbitMQSettings>(opt =>
            {
                configuration.GetSection(nameof(RabbitMQSettings)).Bind(opt);
            });


            services.AddScoped<IMessageBus,RabbitMQMessagePublisher>();
            services.AddScoped<IEmailMessageService, EmailMessageService>();
            services.AddHangfire(opt => opt.UseSqlServerStorage(configuration.GetConnectionString("HangfireSqlCon")));
        }

    }
}
