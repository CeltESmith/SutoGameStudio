using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDApps.DataAccess.EF.SutoStudio.Models
{
    public partial class RpgstoryMakers
    {
        public RpgstoryMakers()
        {
            LoyaltyChart = new HashSet<LoyaltyCharts>();
        }

        public int RpgstoryMakerId { get; set; }
        public TimeSpan? TimePlayed { get; set; }
        public string GameCompleted { get; set; }
        public string OwnRpgstoryMakerGame { get; set; }

        public virtual ICollection<LoyaltyCharts> LoyaltyChart { get; set; }

        public RpgstoryMakers(int rpgstoryMakerId, TimeSpan timePlayed, string gameCompleted, string ownRpgstoryMakerGame)
        {
            RpgstoryMakerId = rpgstoryMakerId;
            TimePlayed = timePlayed;
            GameCompleted = gameCompleted;
            OwnRpgstoryMakerGame = ownRpgstoryMakerGame;

            LoyaltyChart = new HashSet<LoyaltyCharts>();
        }
    }
}
