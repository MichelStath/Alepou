using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Tables
{
    public class UserEventTable
    {
        public Guid EventId { get; set; }
        public string UserId { get; set; }
        public DateTime EventDateTime { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string EventParticipants { get; set; }
    }
}
