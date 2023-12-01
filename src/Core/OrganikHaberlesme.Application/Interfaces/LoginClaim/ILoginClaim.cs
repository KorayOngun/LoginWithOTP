using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Interfaces.LoginClaim
{
    public interface ILoginClaim
    {
        Task<bool> CreateLoginClaim(Guid OtpController);
    }
}
