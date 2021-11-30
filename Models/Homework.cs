using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOList.Models
{
    public class Homework
    {
        public int Id { get; set; }
        public int Task_Id { get; set; }
        public int Kasutajad_Id { get; set; }
        public string Deadline { get; set; }
        public string Subject { get; set; }
        public string Work_Type { get; set; }
        public string Work_Date { get; set; }
    }
}
