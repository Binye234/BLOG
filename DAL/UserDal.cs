using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace DAL
{
    public class UserDal
    {
        private BLOGEntities bLOG = new BLOGEntities();
        /// <summary>
        /// 验证登陆用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsUser(User user)
        {
            try
            {
                bool isUser = bLOG.Users.Where(p => p.UserName == user.UserName && p.PassWord == user.PassWord).SingleOrDefault() == null;
                if (isUser)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
