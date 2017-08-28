using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2Api.Models
{
    public class MemberContext1:DbContext
    {
        public  MemberContext1():base("name= MemberContext1")
        {

        }
        public DbSet<Member1> Member1s { get; set; }
    }
}