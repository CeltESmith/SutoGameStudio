using CRUDApps.DataAccess.EF.Repositories;
using CRUDApps.DataAccess.EF.SutoStudio.Models;
using CRUDApps.DataAccess.EF.SutoStudio.Context;

namespace MVCSutoGameStudio.App.Models
{
	public class MmoslashersViewModel
	{
		private readonly MmoslashersRepository _repo;

		public List<Mmoslashers> MmoslashersList { get; set; }
		public Mmoslashers CurrentMmoslashers { get; set; }
		public bool IsActionSuccess { get; set; }
		public string ActionMessage { get; set; }

		public MmoslashersViewModel(SutoGameStudioContext context)
		{
			_repo = new MmoslashersRepository(context);
			MmoslashersList = GetAllMmoslashers();
			CurrentMmoslashers = MmoslashersList.FirstOrDefault()!;
		}

		public MmoslashersViewModel(SutoGameStudioContext context, int mmoslasherId)
		{
			_repo = new MmoslashersRepository(context);
			MmoslashersList = GetAllMmoslashers();

			if (mmoslasherId > 0 )
			{
				CurrentMmoslashers = GetMmoslashersByID(mmoslasherId);
			}
			else
			{
				CurrentMmoslashers = new Mmoslashers();
			}
		}

		public void SaveMmoslashers(Mmoslashers mmoslashers)
		{
			if (mmoslashers.MmoslasherId > 0)
			{
				_repo.update(mmoslashers);
			}
			else
			{
				mmoslashers.MmoslasherId = _repo.Create(mmoslashers);
			}

			MmoslashersList = GetAllMmoslashers();
			CurrentMmoslashers = GetMmoslashersByID(mmoslashers.MmoslasherId);
		}

		public void RemoveMmoslashers(int mmoslasherId)
		{
			_repo.Delete(mmoslasherId);
			MmoslashersList = GetAllMmoslashers();
			CurrentMmoslashers = MmoslashersList.FirstOrDefault()!;
		}

		public List<Mmoslashers> GetAllMmoslashers()
		{
			return _repo.GetAllMmoslashers();
		}

		public Mmoslashers GetMmoslashersByID(int mmoslasherID)
		{
			return _repo.GetMmoslashersByID(mmoslasherID);
		}
	}
}
