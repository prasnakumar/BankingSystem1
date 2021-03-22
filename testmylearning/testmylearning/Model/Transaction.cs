using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testmylearning.Model
{
   

        public class Transactions
        {
            [Key]
            public int id { get; set; }

            [ForeignKey("person")]
            public int userid { get; set; }
            public float Amount { get; set; }
        
        
        public DateTime CreatedDate { get; set; }
    }
    }

