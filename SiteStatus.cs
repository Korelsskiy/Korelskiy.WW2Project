using Korelskiy.WW2Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.WW2Project
{
    public class SiteStatus
    {
        public static User CurrentUser { get; set; } = new User() { UserName = "Не авторизован" };
    }
}
