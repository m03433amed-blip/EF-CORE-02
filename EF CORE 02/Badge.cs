using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_02
{
    public class Badge
    {
        public int Id { get; set; }
        public int BadgeNumber { get; set; }
        public DateTime IssuedDate { get; set; }
        public BadgeTier Tier { get; set; }

        public int AttendeeId { get; set; }           // FK
        public Attendee Attendee { get; set; }
    }
}
