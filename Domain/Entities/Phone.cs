using Domain.DTOs.Phone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Phone: Entity
    {

        public PhoneOutput ToOutput()
        {
            return new PhoneOutput
            {

            };
        }
    }
}
