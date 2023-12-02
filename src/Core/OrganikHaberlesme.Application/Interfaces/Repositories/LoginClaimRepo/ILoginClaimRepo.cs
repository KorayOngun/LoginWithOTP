using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.Application.Interfaces.Repositories.LoginClaimRepo
{
    public interface ILoginClaimRepo
    {
        Task SetAsync(string key,string value);
        Task<string> GetAsync(string key);
        Task DeleteAsync(string key);
        
    }
}
