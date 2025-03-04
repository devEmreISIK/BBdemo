using BBdemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Services.JwtServices;

public interface IJwtService
{
    Task<AccessTokenDto> CreateTokenAsync(User user);

}
