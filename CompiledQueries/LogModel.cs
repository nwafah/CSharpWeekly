using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompiledQueries
{
    public class LogModel
    {
        [Key]
        public int LogID { get; set; }
        public int? EmployeeID { get; set; }
        public int? GateID { get; set; }
        public DateTime? TransactionDateTime { get; set; }
        public int? IsProcessed { get; set; }
    }
}
