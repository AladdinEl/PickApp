using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KomOchHämta.Views.Products
{
    public class MembersVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; }
        public string ReservedBy { get; set; }
        public bool Reserved {  get; set; }
    }
}
