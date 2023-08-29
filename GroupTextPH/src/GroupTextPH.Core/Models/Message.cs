using System;
using System.Collections.Generic;
using System.Text;

namespace GroupTextPH.Core.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Recipients { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
