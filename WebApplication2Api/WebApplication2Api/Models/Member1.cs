using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2Api.Models
{
    public class Member1
    {
        [Key]
        public int MemId { get; set; }
        public string MemName { get; set; }
        public string MemEmail { get; set; }
        public string MemAddress { get; set; }
    }
}