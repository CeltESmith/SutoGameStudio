using Microsoft.AspNetCore.Mvc;
using MVCSutoGameStudioAPP.Models;
using CRUDApps.DataAccess.EF.Models;
using CRUDApps.DataAccess.EF.Context;

namespace MVCSutoGameStudioAPP.Controllers
{
    public class LoyaltyChartController : Controller
    {
        private readonly SutoGameStudioContext _Context;

        public LoyaltyChartController(SutoGameStudioContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            LoyaltyChartViewModel model = new LoyaltyChartViewModel(_Context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int loyaltyChartId, string username, string ownFpsblastGame, string ownMmoslasherGame, string ownRpgstoryMakerGame, string isLoyalCustomer)
        {
            LoyaltyChartViewModel model = new LoyaltyChartViewModel(_Context);

            LoyaltyCharts loyaltyChart = new(loyaltyChartId, username, ownFpsblastGame, ownMmoslasherGame, ownRpgstoryMakerGame, isLoyalCustomer);

            model.SaveLoyaltyChart(loyaltyChart);
            model.IsActionSuccess = true;
            model.ActionMessage = "Loyalty Chart has been updated with a new users information!";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            LoyaltyChartViewModel model = new LoyaltyChartViewModel(_Context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            LoyaltyChartViewModel model = new LoyaltyChartViewModel(_Context);

            if (id > 0)
            {
                model.RemoveLoyaltyChart(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "The users Loyalty Chart has been successfully removed from database.";
            return View("Index", model);
        }
    }
}
