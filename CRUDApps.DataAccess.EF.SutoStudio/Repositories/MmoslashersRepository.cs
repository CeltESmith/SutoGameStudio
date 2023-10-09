using CRUDApps.DataAccess.EF.SutoStudio.Context;
using CRUDApps.DataAccess.EF.SutoStudio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApps.DataAccess.EF.Repositories
{
	public class MmoslashersRepository
	{
		private readonly SutoGameStudioContext _dbContext;

		public MmoslashersRepository(SutoGameStudioContext context)
		{
			_dbContext = context;
		}

		public int Create(Mmoslashers mmoslashers)
		{
			_dbContext.Add(mmoslashers);
			_dbContext.SaveChanges();
			return mmoslashers.MmoslasherId;
		}

		public int update(Mmoslashers mmoslashers)
		{
			Mmoslashers existingMmoslasher = _dbContext.Mmoslashers.Find(mmoslashers.MmoslasherId);

			existingMmoslasher.TimePlayed = mmoslashers.TimePlayed;
			existingMmoslasher.Expansion1 = mmoslashers.Expansion1;
			existingMmoslasher.ActiveLast30Days = mmoslashers.ActiveLast30Days;
			existingMmoslasher.OwnMmoslasherGame = mmoslashers.OwnMmoslasherGame;

			_dbContext.SaveChanges();

			return existingMmoslasher.MmoslasherId;
		}

		public bool Delete(int mmoslasherId)
		{
			Mmoslashers mmoslasher = _dbContext.Mmoslashers.Find(mmoslasherId);
			_dbContext.Remove(mmoslasher);
			_dbContext.SaveChanges();

			return true;
		}

		public List<Mmoslashers> GetAllMmoslashers()
		{
			List<Mmoslashers> MmoslashersList = _dbContext.Mmoslashers.ToList();
			return MmoslashersList;
		}

		public Mmoslashers GetMmoslashersByID(int mmoslasherID)
		{
			Mmoslashers mmoslashers = _dbContext.Mmoslashers.Find(mmoslasherID);
			return mmoslashers;
		}
	}
}
