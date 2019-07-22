using System.Collections.Generic;

namespace API.Core.Models
{
    public class Community
    {
        public int CommunityId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<CommunityMember> CommunityMembers { get; set; }
    }
}