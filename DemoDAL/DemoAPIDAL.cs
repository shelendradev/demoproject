using DemoDAL.DBContext;
using DemoDAL.Interfaces;
using DemoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDAL
{
    public class DemoAPIDAL : IDemoAPIDAL
    {
        private readonly DefaultDbContext _dbContext;

        public DemoAPIDAL(DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<bool> IDemoAPIDAL.CreateUser(UserModel userModel)
        {
            try
            {
                await _dbContext.UserModels.AddAsync(userModel);
                
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        async Task<List<UserModel>> IDemoAPIDAL.GetAllUsers()
        {
            try
            {
                List<UserModel> users = _dbContext.UserModels.Select(x => x).ToList();
                return users;
            }
            catch (Exception ex)
            {
                return new List<UserModel>();
            }
        }
    }
}
