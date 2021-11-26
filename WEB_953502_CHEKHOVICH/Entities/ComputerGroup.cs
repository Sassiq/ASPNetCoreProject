using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953502_CHEKHOVICH.Entities
{
    public class ComputerGroup
    {
        public int ComputerGroupId { get; set; }
        public string GroupName { get; set; }
        public List<Computer> Computers { get; set; }
    }
}
