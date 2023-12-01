using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Interfaces.Messages
{
    public interface IMessageService
    {
        void Send(string to, string message);
    }
}
