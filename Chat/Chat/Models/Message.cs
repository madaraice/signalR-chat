using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MessageText { get; set; }
        public string ReceiveTime { get; set; }
    }
}
