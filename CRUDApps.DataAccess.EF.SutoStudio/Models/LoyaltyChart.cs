using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDApps.DataAccess.EF.SutoStudio.Models
{
    public partial class LoyaltyChart
    {
        public int LoyaltyChartId { get; set; }
        public int UserId { get; set; }
        public int FpsblastId { get; set; }
        public int MmoslasherId { get; set; }
        public int RpgstoryMakerId { get; set; }
        public string IsLoyalCustomer { get; set; }

        public virtual Fpsblast Fpsblast { get; set; }
        public virtual Mmoslasher Mmoslasher { get; set; }
        public virtual RpgstoryMaker RpgstoryMaker { get; set; }
        public virtual Users User { get; set; }
    }
}
