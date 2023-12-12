using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Interfaces.Messages.AsyncMessage
{
    public interface IMessageBus
    {
        void AddQueue<T>(T message, string queueName);
    }
}
