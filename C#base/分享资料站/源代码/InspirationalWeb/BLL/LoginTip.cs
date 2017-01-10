using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InspirationalWeb.BLL
{
    public enum LoginResult
    {
        UserNotExists,//用户名不存在
        ErrorPassword,//密码错误
        OK//登录成功！
    }
}