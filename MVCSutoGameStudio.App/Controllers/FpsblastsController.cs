using Microsoft.AspNetCore.Mvc;
using MVCSutoGameStudioAPP.Models;
using CRUDApps.DataAccess.EF.Context;
using CRUDApps.DataAccess.EF.Models;

namespace MVCSutoGameStudioAPP.Controllers
{
	public class FpsblastsController : Controller
	{
		private readonly SutoGameStudioContext _Context;

		public FpsblastsController(SutoGameStudioContext context)
		{
			_Context = context;
		}

		public IActionResult Index()
		{
			FpsblastsViewModel model = new FpsblastsViewModel(_Context);
			return View(model);
		}

		[HttpPost]
		public IActionResult Index(int fpsblastId, string userName, TimeSpan timePlayed, string expansion1, string ownFpsblastGame, ICollection<Fpsblasts> loyaltyCharts)
		{
			FpsblastsViewModel model = new FpsblastsViewModel(_Context);
				
			Fpsblasts fpsblasts = new(fpsblastId, userName, timePlayed, expansion1, ownFpsblastGame, loyaltyCharts);

			model.SaveFpsblasts(fpsblasts);
			model.IsActionSuccess = true;
			model.ActionMessage = "The First Person Shooter Blasts game has been updated.";

			return View(model);
		}

		public IActionResult Update(int id)
		{
			FpsblastsViewModel model = new FpsblastsViewModel(_Context, id);
			return View(model);
		}
		
		public IActionResult Delete(int id)
		{
			FpsblastsViewModel model = new FpsblastsViewModel(_Context);

			if (id> 0)
			{
				model.RemoveFpsblasts(id);
			}

			model.IsActionSuccess = true;
			model.ActionMessage = "First Person Shooter entry has been deleted successfully.";
			return View("Index", model);
		}
	}
}
