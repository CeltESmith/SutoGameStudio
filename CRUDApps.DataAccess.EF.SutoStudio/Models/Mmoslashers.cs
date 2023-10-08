using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDApps.DataAccess.EF.SutoStudio.Models
{
    public partial class Mmoslashers
    {
        public Mmoslashers()
        {
            LoyaltyChart = new HashSet<LoyaltyCharts>();
        }

        public int MmoslasherId { get; set; }
        public TimeSpan? TimePlayed { get; set; }
        public string Expansion1 { get; set; }
        public string ActiveLast30Days { get; set; }
        public string OwnMmoslasherGame { get; set; }

        public virtual ICollection<LoyaltyCharts> LoyaltyChart { get; set; }

        public Mmoslashers(int mmoslasherId, TimeSpan timePlayed, string expansion1, string activeLast30days, string ownMmoslasherGame)
        {
            MmoslasherId = mmoslasherId;
            TimePlayed = timePlayed;
            Expansion1 = expansion1;
            ActiveLast30Days = activeLast30days;
            OwnMmoslasherGame = ownMmoslasherGame;

            LoyaltyChart = new HashSet<LoyaltyCharts>();
        }
    }
}
