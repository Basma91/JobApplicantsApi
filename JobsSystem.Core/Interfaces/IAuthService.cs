using JobsSystem.Core.Models.Registeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsSystem.Core.Interfaces
{
   public interface IAuthService
    {
         Task<AuthModel> RegisterAsync(RegisterationModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);

        Task<String> AddRoleAsync(AddRoleModel model);
    }
}
