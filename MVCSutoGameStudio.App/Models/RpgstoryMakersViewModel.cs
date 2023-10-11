using CRUDApps.DataAccess.EF.Repositories;
using CRUDApps.DataAccess.EF.SutoStudio.Models;
using CRUDApps.DataAccess.EF.SutoStudio.Context;

namespace MVCSutoGameStudio.App.Models
{
	public class RpgstoryMakersViewModel
	{
		private RpgstoryMakersRepository _repo;

		public List<RpgstoryMakers> RpgstoryMakersList { get; set; }
		public RpgstoryMakers CurrentRpgstoryMakers { get; set; }
		public bool IsActionSuccess { get; set; }
		public string ActionMessage { get; set; }

		public RpgstoryMakersViewModel(SutoGameStudioContext context)
		{
			_repo = new RpgstoryMakersRepository(context);
			RpgstoryMakersList = GetAllRpgstoryMakers();
			CurrentRpgstoryMakers = RpgstoryMakersList.FirstOrDefault()!;
		}

		public RpgstoryMakersViewModel(SutoGameStudioContext context, int rpgstoryMakerId)
		{
			_repo = new RpgstoryMakersRepository(context);
			RpgstoryMakersList = GetAllRpgstoryMakers();

			if (rpgstoryMakerId > 0)
			{
				CurrentRpgstoryMakers = GetRpgstoryMakersByID(rpgstoryMakerId);
			}
			else
			{
				CurrentRpgstoryMakers = new RpgstoryMakers();
			}
		}

		public void SaveRpgstoryMakers(RpgstoryMakers rpgstoryMakers)
		{
			if (rpgstoryMakers.RpgstoryMakerId > 0)
			{
				_repo.Update(rpgstoryMakers);
			}
			else
			{
				rpgstoryMakers.RpgstoryMakerId = _repo.Create(rpgstoryMakers);
			}

			RpgstoryMakersList = GetAllRpgstoryMakers();
			CurrentRpgstoryMakers = GetRpgstoryMakersByID(rpgstoryMakers.RpgstoryMakerId);
		}

		public void RemoveRpgstoryMakers(int rpgstoryMakerId)
		{
			_repo.Delete(rpgstoryMakerId);
			RpgstoryMakersList = GetAllRpgstoryMakers();
			CurrentRpgstoryMakers = RpgstoryMakersList.FirstOrDefault()!;
		}

		public List<RpgstoryMakers> GetAllRpgstoryMakers()
		{
			return _repo.GetAllRpgstoryMakers();
		}

		public RpgstoryMakers GetRpgstoryMakersByID(int rpgstoryMakerID)
		{
			return _repo.GetRpgstoryMakersByID(rpgstoryMakerID);
		}
	}
}
