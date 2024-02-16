using DemoBAL.interfaces;
using DemoDAL;
using DemoDAL.Interfaces;
using DemoDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBAL
{
    public class DemoAPIBAL : IDemoAPIBAL
    {
        private readonly IDemoAPIDAL _demoAPIDAL;


        public DemoAPIBAL(IDemoAPIDAL demoAPIDAL)
        {
            _demoAPIDAL = demoAPIDAL;
        }

        async Task<bool> IDemoAPIBAL.CreateUser(UserModel userModel)
        {
            try {
                return await _demoAPIDAL.CreateUser(userModel);
            
            }catch(Exception e) {
                return false;
            }    
        }

        async Task<List<UserModel>> IDemoAPIBAL.GetAllUsers()
        {
            try { 
                return await _demoAPIDAL.GetAllUsers();
            
            }catch(Exception ex) {
                return new List<UserModel>();
            }
        }
    }
}
