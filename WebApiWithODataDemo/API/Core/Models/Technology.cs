using System.Collections.Generic;

namespace API.Core.Models
{
    public class Technology
    {
        public int TechnologyId { get; set; }

        public string Name { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}