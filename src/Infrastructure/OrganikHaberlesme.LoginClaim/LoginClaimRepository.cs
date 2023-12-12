using OrganikHaberlesme.Application.Interfaces.Repositories.LoginClaimRepo;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.LoginClaim
{
    public class LoginClaimRepository : ILoginClaimRepo
    {
        
        private IDatabase _database; 
        public LoginClaimRepository(ConfigurationOptions configurationOptions)
        {
            var context = ConnectionMultiplexer.Connect(configurationOptions);
            _database = context.GetDatabase();
        }

        public async Task DeleteAsync(string key)
        {
            await _database.StringGetDeleteAsync(key);
        }

        public async Task<string> GetAsync(string key)
        {
           return await _database.StringGetAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
           var result = await _database.StringSetAsync(key, value,expiry:TimeSpan.FromMinutes(3));
        }
        
    }
}
