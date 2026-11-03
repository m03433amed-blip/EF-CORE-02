using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_02
{
    public class OrganizerProfile
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public string WebsiteUrl { get; set; }
        public string LogoUrl { get; set; }

        public int OrganizerId { get; set; }          // FK
        public Organizer Organizer { get; set; }
    }
}
