namespace API.Core.Models
{
    public class CommunityMember
    {
        public int CommunityId { get; set; }

        public Community Community { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }
    }
}