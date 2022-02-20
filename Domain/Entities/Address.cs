using Domain.DTOs.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address: Entity
    {


        public AddressOutput ToOutput()
        {
            return new AddressOutput
            {

            };
        }

    }
}
