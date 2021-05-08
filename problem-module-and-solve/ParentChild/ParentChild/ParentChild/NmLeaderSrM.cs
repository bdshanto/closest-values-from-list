using System.Collections.Generic;

namespace ParentChild
{
    public class NmLeaderSrM
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long? ReferralId { get; set; }
        public long? PlacementId { get; set; }


        public virtual NmLeaderSrM Referral { get; set; }
        public virtual NmLeaderSrM Placement { get; set; }

        public virtual ICollection<NmLeaderSrM> ReferredLeaders { get; set; } = new List<NmLeaderSrM>();
        public virtual ICollection<NmLeaderSrM> Associates { get; set; } = new List<NmLeaderSrM>();
    }
}