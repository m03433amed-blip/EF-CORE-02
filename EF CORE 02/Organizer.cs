using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_02
{
    
        [Table("EventOrganizers")]
        public class Organizer
        {
            public int Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string Name { get; set; }

            [MaxLength(150)]
            public string CompanyName { get; set; }   // optional

            public bool IsVerified { get; set; }

            // Navigation properties
            public OrganizerProfile Profile { get; set; }
            public ICollection<Event> Events { get; set; } = new List<Event>();

        }
    }
