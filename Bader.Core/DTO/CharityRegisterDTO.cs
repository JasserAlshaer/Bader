using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.DTO
{
    public class CharityRegisterDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool? IsActive { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
