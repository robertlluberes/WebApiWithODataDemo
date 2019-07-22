using System.Collections.Generic;

namespace API.Core.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        public string Name { get; set; }

        public double Salary { get; set; }

        public int TechnologyId { get; set; }

        public Technology Technology { get; set; }

        public ICollection<CommunityMember> CommunityMembers { get; set; }
    }
}