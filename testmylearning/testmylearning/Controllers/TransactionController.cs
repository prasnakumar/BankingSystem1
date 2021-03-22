using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testmylearning.Data;
using testmylearning.handlers;
using testmylearning.Model;

namespace testmylearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        DataContext obj = null;
        public TransactionController(DataContext _obj)
        {
            obj = _obj;
        }

        [HttpPut("{id}/{cmd}/{a}")]
        public ActionResult UpdateAmount(int id, int a, string cmd)
        {
            var per = obj.persons.Where(i => i.id == id).First();
            if (cmd == "deposit")
            {
                per.TotalAmount = per.TotalAmount + a;
            }
            if (cmd == "withdraw")
            {
                per.TotalAmount = per.TotalAmount - a;
            }
            obj.SaveChanges();
            return NoContent();

        }

        [HttpPut("{cmd}/{number}")]
        public ActionResult UpdateAmountAut(string cmd, double number)
        {
            string authheader = HttpContext.Request.Headers["Authorization"];
            if (authheader != null && authheader.StartsWith("Basic"))
            {

                string a = authheader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("UTF-8");
                string b = encoding.GetString(Convert.FromBase64String(a));

                int index = b.IndexOf(":");

                var username = b.Substring(0, index);
                var password = b.Substring(index + 1);
                Person per = obj.persons.Where(i => i.Name == username && i.password == password).FirstOrDefault();
           
               
               
                    
                if (per == null)
                {
                    return Unauthorized();

                }
                int IDS = per.id;
                Transactions l = new Transactions
                {
                    userid = IDS,
                    Amount = (float)number,
                    CreatedDate = DateTime.Now
                };



                obj.Transaction.Add(l);
              

                
                Logic t = new Logic();
                float mo = (float)per.TotalAmount;
                per.TotalAmount = t.Check(number, per.TotalAmount, cmd);
                obj.SaveChanges();

                if (mo != per.TotalAmount)
                    return Ok(per.TotalAmount);


                else
                    return Conflict("amount of bal is high");


            }
            else
            {
                return NotFound("User Not FOund");
            }
 }
    }
}
