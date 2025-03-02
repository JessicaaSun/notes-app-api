using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using notes_api.Models;

namespace api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}