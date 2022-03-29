using System;
using System.Collections.Generic;
using System.Text;

namespace Bader.Core.DTO
{
    public  class ResponseDTO
    {
        public string ResponeTitle { get; set; }    
        public string ResponeDescription { get; set; }

        public DateTime ResponseDate { get; set; }
        
        public string ResponseReciver { get; set; }
    }
}
