using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class ShowManagersMessagesDAL
    {
        public List<Managers> ShowManagers(string kindbelong)
        {
            string sql = null;
            SqlParameter[] sp = null;
            List<Managers> list = new List<Managers>();
            if (kindbelong == null || (kindbelong == "All"))
            {
                sql = "select * from T_Managers order by ID";
            }
            else
            {
                sql = "select * from T_Managers where belong=@belong order by ID";
                sp = new SqlParameter[]{
                    new SqlParameter("@belong",kindbelong)
                };
            }
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Managers m = new Managers()
                    {
                        ID = Convert.ToInt32(rows["ID"]),
                        IsDelete = Convert.ToBoolean(rows["IsDelete"]),
                        CreateTime = Convert.ToDateTime(rows["CreateTime"]),
                        UserName = Convert.ToString(rows["UserName"]),
                        UserPassWord = Convert.ToString(rows["UserPassWord"]),
                        UserSex = Convert.ToString(rows["UserSex"] == DBNull.Value ? null : rows["UserSex"]),
                        UserQQ = Convert.ToInt32(rows["UserQQ"] == DBNull.Value ? 0 : rows["UserQQ"]),
                        UserPhone = Convert.ToInt32(rows["UserPhone"] == DBNull.Value ? null : rows["UserPhone"]),
                        UserStuID = Convert.ToInt32(rows["UserStuID"]),
                        UserFname = Convert.ToString(rows["UserFname"] == DBNull.Value ? null : rows["UserFname"]),
                        UserIP = Convert.ToString(rows["UserIP"] == DBNull.Value ? null : rows["UserIP"]),
                        belong = Convert.ToString(rows["belong"] == DBNull.Value ? null : rows["belong"])
                    };
                    list.Add(m);
                }
            }
            return list;
        }






        public int selectQuan(string name,string pwd)
        {
            string sql = "select count(*) from T_Managers where UserName=@name and UserPassWord=@pwd";
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@name",name),
                new SqlParameter("@pwd",pwd)
            };
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql,CommandType.Text,sp));

        }
        public List<Managers> selectM()
        {
            List<Managers> list = new List<Managers>();
            using(DataTable dt=SqlHelper.ExecuteDataTable("select * from T_Managers",CommandType.Text))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Managers m = new Managers();
                    m.ID = Convert.ToInt32(rows["ID"]);
                    m.IsDelete = Convert.ToBoolean(rows["IsDelete"]);
                    m.CreateTime = Convert.ToDateTime(rows["CreateTime"]);
                    m.UserName = Convert.ToString(rows["UserName"]);
                    m.UserPassWord = Convert.ToString(rows["UserPassWord"]);
                    m.UserSex = Convert.ToString(rows["UserSex"] == DBNull.Value ? null : rows["UserSex"]);
                    m.UserQQ = Convert.ToInt32(rows["UserQQ"] == DBNull.Value ? 0 : rows["UserQQ"]);
                    m.UserPhone = Convert.ToInt32(rows["UserPhone"] == DBNull.Value ? null : rows["UserPhone"]);
                    m.UserStuID = Convert.ToInt64(rows["UserStuID"]);
                    m.UserFname = Convert.ToString(rows["UserFname"] == DBNull.Value ? null : rows["UserFname"]);
                    m.UserIP = Convert.ToString(rows["UserIP"] == DBNull.Value ? null : rows["UserIP"]);
                    m.belong = Convert.ToString(rows["belong"] == DBNull.Value ? null : rows["belong"]);
                    list.Add(m);
                }
            }
            return list;
        }                                                      //所有manager
        public List<SuperManagers> selectSM()                                   
        {
            List<SuperManagers> list = new List<SuperManagers>();
            using(DataTable dt=SqlHelper.ExecuteDataTable("select * from T_SuperManagers",CommandType.Text))
            {
                foreach (DataRow row in dt.Rows)
                {
                    SuperManagers sm = new SuperManagers();
                    sm.ID = Convert.ToInt32(row["ID"]);
                    sm.CreateTime = Convert.ToDateTime(row["CreateTime"]);
                    sm.UserName = Convert.ToString(row["UserName"]);
                    sm.UserPassWord = Convert.ToString(row["UserPassWord"]);
                    sm.UserSex = row["UserSex"] == DBNull.Value ? "" : Convert.ToString(row["UserSex"]);
                    sm.UserQQ = row["UserQQ"] == DBNull.Value ? 0 : Convert.ToInt64(row["UserQQ"]);
                    sm.UserPhone = row["UserPhone"] == DBNull.Value ? 0 : Convert.ToInt64(row["UserPhone"]);
                    sm.UserStuID = Convert.ToInt64(row["UserStuID"]);
                    sm.UserFname = row["UserFname"] == DBNull.Value ? "" : Convert.ToString(row["UserFname"]);
                    sm.UserIP=row["UserIP"]==DBNull.Value?"":Convert.ToString(row["UserIP"]);
                    list.Add(sm);
                }
            }
            return list;
        }             //所有supermanager







        public List<Managers> showManagersByID(int id)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select * from T_Managers where ID=@id order by ID";
            SqlParameter sp = new SqlParameter("@id",id);
            list = zong(sql,sp,list);
            return list;
        }                                 //  by  id

        public List<Managers> showManagersByIsDelete(string isdelete)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select *,IIF(IsDelete='false','false','true') as result from T_Managers where IIF(IsDelete='false','false','true') like @isdelete order by ID";
            SqlParameter sp = new SqlParameter("@isdelete",isdelete);
            list = zong(sql, sp, list);
            return list;
        }                  //  by  isdelete

        public List<Managers> showManagersByCreattime(string dt)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select * from T_Managers where convert(varchar,CreateTime,120) like @dt order by ID";
            SqlParameter sp = new SqlParameter("@dt",dt);
            list = zong(sql, sp, list);
            return list;
        }                       //  by  createtime

        public List<Managers> showManagersByUserName(string username)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select * from T_Managers where UserName like @username order by ID";
            SqlParameter sp = new SqlParameter("@username",username);
            list = zong(sql, sp, list);

            return list;
        }                  //  by name

        public List<Managers> showManagersByUserPassWord(string pwd)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select * from T_Managers where UserPassWord like @pwd order by ID";
            SqlParameter sp = new SqlParameter("@pwd",pwd);
            list = zong(sql, sp, list);

            return list;
        }                   //  by pwd

        public List<Managers> showManagersByUserSex(string usersex)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select * from T_Managers where UserSex like @usersex order by ID";
            SqlParameter sp = new SqlParameter("@usersex",usersex);
            list = zong(sql, sp, list);
            return list;
        }                    // by sex

        public List<Managers> showManagersByUserQQ(string userqq)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select *,cast(UserQQ as varchar(20)) from T_Managers where cast(UserQQ as varchar) like @userqq";
            SqlParameter sp = new SqlParameter("@userqq",userqq);
            list = zong(sql, sp, list);

            return list;
        }                      // by userqq

        public List<Managers> showManagersByUserPhone(string userphone)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select *,cast(UserPhone as varchar(20)) from T_Managers where cast(UserPhone as varchar) like @userphone";
            SqlParameter sp = new SqlParameter("@userphone",userphone);
            list = zong(sql, sp, list);

            return list;
        }                // by phone

        public List<Managers> showManagersByUserStuID(string userstuid)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select *,cast(UserStuID as varchar(20)) from T_Managers where cast(UserStuID as varchar) like @userstuid";
            SqlParameter sp = new SqlParameter("@userstuid",userstuid);
            list = zong(sql, sp, list);

            return list;
        }                // by stuid

        public List<Managers> showManagersByUserFname(string userfname)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select * from T_Managers where UserFname like @userfname order by ID";
            SqlParameter sp = new SqlParameter("@userfname",userfname);
            list = zong(sql, sp, list);
            return list;
        }                // by username

        public List<Managers> showManagersByUserIP(string userip)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select * from T_Managers where UserIP like @userip order by ID";
            SqlParameter sp = new SqlParameter("@userip",userip);
            list = zong(sql, sp, list);
            return list;
        }                      // by userip

        public List<Managers> showManagersBybelong(string belong)
        {
            List<Managers> list = new List<Managers>();
            string sql = "select * from T_Managers where belong like @belong order by ID";
            SqlParameter sp = new SqlParameter("@belong",belong);
            list = zong(sql, sp, list);
            return list;
        }                      // by belong






        public List<Managers> zong(string sql,SqlParameter sp,List<Managers> list)             //公共部分
        {
            using(DataTable dt=SqlHelper.ExecuteDataTable(sql,CommandType.Text,sp))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Managers m = new Managers();
                    m.ID = Convert.ToInt32(rows["ID"]);
                    m.IsDelete = Convert.ToBoolean(rows["IsDelete"]);
                    m.CreateTime = Convert.ToDateTime(rows["CreateTime"]);
                    m.UserName = Convert.ToString(rows["UserName"]);
                    m.UserPassWord = Convert.ToString(rows["UserPassWord"]);
                    m.UserSex = Convert.ToString(rows["UserSex"] == DBNull.Value ? null : rows["UserSex"]);
                    m.UserQQ = Convert.ToInt32(rows["UserQQ"] == DBNull.Value ? 0 : rows["UserQQ"]);
                    m.UserPhone = Convert.ToInt32(rows["UserPhone"] == DBNull.Value ? null : rows["UserPhone"]);
                    m.UserStuID = Convert.ToInt64(rows["UserStuID"]);
                    m.UserFname = Convert.ToString(rows["UserFname"] == DBNull.Value ? null : rows["UserFname"]);
                    m.UserIP = Convert.ToString(rows["UserIP"] == DBNull.Value ? null : rows["UserIP"]);
                    m.belong = Convert.ToString(rows["belong"] == DBNull.Value ? null : rows["belong"]);
                    list.Add(m);
                }
            }
            return list;
        }

        public int selectsm(string name)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar("select count(*) from T_SuperManagers where UserName='"+name+"'",CommandType.Text));
        }
    }
}