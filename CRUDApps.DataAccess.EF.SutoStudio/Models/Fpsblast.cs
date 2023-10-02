using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDApps.DataAccess.EF.SutoStudio.Models
{
    public partial class Fpsblast
    {
        public Fpsblast()
        {
            LoyaltyChart = new HashSet<LoyaltyChart>();
        }

        public int FpsblastId { get; set; }
        public TimeSpan? TimePlayed { get; set; }
        public string Expansion1 { get; set; }
        public string OwnFpsblastGame { get; set; }

        public virtual ICollection<LoyaltyChart> LoyaltyChart { get; set; }
    }
}
