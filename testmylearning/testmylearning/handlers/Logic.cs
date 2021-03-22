using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testmylearning.handlers
{
    public class Logic
    {
        public float Check(double  money , double TotalAmount ,string cmd )
        {
            string message;
            
            if (cmd == "deposit")

            {
                TotalAmount = money + TotalAmount;
                message = "done";
            }
            if (cmd == "withdraw")
            {
                if (TotalAmount > money)
                {
                    
                    
                    TotalAmount = TotalAmount - money;
                    message = "can withdraw ";
                }

                else
                    message = "cant withdraw ";
               
            }


            return ((float)TotalAmount);
        }
    }
}
