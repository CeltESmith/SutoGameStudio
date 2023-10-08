using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDApps.DataAccess.EF.SutoStudio.Models
{
    public partial class Fpsblasts
    {
        public Fpsblasts()
        {
            LoyaltyChart = new HashSet<LoyaltyCharts>();
        }

        public int FpsblastId { get; set; }
        public TimeSpan? TimePlayed { get; set; }
        public string Expansion1 { get; set; }
        public string OwnFpsblastGame { get; set; }

        public virtual ICollection<LoyaltyCharts> LoyaltyChart { get; set; }

        public Fpsblasts(int fpsblastId, TimeSpan timePalyed, string expansion1, string ownFpsblastGame)
        {
            FpsblastId = fpsblastId;
            TimePlayed = timePalyed;
            Expansion1 = expansion1;
            OwnFpsblastGame = ownFpsblastGame;

            LoyaltyChart = new HashSet<LoyaltyCharts>();
        }
    }
}
