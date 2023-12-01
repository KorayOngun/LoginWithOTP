using OrganikHaberlesme.Application.Interfaces.Repositories.LoginClaimRepo;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganikHaberlesme.LoginClaim
{
    public class LoginClaimRepository :  ILoginClaimRepo
    {
        
        private IDatabase _database; 
        public LoginClaimRepository()
        {
            var redisConfiguration = new ConfigurationOptions
            {
                EndPoints = { "localhost:6379" },
                Password = "your_password"
            };
            var context = ConnectionMultiplexer.Connect(redisConfiguration);
            _database = context.GetDatabase();
        }
        public async Task<string> GetAsync(string key)
        {
           
           return await _database.StringGetAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            
           var result = await _database.StringSetAsync(key, value,expiry:TimeSpan.FromMinutes(5));
        }
    }
}
