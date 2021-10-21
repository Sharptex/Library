using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
    }
}
