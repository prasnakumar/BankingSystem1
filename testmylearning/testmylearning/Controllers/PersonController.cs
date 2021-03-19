using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testmylearning.Model;

namespace testmylearning.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        PersonContext obj =null;
       

        public PersonController(PersonContext _obj)
        {
            obj = _obj; 
        }

        [HttpGet ]
        public List<person> getPersons()
        {
           
                
                var listPerson = obj.persons.ToList();
                return listPerson;


            
        }
        [HttpPost]
        public ActionResult InsertPerson(person p)
        {
            obj.persons.Add(p);
            obj.SaveChanges();
            return NoContent();

        }
        [HttpPut]
        public ActionResult UpdatePerson(person p)
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
        public person SinglePerson(int  id)
        {
            var p = obj.persons.Where(i => i.id == id).First();
            return p;

        }

        
        [HttpPut("{id}/{cmd}/{a}")]
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
        public ActionResult UpdateAmountAut(string cmd,float number)
        { string authheader = HttpContext.Request.Headers["Authorization"];
                if (authheader != null && authheader.StartsWith("Basic"))
                {

                    string a = authheader.Substring("Basic ".Length).Trim();
                    Encoding encoding = Encoding.GetEncoding("UTF-8");
                    string b = encoding.GetString(Convert.FromBase64String(a));

                    int index = b.IndexOf(":");

                    var username = b.Substring(0, index);
                    var password = b.Substring(index + 1);
                    person per = obj.persons.Where(i => i.Name==username && i.password==password).FirstOrDefault();
                   if (per == null)
                {
                    return Unauthorized();

                }
                if (cmd == "deposit")
                   
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
            obj.SaveChanges();
            return NoContent();

                   
                }
                else
                {
                    return Ok("cant");
                }
            
       
            

        }

    }
}
