﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stayHealthy.Services.Models.User
{
    public class UserPasswordChange
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
