using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsResto.Data.ViewModel_DTO
{
    public class CustomerDTOView
    {
        public Guid Id { get; set; }
        public string fullname { get; set; }
        public string address { get; set; }
        public string contact1 { get; set; }
        public string contact2 { get; set; }
        public Nullable<System.DateTime> datereg { get; set; }
        public string company { get; set; }
    }
}
