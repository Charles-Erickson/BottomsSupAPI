using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BottomsSupAPI.Models
{
    public class Tokens
    {
        [Key]
        public int TokenId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsComplete { get; set; }
    }
}
