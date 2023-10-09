using CRUDApps.DataAccess.EF.SutoStudio.Context;
using MVCSutoGameStudio.App.Models;
using Microsoft.AspNetCore.Mvc;
using CRUDApps.DataAccess.EF.SutoStudio.Models;

namespace MVCSutoGameStudio.App.Controllers
{
	public class UsersController : Controller
	{
		private readonly SutoGameStudioContext _Context;

		public UsersController(SutoGameStudioContext context)
		{
			_Context = context;
		}

		public IActionResult Index()
		{
			UsersViewModel model = new UsersViewModel(_Context);
			return View(model);
		}

		[HttpPost]
		public IActionResult Index(int userId, string userName, string customerFirstName, string customerLastName, string customerEmail, string customerState, LoyaltyCharts userNameNavigation)
		{
			UsersViewModel model = new UsersViewModel(_Context);
			Users users = new(userId, userName, customerFirstName, customerLastName, customerEmail, customerState);

			model.SaveUsers(users);
			model.IsActionSuccess = true;
			model.ActionMessage = "New User has been added to the database.";

			return View(model);
		}

		public IActionResult Update(int id)
		{
			UsersViewModel model = new UsersViewModel(_Context, id);
			return View(model);
		}

		public IActionResult Delete(int id)
		{
			UsersViewModel model = new UsersViewModel(_Context);

			if (id > 0)
			{
				model.RemoveUsers(id);
			}

			model.IsActionSuccess = true;
			model.ActionMessage = "The user has been successfully removed from the database.";
			return View("Index", model);
		}
	}
}
