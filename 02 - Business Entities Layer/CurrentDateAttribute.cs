using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public override bool IsValid(Object value)
        {          
            DateTime dateTime = Convert.ToDateTime(value);

            return dateTime <= DateTime.Now;
        }
    }
}

