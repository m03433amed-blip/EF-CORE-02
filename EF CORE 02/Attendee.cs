using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_02
{
    public class Attendee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(150)]
        public string Street { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(20)]
        [Column("ZipCode")]
        public string PostalCode { get; set; }

        // Read-only, must NOT become a column
        [NotMapped]
        public string FullAddress => $"{Street}, {City}, {Country}, {PostalCode}";

        // Navigation property
        public Badge Badge { get; set; }
    }
}
