using CRUDApps.DataAccess.EF.SutoStudio.Context;
using CRUDApps.DataAccess.EF.SutoStudio.Models;
using CRUDApps.DataAccess.EF.Repositories;

namespace MVCSutoGameStudio.App.Models
{
	public class UsersViewModel
	{
		private readonly UsersRepository _repo;

		public List<Users> UsersList { get; set; }
		public Users CurrentUsers { get; set; }
		public bool IsActionSuccess { get; set; }
		public string ActionMessage { get; set; }

		public UsersViewModel(SutoGameStudioContext context)
		{
			_repo = new UsersRepository(context);
			UsersList = GetAllUsers();
			CurrentUsers = UsersList.FirstOrDefault()!;
		}

		public UsersViewModel(SutoGameStudioContext context, int userId)
		{
			_repo = new UsersRepository(context);

			if (userId > 0 )
			{
				CurrentUsers = GetUsersByID(userId);
			}
			else
			{
				CurrentUsers = new Users();
			}
		}

		public void SaveUsers(Users users)
		{
			if (users.UserId > 0 )
			{
				_repo.Update(users);
			}
			else
			{
				users.UserId = _repo.Create(users);
			}

			UsersList = GetAllUsers();
			CurrentUsers = GetUsersByID(users.UserId);
		}

		public void RemoveUsers(int userId)
		{
			_repo.Delete(userId);
			UsersList = GetAllUsers();
			CurrentUsers = UsersList.FirstOrDefault()!;
		}

		public List<Users> GetAllUsers()
		{
			return _repo.GetAllUsers();
		}

		public Users GetUsersByID(int userID)
		{
			return _repo.GetUsersByID(userID);
		}
	}
}
