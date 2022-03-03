using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsResto.Data.Models
{
    public class Customer
    {
        [Column("CustomerId")]
        public Guid Id { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string middle { get; set; }
        public string address { get; set; }
        public string contact1 { get; set; }
        public string contact2 { get; set; }
        public Nullable<System.DateTime> datereg { get; set; }
        public string company { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
