using CRUDApps.DataAccess.EF.Context;
using CRUDApps.DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApps.DataAccess.EF.Repositories
{
	public class FpsblastsRepository
	{
		private readonly SutoGameStudioContext _dbContext;

		public FpsblastsRepository(SutoGameStudioContext dbContext)
		{
			_dbContext = dbContext;
		}

		public int Create(Fpsblasts fpsblasts)
		{
			_dbContext.Add(fpsblasts);
			_dbContext.SaveChanges();

			return fpsblasts.FpsblastId;
		}

		public int Update(Fpsblasts fpsblasts)
		{
			Fpsblasts existingfpsblasts = _dbContext.Fpsblasts.Find(fpsblasts.FpsblastId);

			existingfpsblasts.UserName = fpsblasts.UserName;
			existingfpsblasts.TimePlayed = fpsblasts.TimePlayed;
			existingfpsblasts.Expansion1 = fpsblasts.Expansion1;
			existingfpsblasts.OwnFpsblastGame = fpsblasts.OwnFpsblastGame;

			_dbContext.SaveChanges();
			return existingfpsblasts.FpsblastId;
		}

		public bool Delete(int fpsblastsID)
		{
			Fpsblasts fpsblasts = _dbContext.Fpsblasts.Find(fpsblastsID);
			_dbContext.Remove(fpsblasts);
			_dbContext.SaveChanges();

			return true;
		}

		public List<Fpsblasts> GetAllFpsblasts()
		{
			List<Fpsblasts> fpsblastsList = _dbContext.Fpsblasts.ToList();
			_dbContext.SaveChanges();

			return fpsblastsList;
		}

		public Fpsblasts GetFpsblastsByID(int fpsblastID)
		{
			Fpsblasts fpsblast = _dbContext.Fpsblasts.Find(fpsblastID);
			return fpsblast;
		}
	}
}
