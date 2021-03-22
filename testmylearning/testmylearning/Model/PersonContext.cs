using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace testmylearning.Model
{
  
    public class Person 
        {
        [Key]
        public int id { get; set; }
       
        public string Name { get; set; }

        public string  password { get; set; }

        public double TotalAmount { get; set; }
        
    }
}
