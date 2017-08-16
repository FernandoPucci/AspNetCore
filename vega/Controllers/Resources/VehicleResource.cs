using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace vega.Controllers.Resources
{
    public class VehicleResource
    {
        public VehicleResource()
        {
            Features = new Collection<int>();

        }
        public int Id { get; set; }

        public int ModelId { get; set; }

        public bool IsRegister { get; set; }

        public ContactResource Contact { get; set; }

        public ICollection<int> Features { get; set; }
    }
}