using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LiZhiOSManagement.DAL
{
    public class ShowUsersMessagesDAL
    {
        public List<Users> ShowUsers(string kindbelong)
        {
            string sql = null;
            SqlParameter[] sp = null;
            List<Users> list = new List<Users>();
            if(kindbelong==null||(kindbelong=="All"))
            {
                sql = "select * from T_User order by ID";
            }
            else
            {
                sql = "select * from T_User where Belong=@belong order by ID";
                sp = new SqlParameter[]{
                    new SqlParameter("@belong",kindbelong)
                };
            }
            using(DataTable dt=SqlHelper.ExecuteDataTable(sql,CommandType.Text,sp))
            {
                foreach(DataRow rows in dt.Rows)
                {
                    Users u = new Users()
                    {
                        ID=Convert.ToInt32(rows["ID"]),
                        IsDelete=Convert.ToBoolean(rows["IsDelete"]),
                        CreateTime=Convert.ToDateTime(rows["CreateTime"]),
                        UserName=Convert.ToString(rows["UserName"]),
                        UserPassWord=Convert.ToString(rows["UserPassWord"]),
                        UserSex = Convert.ToString(rows["UserSex"] == DBNull.Value ? null : rows["UserSex"]),
                        UserQQ = Convert.ToInt64(rows["UserQQ"] == DBNull.Value ? 0 : rows["UserQQ"]),
                        UserPhone = Convert.ToInt64(rows["UserPhone"] == DBNull.Value ? null : rows["UserPhone"]),
                        UserStuID = Convert.ToInt64(rows["UserStuID"]),
                        UserFname = Convert.ToString(rows["UserFname"] == DBNull.Value ? null : rows["UserFname"]),
                        UserIP = Convert.ToString(rows["UserIP"]),
                        Belong = Convert.ToString(rows["Belong"])
                    };
                    list.Add(u);
                }
            }
            return list;
        }



        public List<Users> ShowUsersById(int id)
        {
            List<Users> list = new List<Users>();
            string sql = "select * from T_User where ID=@id order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@id",id)
            };
            list = zong(sql, sp, list);
            return list;

        }                                                     //id

        public List<Users> ShowUsersByIsDelete(string isdelete)                                       //boolean模糊查询  IsDelete
        {
            List<Users> list = new List<Users>();
            string sql = "select *,IIF(IsDelete='false','false','true') as result from T_User where IIF(IsDelete='false','false','true') like @isdelete order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@isdelete",isdelete)
            };
            list = zong(sql, sp, list);
            return list;
        }

        public List<Users> ShowUsersByCreattime(string dt)
        {
            List<Users> list = new List<Users>();
            string sql = "select * from T_User where convert(varchar,CreateTime,120) like @dt order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                new SqlParameter("@dt",dt)
            };
            list = zong(sql, sp, list);
            return list;
        }

        public List<Users> ShowUsersByUserName(string username)
        {
            List<Users> list = new List<Users>();
            string sql = "select * from T_User where UserName like @username order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@username",username)
                };
            list = zong(sql, sp, list);

            return list;
        }                                    //username

        public List<Users> ShowUsersByUserPassWord(string pwd)                                          //userpassword
        {
            List<Users> list = new List<Users>();
            string sql = "select * from T_User where UserPassWord like @pwd order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@pwd",pwd)
                };
            list = zong(sql, sp, list);

            return list;
        }

        public List<Users> ShowUsersByUserSex(string usersex)                                          //usresex
        {
            List<Users> list = new List<Users>();
            string sql = "select * from T_User where UserSex like @usersex order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@usersex",usersex)
                };
            list = zong(sql, sp, list);

            return list;
        }

        public List<Users> ShowUsersByUserQQ(string userqq)                                          //usresex
        {
            List<Users> list = new List<Users>();
            string sql = "select *,cast(UserQQ as varchar(20)) from T_User where cast(UserQQ as varchar) like @userqq";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@userqq",userqq)
                };
            list = zong(sql, sp, list);

            return list;
        }

        public List<Users> ShowUsersByUserPhone(string userphone)                                          //userphone
        {
            List<Users> list = new List<Users>();
            string sql = "select *,cast(UserPhone as varchar(20)) from T_User where cast(UserPhone as varchar) like @userphone";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@userphone",userphone)
                };
            list = zong(sql, sp, list);

            return list;
        }
        public List<Users> ShowUsersByUserStuID(string userstuid)                                          //UserStuID
        {
            List<Users> list = new List<Users>();
            string sql = "select *,cast(UserStuID as varchar(20)) from T_User where cast(UserStuID as varchar) like @userstuid";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@userstuid",userstuid)
                };
            list = zong(sql, sp, list);

            return list;
        }
        public List<Users> ShowUsersByUserFname(string userfname)
        {
            List<Users> list = new List<Users>();
            string sql = "select * from T_User where UserFname like @userfname order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@userfname",userfname)
                };
            list = zong(sql, sp, list);

            return list;
        }                                    //username
        public List<Users> ShowUsersByUserIP(string userip)
        {
            List<Users> list = new List<Users>();
            string sql = "select * from T_User where UserIP like @userip order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@userip",userip)
                };
            list = zong(sql, sp, list);

            return list;
        }                                    //userip

        public List<Users> ShowUsersBybelong(string belong)
        {
            List<Users> list = new List<Users>();
            string sql = "select * from T_User where Belong like @belong order by ID";
            SqlParameter[] sp = new SqlParameter[]{
                    new SqlParameter("@belong",belong)
                };
            list = zong(sql, sp, list);

            return list;
        }                                            //belong





        public string selectUserName(int id)             //查找用户名
        {
            string sql = "select UserName from T_User where ID=@id";
            SqlParameter sp = new SqlParameter("@id",id);
            string username = SqlHelper.ExecuteScalar(sql, CommandType.Text, sp).ToString();
            return username;
        }
        public string selectGroup(string belonggrouptype)
        {
            string sql = "select BelongGroup from T_ArticleGroup,T_ArticleGroupType where T_ArticleGroup.ID in (select IDCount from T_ArticleGroup where BelongType=@belongtype)";
            SqlParameter sp = new SqlParameter("@belongtype", belonggrouptype);
            string sgroup = SqlHelper.ExecuteScalar(sql, CommandType.Text, sp).ToString();
            return sgroup;
        }

        public int selectUseridbyname(string name)
        {
            string sql = "select ID from T_Managers where UserName=@name";
            SqlParameter sp = new SqlParameter("@name",name);
            return Convert.ToInt32(SqlHelper.ExecuteScalar(sql,CommandType.Text,sp));
        }

        public List<Users> selectAllUsers()
        {
            List<Users> list = new List<Users>();
            using(DataTable dt=SqlHelper.ExecuteDataTable("select * from T_User",CommandType.Text))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Users u = new Users();
                    u.ID=Convert.ToInt32(rows["ID"]);
                    u.IsDelete=Convert.ToBoolean(rows["IsDelete"]);
                    u.CreateTime=Convert.ToDateTime(rows["CreateTime"]);
                    u.UserName=Convert.ToString(rows["UserName"]);
                    u.UserPassWord=Convert.ToString(rows["UserPassWord"]);
                    u.UserSex = Convert.ToString(rows["UserSex"] == DBNull.Value ? null : rows["UserSex"]);
                    u.UserQQ = Convert.ToInt64(rows["UserQQ"] == DBNull.Value ? 0 : rows["UserQQ"]);
                    u.UserPhone = Convert.ToInt64(rows["UserPhone"] == DBNull.Value ? null : rows["UserPhone"]);
                    u.UserStuID = Convert.ToInt64(rows["UserStuID"]);
                    u.UserFname = Convert.ToString(rows["UserFname"] == DBNull.Value ? null : rows["UserFname"]);
                    u.UserIP = Convert.ToString(rows["UserIP"]);
                    u.Belong = Convert.ToString(rows["Belong"]);
                    list.Add(u);
                }
            }
            return list;
        }

        public string selectGroupbyName(string name)
        {
            string sql = "select Belong from T_User where UserName=@name";
            SqlParameter sp = new SqlParameter("@name",name);
            return SqlHelper.ExecuteScalar(sql,CommandType.Text,sp).ToString();
        }

        //通过名字模糊查询到用户的id
        public List<Users> selectUserNameId(string name)
        {
            string sql = "select ID from T_User where UserName like @name";
            SqlParameter sp = new SqlParameter("@name", name);
            //int uid = Convert.ToInt32(SqlHelper.ExecuteScalar(sql,CommandType.Text,sp));
            List<Users> list = new List<Users>();
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Users u = new Users();
                    u.ID = Convert.ToInt32(rows["ID"]);
                    list.Add(u);
                }
            }
            return list;
        }



        public List<Users> zong(string sql,SqlParameter[] sp,List<Users> list)          //公共部分
        { 
            using (DataTable dt = SqlHelper.ExecuteDataTable(sql, CommandType.Text, sp))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Users u = new Users()
                    {
                        ID = Convert.ToInt32(rows["ID"]),
                        IsDelete = Convert.ToBoolean(rows["IsDelete"]),
                        CreateTime = Convert.ToDateTime(rows["CreateTime"]),
                        UserName = Convert.ToString(rows["UserName"]),
                        UserPassWord = Convert.ToString(rows["UserPassWord"]),
                        UserSex = Convert.ToString(rows["UserSex"] == DBNull.Value ? null : rows["UserSex"]),
                        UserQQ = Convert.ToInt64(rows["UserQQ"] == DBNull.Value ? 0 : rows["UserQQ"]),
                        UserPhone = Convert.ToInt64(rows["UserPhone"] == DBNull.Value ? null : rows["UserPhone"]),
                        UserStuID = Convert.ToInt64(rows["UserStuID"]),
                        UserFname = Convert.ToString(rows["UserFname"] == DBNull.Value ? null : rows["UserFname"]),
                        UserIP = Convert.ToString(rows["UserIP"]),
                        Belong = Convert.ToString(rows["Belong"])
                    };
                    list.Add(u);
                }
            }
            return list;
        }


        public List<Users> addManagersFromUsers(string ids)
        {
            List<Users> list=new List<Users>();
            return zong("select * from T_User where ID in(" + ids + ")", null, list);
            
        }

    }
}