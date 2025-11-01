using CMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Abstractions.Services;

public interface ITokenService
{
    string GenerateToken(User user);
    bool ValidateToken(string token);
    Guid? GetUserIdFromToken(string token);
}

