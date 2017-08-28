using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.DTO_s
{
    public class CarStockDTO
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
        public int CarPrice { get; set; }
    }
}