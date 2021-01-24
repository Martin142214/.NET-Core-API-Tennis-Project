using Bussiness_layer.Models.LoginModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness_layer.RepServices.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(AuthModel model);
        Task<string> GenerateToken(PlayerAuthModel player);
    }
}
