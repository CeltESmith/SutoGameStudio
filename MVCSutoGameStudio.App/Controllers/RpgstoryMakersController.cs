﻿using CRUDApps.DataAccess.EF.Context;
using CRUDApps.DataAccess.EF.Models;
using MVCSutoGameStudioAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVCSutoGameStudioAPP.Controllers
{
	public class RpgstoryMakersController : Controller
	{
		private readonly SutoGameStudioContext _Context;

		public RpgstoryMakersController(SutoGameStudioContext context)
		{
			_Context = context;
		}

		public IActionResult Index()
		{
			RpgstoryMakersViewModel model = new RpgstoryMakersViewModel(_Context);
			return View(model);
		}

		[HttpPost]
		public IActionResult Index(int rpgstoryMakerId, string userName, TimeSpan timePlayed, string gameCompleted, string ownRpgstoryMakerGame, ICollection<LoyaltyCharts> loyaltyCharts)
		{
			RpgstoryMakersViewModel model = new RpgstoryMakersViewModel(_Context);

			RpgstoryMakers rpgstoryMakers = new(rpgstoryMakerId, userName, timePlayed, gameCompleted, ownRpgstoryMakerGame, loyaltyCharts);

			model.SaveRpgstoryMakers(rpgstoryMakers);
			model.IsActionSuccess = true;
			model.ActionMessage = "Role Playing Game Story Maker has been saved successfully.";

			return View(model);
		}

		public IActionResult Update(int id)
		{
			RpgstoryMakersViewModel model = new RpgstoryMakersViewModel(_Context, id);
			return View(model);
		}

		public IActionResult Delete(int id)
		{
			RpgstoryMakersViewModel model = new RpgstoryMakersViewModel(_Context);

			if (id> 0)
			{
				model.RemoveRpgstoryMakers(id);
			}

			model.IsActionSuccess = true;
			model.ActionMessage = "The Role PLaying Game Data has been successfully Deleted!";
			return View("Index", model);
		}
	}
}
