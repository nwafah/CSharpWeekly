using System;
using System.Collections.Generic;
using System.Text;

namespace ResultPattern.Model
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Email { get; set; } = string.Empty;
    }
}
