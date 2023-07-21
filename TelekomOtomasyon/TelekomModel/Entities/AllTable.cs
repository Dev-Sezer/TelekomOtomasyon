using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelekomCore.Entity;

namespace TelekomModel.Entities
{
    public class AllTable : CoreEntity
    {
        public int PackageID { get; set; }
        public Package Package { get; set; }

        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
