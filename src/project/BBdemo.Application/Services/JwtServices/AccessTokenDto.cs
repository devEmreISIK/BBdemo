﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBdemo.Application.Services.JwtServices;

public class AccessTokenDto
{
    public string Token { get; set; }
    public DateTime TokenExpiration { get; set; }
}
