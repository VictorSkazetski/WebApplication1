using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ReqDataDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string EditProdName { get; set; }
        public string EditProdDescription { get; set; }
        public int Page { get; set; }
    }
}
