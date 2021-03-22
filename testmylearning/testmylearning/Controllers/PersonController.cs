using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class PersonController : ControllerBase
    {

        DataContext obj =null;
       

        public PersonController(DataContext _obj)
        {
            obj = _obj; 
        }

        [HttpGet ]
        public List<Person> getPersons()
        {
           
                
                var listPerson = obj.persons.ToList();
          
                return listPerson[0];


            
        }
        [HttpPost]
        public ActionResult InsertPerson(Person p)
        {
            obj.persons.Add(p);
            obj.SaveChanges();
            return NoContent();

        }
        [HttpPut]
        public ActionResult UpdatePerson(Person p)
        {
            var per = obj.persons.Where(i => i.id == p.id).First();
            per.Name = p.Name;
            per.password = p.password;
            per.TotalAmount = p.TotalAmount;
            obj.SaveChanges();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var p = obj.persons.Where(i => i.id == id).First();
            obj.Remove(p);
            obj.SaveChanges();
            return NoContent();

        }
        [HttpGet("{id}")]
        public Person SinglePerson(int  id)
        {
            var p = obj.persons.Where(i => i.id == id).First();
            return p;

        }

        
      /*  [HttpPut("{id}/{cmd}/{a}")]
        public ActionResult UpdateAmount(int id,int a,string cmd)
        {
            var per = obj.persons.Where(i => i.id ==id).First();
            if (cmd == "deposit")
            {
                per.TotalAmount = per.TotalAmount + a;
            }
            if(cmd== "withdraw")
            {
                per.TotalAmount = per.TotalAmount - a;
            }
            obj.SaveChanges();
            return NoContent();

        }

        [HttpPut("{cmd}/{number}")]
        public ActionResult UpdateAmountAut(string cmd, double number)
        { string authheader = HttpContext.Request.Headers["Authorization"];
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

                /*   if (cmd == "deposit")

               {
                           per.TotalAmount = per.TotalAmount + number ;
               }
               if (cmd == "withdraw")
                   {
                       if (per.TotalAmount > number)
                           per.TotalAmount = per.TotalAmount - number;

                       else
                           return Ok("cant withdraw ");
               }
                Logic t = new Logic();
                float mo = (float)per.TotalAmount;
                per.TotalAmount = t.Check(number, per.TotalAmount, cmd);
                obj.SaveChanges();

                if (mo != per.TotalAmount)
                    return Ok(per.TotalAmount);

                else
                    return Ok("can't");



                } 
                else
                {
                    return Ok("cant connect ");
                }
            
       
            

        }

        [HttpPut("rats/{money}")]
        public ActionResult  UpdateMu(float money )
        {
            Logic a = new Logic();
            float valu = a.Check(money , 100, "withdraw");

            return Ok(valu);*/
        }

    }

