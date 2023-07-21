using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelekomCore.Entity;

namespace TelekomModel.Entities
{
    public class Customer : CoreEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string  Tc { get; set; }
    }
}
