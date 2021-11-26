using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953502_CHEKHOVICH.Entities
{
    public class Computer
    {
        public int ComputerId { get; set; }
        public string Name { get; set; }
        public int RAM { get; set; }
        public string GraphicsCard { get; set; }
        public string CPU { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }

        public int ComputerGroupId { get; set; }
        public ComputerGroup Group { get; set; }
    }
}
