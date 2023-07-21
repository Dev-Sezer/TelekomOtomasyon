using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelekomCore.Entity;

namespace TelekomModel.Entities
{
    public class Package : CoreEntity
    {
        public string PackageName { get; set; }
        public string Contents { get; set; }
    }
}
