using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InspirationalWeb.DAL
{
    public class T_Menu
    {
        //检索文章分类菜单
        public DataTable SelsctArMenu()
        {
            string su = "select * from T_ArticleType order by ID";
            //SqlParameter[] set = new SqlParameter[]{
            //    new SqlParameter("@ImgCreator",System.Data.SqlDbType.Int){Value=ImgCreator},
            //     new SqlParameter("@ImgPath",System.Data.SqlDbType.NVarChar){Value=ImgPath},
            //};

            return Sql.ExecuteDataTable(su, System.Data.CommandType.Text);
        }
        //检索文章分类子菜单
        public DataTable SelsctArMenuSon()
        {
            string su = "select * from T_ArticleTypeSon order by TypeFather";

            return Sql.ExecuteDataTable(su, System.Data.CommandType.Text);
        }
        //检索相册分类
        
            public DataTable SelsctPoMenu()
        {
            string su = "select * from T_PhotoType order by ID";

            return Sql.ExecuteDataTable(su, System.Data.CommandType.Text);
        }
    }
}