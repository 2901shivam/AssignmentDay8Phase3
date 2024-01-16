using System;
using System.Collections.Generic;

namespace AssignmentDay8.Models
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int? BookPrice { get; set; }
        public string? Bookcategory { get; set; }
    }
}
