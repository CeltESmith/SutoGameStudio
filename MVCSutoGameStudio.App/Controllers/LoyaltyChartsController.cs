using Microsoft.AspNetCore.Mvc;
using MVCSutoGameStudio.App.Models;
using CRUDApps.DataAccess.EF.SutoStudio.Models;
using CRUDApps.DataAccess.EF.SutoStudio.Context;

namespace MVCSutoGameStudio.App.Controllers
{
    public class LoyaltyChartsController : Controller
    {
        private readonly SutoGameStudioContext _Context;

        public LoyaltyChartsController(SutoGameStudioContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            LoyaltyChartViewModel model = new LoyaltyChartViewModel(_Context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int loyaltyChartId, int userId, int fpsblastId, int mmoslasherId, int rpgstoryMakerId, string isLoyalCustomer)
        {
            LoyaltyChartViewModel model = new LoyaltyChartViewModel(_Context);

            LoyaltyCharts loyaltyChart = new(loyaltyChartId, userId, fpsblastId, mmoslasherId, rpgstoryMakerId, isLoyalCustomer);

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
