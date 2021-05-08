using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2
{
    public class NmLeaderSrM
    {
        public NmLeaderSrM()
        {
            Associates  = new List<NmLeaderSrM>();
        }
        public long Id { get; set; }
        [NotMapped]
        public long LoopThroughId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhotoUrl { get; set; }
        public string CoverPhotoUrl { get; set; }
        public string Description { get; set; }
        public string AutoGenCode { get; set; }
        public long? ReferralId { get; set; } // who is referring 
        public long? PlacementId { get; set; } // immediate parent
        public long UserId { get; set; }

        public DateTime JoiningDate { get; set; }


        //------------
        public string ClosingStatementCode { get; set; } // AutoGenCode, Another Class
        public string RankId { get; set; } // such as, *, **, *** etc.  we will move this to another class
        public double Unit { get; set; } // such as, 1500 etc.  we will move this to another class

        public double ReferralBonus { get; set; }
        public double GenerationBonus { get; set; }
        public double RankBonus { get; set; }
        public long OrganizationId { get; set; }


        public virtual NmLeaderSrM Referral { get; set; }
        public virtual NmLeaderSrM Placement { get; set; }

        public virtual ICollection<NmLeaderSrM> Associates { get; set; } = new List<NmLeaderSrM>();

        //not mapped models
        public bool IsRootNode { get; set; }
        public bool IsUpNodeConnected { get; set; }
        public bool IsDownNodeConnected { get; set; }
    }
}