using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestForNet.DAL;
using TestForNet.Model;

namespace TestForNet.BLL
{
    public class B_User
    {
        public LoginResult Login1(string loginId, string password, out string username)
        {
            username = string.Empty;

            T_User dal = new T_User();
            Seat model = dal.GetModelByLoginId(loginId);
            //根据查询到的信息判断用户登录是否成功！
            if (model != null)
            {
                if (loginId == "")
                {
                    return LoginResult.UserNotExists;
                }
                if (password == model.UserPassword)
                {
                    username = model.UserName;
                    return LoginResult.OK;
                }
                else
                {
                    return LoginResult.ErrorPassword;
                }
            }
            else
            {
                return LoginResult.UserNotExists;
            }
        }
    }
}