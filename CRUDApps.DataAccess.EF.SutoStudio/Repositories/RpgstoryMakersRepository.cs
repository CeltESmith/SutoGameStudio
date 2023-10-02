using CRUDApps.DataAccess.EF.Context;
using CRUDApps.DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApps.DataAccess.EF.Repositories
{
	public class RpgstoryMakersRepository
	{
		private readonly SutoGameStudioContext _dbContext;

		public RpgstoryMakersRepository(SutoGameStudioContext context)
		{
			_dbContext = context;
		}

		public int Create(RpgstoryMakers rpgstoryMakers)
		{
			_dbContext.Add(rpgstoryMakers);
			_dbContext.SaveChanges();
			return rpgstoryMakers.RpgstoryMakerId;
		}

		public int Update(RpgstoryMakers rpgstoryMakers)
		{
			RpgstoryMakers existingRpgstoryMakers = _dbContext.RpgstoryMakers.Find(rpgstoryMakers.RpgstoryMakerId);

			existingRpgstoryMakers.UserName = rpgstoryMakers.UserName;
			existingRpgstoryMakers.TimePlayed = rpgstoryMakers.TimePlayed;
			existingRpgstoryMakers.GameCompleted = rpgstoryMakers.GameCompleted;
			existingRpgstoryMakers.OwnRpgstoryMakerGame = rpgstoryMakers.OwnRpgstoryMakerGame;
			existingRpgstoryMakers.LoyaltyCharts = rpgstoryMakers.LoyaltyCharts;

			_dbContext.SaveChanges();
			return existingRpgstoryMakers.RpgstoryMakerId;
		}

		public bool Delete(int rpgstoryMakerID)
		{
			RpgstoryMakers rpgstoryMakers = _dbContext.RpgstoryMakers.Find(rpgstoryMakerID);
			_dbContext.Remove(rpgstoryMakers);
			_dbContext.SaveChanges();

			return true;
		}

		public List<RpgstoryMakers> GetAllRpgstoryMakers()
		{
			List<RpgstoryMakers> RpgstoryMakersList = _dbContext.RpgstoryMakers.ToList();
			return RpgstoryMakersList;
		}

		public RpgstoryMakers GetRpgstoryMakersByID(int rpgstoryMakerID)
		{
			RpgstoryMakers rpgstoryMakers = _dbContext.RpgstoryMakers.Find(rpgstoryMakerID);
			return rpgstoryMakers;
		}
	}
}
