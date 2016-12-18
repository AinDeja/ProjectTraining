using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using LiZhiOSManagement.Model;

namespace LiZhiOSManagement.DAL
{
    public class T_User
    {
          /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Login(string loginId, string password)
        {
            string sql = "select count(*) from T_User where UserName=@uid and UserPassWord=@pwd";
            SqlParameter[] pms = new SqlParameter[] { 
            new SqlParameter("@uid",System.Data.SqlDbType.NVarChar,50){ Value=loginId},
            new SqlParameter("@pwd",System.Data.SqlDbType.VarChar,50){ Value=password}
            };
            return (int)Sql.ExecuteScalar(sql, System.Data.CommandType.Text, pms);
        
        }
        /// <summary>
        /// 查找所有用户
        /// </summary>
        /// <returns></returns>
        public DataTable allId() {
            string sql = "select*from T_User order by belong";
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return view;
        }

        /// <summary>
        /// 根据用户名查IP
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string IpByUserNameSearch(string uid)
        {
            string sql = "select*from T_User where UserName=@uid";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@uid", System.Data.SqlDbType.NVarChar) { Value = uid } };
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);
            DataRow name = view.Rows[0];
            string userIP = Convert.ToString(name["UserIP"]);
            return userIP;
        }


        /// <summary>
        /// 根据用户名查当前用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataRow userStuIDByUserNameSearch(string uid)
        {
            string sql = "select*from T_User where UserName=@uid";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@uid", System.Data.SqlDbType.NVarChar) { Value = uid } };
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);
            DataRow name = view.Rows[0];
            //string userStuID = Convert.ToString(name["UserStuID"]);
            return name;
        }
        
        /// <summary>
        /// 根据用户名查询当前用户的基本信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        /// 
        public Seat GetModelByLoginId(string loginId)
        {
            Seat model = null;
            string sql = "select UserPassword,UserName from T_User where UserName=@loginId";
            using (SqlDataReader reader = Sql.ExecuteReader(sql, System.Data.CommandType.Text, new SqlParameter("@loginId", System.Data.SqlDbType.NVarChar, 50) { Value = loginId }))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        model = new Seat();
                        model.UserPassword = reader.GetString(0);
                        model.UserName = reader.GetString(1);

                    }
                }
            }
            return model;
        }
        /*
        /// <summary>
        /// 用户个人资料查询
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public Seat UserMessSelect(string loginId)
        {
            string a = loginId;
            Seat model = null;
            string sql = "select * from T_User where UserName=@loginId";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@loginId", System.Data.SqlDbType.NVarChar, 50) { Value = loginId } };
            DataTable reader = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);

            DataRow mess = reader.Rows[0];
            model = new Seat();
            model.UserPassword = mess["UserPassWord"].ToString();
            model.UserName = mess["UserName"].ToString();
            model.UserSex = (bool)mess["UserSex"];
            model.UserAge = (int)mess["UserAge"];
            model.UserBirth = (DateTime)mess["UserBirth"];
            model.UserQQ = (Int64)mess["UserQQ"];
            model.UserPhone = (Int64)mess["UserPhone"];
            model.UserEmail = mess["UserEmail"].ToString();
            model.UserFname = mess["UserFname"].ToString();
            model.UserID = Convert.ToInt32(mess["ID"]);
            return model;
        }
        /// <summary>
        /// 用户个人资料更新
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="sex"></param>
        /// <param name="Fname"></param>
        /// <param name="email"></param>
        /// <param name="age"></param>
        /// <param name="qq"></param>
        /// <param name="phone"></param>
        /// <param name="birth"></param>
        public void UserUpData(string username, string password, string sex, string Fname, string email, int age, Int64 qq, Int64 phone, DateTime birth)
        {
            bool gender;
            if (sex == "男") gender = true; else gender = false;
            string sql = "update T_User set UserPassWord=@pwd,UserSex=@sex,UserFname=@fn,UserEmail=@em,UserAge=@age,UserQQ=@qq,UserPhone=@ph,UserBirth=@br where UserName=@uid";
            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@uid",System.Data.SqlDbType.VarChar,50){ Value=username},
            new SqlParameter("@pwd",System.Data.SqlDbType.VarChar,50){ Value=password},
            new SqlParameter("@sex",System.Data.SqlDbType.Bit,50){ Value=gender},
            new SqlParameter("@fn",System.Data.SqlDbType.NVarChar,50){ Value=Fname},
            new SqlParameter("@em",System.Data.SqlDbType.NVarChar,50){ Value=email},
            new SqlParameter("@age",System.Data.SqlDbType.Int,50){ Value=age},
            new SqlParameter("@qq",System.Data.SqlDbType.BigInt,50){ Value=qq},
            new SqlParameter("@ph",System.Data.SqlDbType.BigInt,50){ Value=phone},
            new SqlParameter("@br",System.Data.SqlDbType.Date,50){ Value=birth}
            };

            DataTable reader = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);
        }
        /// <summary>
        /// 根据ID查找用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string UserNameSearchByID(int id)
        {
            string sql = "select*from T_User where ID=@id",userName;
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@id", System.Data.SqlDbType.Int, 50) { Value = id } };
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);
            DataRow name = view.Rows[0];
            userName=name["UserName"].ToString();
            return userName;
        }
        /// <summary>
        /// 根据用户名查ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int IDByUserNameSearch(string uid)
        {
            string sql = "select*from T_User where UserName=@uid";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@uid", System.Data.SqlDbType.NVarChar) { Value = uid } };
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);
            DataRow name = view.Rows[0];
            int userid =Convert.ToInt32( name["ID"]);
            return userid;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPassWord"></param>
        /// <returns></returns>
        public int SetUser(string UserName, string UserPassWord)
        {
            string su = "Insert into T_User(UserName,UserPassword) values(@UserName,@UserPassWord)";
            SqlParameter[] set = new SqlParameter[]{
                new SqlParameter("@UserName",System.Data.SqlDbType.NVarChar){Value=UserName},
                 new SqlParameter("@UserPassWord",System.Data.SqlDbType.NVarChar){Value=UserPassWord},
            };

            return Sql.ExecuteNonQuery(su, System.Data.CommandType.Text, set);
        }
        /// <summary>
        /// 注册校验
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public int SetCheck(string UserName)
        {
            int check =0;
            string sql = "select * from T_User where UserName=@UserName";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@UserName", System.Data.SqlDbType.NVarChar) { Value = UserName } };
            DataTable pList = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);
             DataRow user;
             if (pList.Rows.Count == 1)
             {
                 user = pList.Rows[0];
                 if (user["UserName"].ToString() != UserName)
                 check = 1;
             
               
             }
             else
             {
                     check = 1;
             }
            return check;
        }
        */
    }
}
    
