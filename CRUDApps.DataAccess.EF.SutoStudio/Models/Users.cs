using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDApps.DataAccess.EF.SutoStudio.Models
{
    public partial class Users
    {
        public Users()
        {
            LoyaltyChart = new HashSet<LoyaltyCharts>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerState { get; set; }

        public virtual ICollection<LoyaltyCharts> LoyaltyChart { get; set; }

        public Users(int userId, string userName, string customerFirstName, string customerLastName, string customerEmail, string customerState)
        {
            UserId = userId;
            UserName = userName;
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            CustomerEmail = customerEmail;
            CustomerState = customerState;
        }
    }
}
