using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int JobID { get; set; }
        public Job Job { get; set; }
    }
}
