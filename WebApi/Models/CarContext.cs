using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class CarContext :DbContext
    {
        public CarContext() : base("MyCarString")
        {

        }
        public DbSet<CarStock> CarStock { get; set; }
    }
}