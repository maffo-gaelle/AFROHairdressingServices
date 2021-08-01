using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFROHairdressingServices.Security.API.Infrastructures.Security
{
    public interface ITokenRepository
    {
        string GenerateToken(TokenUser user);
        TokenUser ValidateToken(string token);
    }
}
