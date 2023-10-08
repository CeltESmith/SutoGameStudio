using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDApps.DataAccess.EF.SutoStudio.Models
{
    public partial class LoyaltyCharts
    {
        public int LoyaltyChartId { get; set; }
        public int UserId { get; set; }
        public int FpsblastId { get; set; }
        public int MmoslasherId { get; set; }
        public int RpgstoryMakerId { get; set; }
        public string IsLoyalCustomer { get; set; }

        public virtual Fpsblasts Fpsblast { get; set; }
        public virtual Mmoslashers Mmoslasher { get; set; }
        public virtual RpgstoryMakers RpgstoryMaker { get; set; }
        public virtual Users User { get; set; }

        public LoyaltyCharts(int loyaltyChartId, int userId, int fpsblastId, int mmoslasherId, int rpgstoryMakerId, string isLoyalCustomer)
        {
            LoyaltyChartId = loyaltyChartId;
            UserId = userId;
            FpsblastId = fpsblastId;
            MmoslasherId = mmoslasherId;
            RpgstoryMakerId = rpgstoryMakerId;
            IsLoyalCustomer = isLoyalCustomer;
        }

        public LoyaltyCharts()
        {

        }
    }
}
