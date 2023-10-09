using CRUDApps.DataAccess.EF.SutoStudio.Context;
using CRUDApps.DataAccess.EF.Repositories;
using CRUDApps.DataAccess.EF.SutoStudio.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCSutoGameStudio.App.Models
{
	public class FpsblastsViewModel
	{
		private FpsblastsRepository _repo;

		public List<Fpsblasts> FpsblastsList { get; set; }
		public Fpsblasts CurrentFpsblasts { get; set; }
		public bool IsActionSuccess { get; set; }
		public string ActionMessage { get; set; }

		public FpsblastsViewModel(SutoGameStudioContext context)
		{
			_repo = new FpsblastsRepository(context);
			FpsblastsList = GetAllFpsblasts();
			CurrentFpsblasts = FpsblastsList.FirstOrDefault()!;
		}

		public FpsblastsViewModel(SutoGameStudioContext context, int fpsblastsId)
		{
			_repo = new FpsblastsRepository(context);
			FpsblastsList = GetAllFpsblasts();

			if (fpsblastsId > 0)
			{
				CurrentFpsblasts = GetFpsblastsByID(fpsblastsId);
			}
			else
			{
				CurrentFpsblasts = new Fpsblasts();
			}
		}

		public void SaveFpsblasts(Fpsblasts fpsblasts)
		{
			if (fpsblasts.FpsblastId > 0)
			{
				_repo.Update(fpsblasts);
			}
			else
			{
				fpsblasts.FpsblastId = _repo.Create(fpsblasts);
			}

			FpsblastsList = GetAllFpsblasts();
			CurrentFpsblasts = GetFpsblastsByID(fpsblasts.FpsblastId);
		}

		public void RemoveFpsblasts(int fpsblastsId)
		{
			_repo.Delete(fpsblastsId);
			FpsblastsList = GetAllFpsblasts();
			CurrentFpsblasts = FpsblastsList.FirstOrDefault()!;
		}

		public List<Fpsblasts> GetAllFpsblasts()
		{
			return _repo.GetAllFpsblasts();
		}

		public Fpsblasts GetFpsblastsByID(int fpsblastId)
		{
			return _repo.GetFpsblastsByID(fpsblastId);
		}
	}
}
