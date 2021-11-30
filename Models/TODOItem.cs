using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOList.Models
{
    public class TODOItem
    {
        public int Id { get; set; }
        public string Expected_Deadline { get; set; }
        public string Task_Size { get; set; }
        public string Study_Materials { get; set; }
        public string Task_Type { get; set; }
        public string Information { get; set; }
        public string Description { get; set; }
    }
}
