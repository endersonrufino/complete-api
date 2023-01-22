using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
    }
}
