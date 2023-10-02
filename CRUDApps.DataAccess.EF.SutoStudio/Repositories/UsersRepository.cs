using CRUDApps.DataAccess.EF.Context;
using CRUDApps.DataAccess.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApps.DataAccess.EF.Repositories
{
	public class UsersRepository
	{
		private readonly SutoGameStudioContext _dbContext;

		public UsersRepository(SutoGameStudioContext dbContext)
		{
			_dbContext = dbContext;
		}

		public int Create(Users users)
		{
			_dbContext.Add(users);
			_dbContext.SaveChanges();
			return users.UserId;
		}

		public int Update(Users users)
		{
			Users existingUser = _dbContext.Users.Find(users.UserId);

			existingUser.UserName = users.UserName;
			existingUser.CustomerFirstName = users.CustomerFirstName;
			existingUser.CustomerLastName = users.CustomerLastName;
			existingUser.CustomerEmail = users.CustomerEmail;
			existingUser.CustomerState = users.CustomerState;
			existingUser.UserNameNavigation = users.UserNameNavigation;

			_dbContext.SaveChanges();
			return users.UserId;
		}

		public bool Delete(int userId)
		{
			Users user = _dbContext.Users.Find(userId);
			_dbContext.Remove(user);
			_dbContext.SaveChanges();
			return true;
		}

		public List<Users> GetAllUsers()
		{
			List<Users> usersList = _dbContext.Users.ToList();
			return usersList;
		}

		public Users GetUsersByID(int usersId)
		{
			Users currentUser = _dbContext.Users.Find(usersId);
			return currentUser;
		}
	}
}
