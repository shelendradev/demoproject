using DemoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBAL.interfaces
{
    public interface IDemoAPIBAL
    {
        public Task<List<UserModel>> GetAllUsers();

        public Task<bool> CreateUser(UserModel userModel);
    }
}
