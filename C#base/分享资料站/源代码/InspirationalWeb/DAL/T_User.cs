using InspirationalWeb.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InspirationalWeb.DAL
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

        ///文章管理
        public DataTable SelectArticle(int id)
        {
            string sql = "select*from T_Article where ArCreator=@uid order by ID";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@uid", System.Data.SqlDbType.Int, 50) { Value = id } };
            DataTable pList = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);
            return pList;
        }
        /// <summary>
        /// 父类列表
        /// </summary>
        /// <returns></returns>
        public DataTable SearchArticleTypeFather()
        {
            string sql = "select*from T_ArticleType order by ID";
            
            return Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);

        }
        /// <summary>
        /// 子类列表
        /// </summary>
        /// <returns></returns>
        public DataTable SearchArticleTypeSon(int fatherid)
        {
            string sql = "select*from T_ArticleTypeSon where TypeFather=@fatherid order by ID";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@fatherid", System.Data.SqlDbType.Int, 50) { Value = fatherid } };
            return Sql.ExecuteDataTable(sql, System.Data.CommandType.Text,pms);

        }
        /// <summary>
        /// 创建文章、回复
        /// </summary>
        /// <param name="id"></param>
        /// <param name="arType"></param>
        /// <param name="arTitle"></param>
        /// <param name="arCont"></param>
        public int SetArticleT(int id, int arType,string arTitle,string arCont)
        {
            string sql = "Insert into T_Article(ArTitle,ArCont,ArType,ArCreator) values(@ArTitle,@ArCont,@ArType,@ArCreator)";
            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@ArCreator", System.Data.SqlDbType.Int, 50) { Value = id } ,
                 new SqlParameter("@ArType", System.Data.SqlDbType.Int, 50) { Value = arType } ,
                 new SqlParameter("@ArTitle",System.Data.SqlDbType.NVarChar){Value=arTitle},
                 new SqlParameter("@ArCont",System.Data.SqlDbType.NVarChar){Value=arCont},
            };
            int uid = Sql.ExecuteNonQuery(sql,System.Data.CommandType.Text,pms);//新增文章
            //返回新增文章至展示页面
            string newSql = "select top(1) * from T_Article  order by ID DESC";

            int newId =Convert.ToInt32( Sql.ExecuteScalar(newSql, System.Data.CommandType.Text));
            return newId;
            
        }
        /// <summary>
        /// 文章展示
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable ArticleViewT(int id)
        {
            string sql = "select*from T_Article where ID=@id";
            SqlParameter[] pms = new SqlParameter[] { new SqlParameter("@id", System.Data.SqlDbType.Int, 50) { Value = id } };
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, pms);
            return view;
        }
        /// <summary>
        /// 文章搜索
        /// </summary>
        /// <param name="SerchText"></param>
        /// <returns></returns>
        public DataTable SearchArticleT(string SerchText)
        {
            string sqlForSerch = "select*from T_Article where ArTitle like'%" + SerchText + "%' order by id";
            DataTable postSerch = Sql.ExecuteDataTable(sqlForSerch, System.Data.CommandType.Text);
            //查询结果分页
            //            DataTable userList = Sql.ExecuteDataTable(@"
            //                     ;WITH userOrder AS
            //(SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM DS_Post where PostTitle like'%" + SerchText + "')SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end", new SqlParameter("@Star", (pageNumber - 1) * 10 + 1),
            //                          new SqlParameter("@End", pageNumber * 10));
            return postSerch;
        }
        //文章分页
        public DataTable pagingT( int userid,int pageNumber)
        {
            int star = (pageNumber - 1) * 10 + 1;
            int end = pageNumber * 10;
            string sqlForSerch = @"WITH userOrder AS
            (SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM T_Article  ArTitle where ArCreator=@uid) SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end";

            //查询结果分页

            SqlParameter[] set = new SqlParameter[]{
                
                 new SqlParameter("@star",System.Data.SqlDbType.Int){Value=star},
                 new SqlParameter("@end",System.Data.SqlDbType.Int){Value=end},
                 new SqlParameter("@uid",System.Data.SqlDbType.Int){Value=userid},

            };
            return Sql.ExecuteDataTable(sqlForSerch, System.Data.CommandType.Text, set);

        }
        //搜索文章分页
        public DataTable srPagingT(string SerchText, int pageNumber)
        {
            int star=(pageNumber - 1) * 10 + 1;
            int end=pageNumber * 10;
            string sqlForSerch = @"
                                 ;WITH userOrder AS
            (SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM T_Article where ArTitle like'%" + SerchText + "')SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end";
           
            //查询结果分页
                      
                                                                                                     SqlParameter[] set = new SqlParameter[]{
                
                 new SqlParameter("@star",System.Data.SqlDbType.Int){Value=star},
                 new SqlParameter("@end",System.Data.SqlDbType.Int){Value=end},
                 
            };
          return Sql.ExecuteDataTable(sqlForSerch, System.Data.CommandType.Text, set);
                                                                               
        }

        //相册管理
        public void SelectPicture()
        {

        }
    }
}