using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Models
{
    public class Make
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }

        // make.Models = new Collection<Model>();
        public Make()
        {
            Models = new Collection<Model>();
        }
        
    }
}