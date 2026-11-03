using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_02
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }        // optional
        public int MaxAttendees { get; set; }

        public int OrganizerId { get; set; }          // FK
        public Organizer Organizer { get; set; }
    }
}
