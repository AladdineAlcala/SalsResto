using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsResto.Data.Models
{
    public class Booking
    {
        [Column("BookingId")]
        public Guid Id { get; set; }
        public Nullable<System.DateTime> transdate { get; set; }
        public string booktype { get; set; }
        public Nullable<int> noofperson { get; set; }
        public string occasion { get; set; }
        public string venue { get; set; }
        public Nullable<int> typeofservice { get; set; }
        public Nullable<System.DateTime> startdate { get; set; }
        public Nullable<System.DateTime> enddate { get; set; }
        public string eventcolor { get; set; }
        public Nullable<int> p_id { get; set; }
        public string reference { get; set; }
        public Nullable<int> extendedAreaId { get; set; }
        public Nullable<bool> apply_extendedAmount { get; set; }
        public Nullable<Decimal> p_amount { get; set; }
        public Nullable<bool> serve_stat { get; set; }
        public Nullable<bool> is_cancelled { get; set; }
        public string b_createdbyUser { get; set; }
        public Nullable<System.DateTime> b_updatedDate { get; set; }
        public Nullable<System.DateTime> b_createdDate { get; set; }
        public Nullable<bool> is_deleted { get; set; }

        [ForeignKey(nameof(Customer))]
        public Guid cId { get; set; }
        public Customer Customer { get; set; }
    }
}
