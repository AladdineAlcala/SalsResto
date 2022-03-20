using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalsResto.Data.ViewModel_DTO
{
    public abstract class CustomerManipulationDTO
    {
        [Required(ErrorMessage = "Customer name is a requied field")]
        [MaxLength(30, ErrorMessage = "Max length for name is 30 characters")]
        public string lastname { get; set; }
        [Required(ErrorMessage = "Customer lastname is a requied field")]
        [MaxLength(30, ErrorMessage = "Max length for name is 30 characters")]
        public string firstname { get; set; }
        public string middle { get; set; }
        [Required(ErrorMessage = "Customer name is requied field")]
        [MaxLength(100, ErrorMessage = "Max length for name is 30 characters")]
        public string address { get; set; }
        public string contact1 { get; set; }
        public string contact2 { get; set; }
        public Nullable<System.DateTime> datereg { get; set; }
        public string company { get; set; }
    }
}
