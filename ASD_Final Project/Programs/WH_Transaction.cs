using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Final_Project.Programs
{
    public class WH_Transaction
    {

        public int Id { get; set; }
        public string note { get; set; }
        public string EntryDate { get; set; }
        public string ExportDate { get; set; }
        public string Type { get; set; }
        public int WarehouseId { get; set; }
    }
}
