using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreConcurrency
{
    public class Product
    {
        public int Id { get; set;  } 
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public byte[] RowVersion { get; set; } // Concurrency token
    }
}
