using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.DTO
{
    public class LoginResultDTO
    {
        public string Email { get; set; }
        public int? roleID { get; set; }
        public int? AdminId { get; set; }

        public int? CharityID { get; set; } 
    }
}
