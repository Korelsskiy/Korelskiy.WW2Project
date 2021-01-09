﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project.Models
{
    public class User : IdentityUser<Guid>
    {
        public string AvatarPath { get; set; }
    }
}
