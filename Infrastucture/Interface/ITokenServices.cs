using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Interface
{
    public interface ITokenServices
    {
        public string CreateToken(IdentityUser identityUser);
    }
}
