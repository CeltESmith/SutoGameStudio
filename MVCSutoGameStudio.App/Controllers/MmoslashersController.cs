using CRUDApps.DataAccess.EF.Context;
using CRUDApps.DataAccess.EF.Models;
using Microsoft.AspNetCore.Mvc;
using MVCSutoGameStudioAPP.Models;

namespace MVCSutoGameStudioAPP.Controllers
{
	public class MmoslashersController : Controller
	{
		private readonly SutoGameStudioContext _Context;

		public MmoslashersController(SutoGameStudioContext context)
		{
			_Context = context;
		}

		public IActionResult Index()
		{
			MmoslashersViewModel model = new MmoslashersViewModel(_Context);
			return View(model);
		}

		[HttpPost]
		public IActionResult Index(int mmoslasherId, string userName, TimeSpan timePlayed, string expansion1, string activeLast30Days, string ownMmoslasherGame, ICollection<Mmoslashers> loyaltyCharts)
		{
			MmoslashersViewModel model = new MmoslashersViewModel(_Context);
			Mmoslashers mmoslasher = new(mmoslasherId, userName, timePlayed, expansion1, activeLast30Days, ownMmoslasherGame, loyaltyCharts);

			model.SaveMmoslashers(mmoslasher);
			model.IsActionSuccess = true;
			model.ActionMessage = "The Mass Multiplayer Online game Slashers has been saved!";
			return View(model);
		}

		public IActionResult Update(int id)
		{
			MmoslashersViewModel model = new MmoslashersViewModel(_Context, id);
			return View(model);
		}

		public IActionResult Delete(int id)
		{
			MmoslashersViewModel model = new MmoslashersViewModel(_Context);

			if (id>0)
			{
				model.RemoveMmoslashers(id);
			}

			model.IsActionSuccess = true;
			model.ActionMessage = "Mass Multiplayer Online user infom has been deleted.";
			return View("Index", model);
		}
	}
}
