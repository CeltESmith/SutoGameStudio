using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDApps.DataAccess.EF.SutoStudio.Models
{
    public partial class Mmoslasher
    {
        public Mmoslasher()
        {
            LoyaltyChart = new HashSet<LoyaltyChart>();
        }

        public int MmoslasherId { get; set; }
        public TimeSpan? TimePlayed { get; set; }
        public string Expansion1 { get; set; }
        public string ActiveLast30Days { get; set; }
        public string OwnMmoslasherGame { get; set; }

        public virtual ICollection<LoyaltyChart> LoyaltyChart { get; set; }
    }
}
