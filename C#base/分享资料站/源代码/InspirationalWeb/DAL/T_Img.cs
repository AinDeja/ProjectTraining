using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InspirationalWeb.DAL
{
    public class T_Img
    {
        //UP
        public int Up( string ImgPath,string ImgMess,int uid,int imgType)
        {
            string su = "Insert into T_PhotoPath(ImgPath,ImgMess,ImgCreator,ImgType) values(@ImgPath,@ImgMess,@ImgCreator,@ImgType)";
            SqlParameter[] set = new SqlParameter[]{
              
                 new SqlParameter("@ImgPath",System.Data.SqlDbType.NVarChar){Value=ImgPath},
                   new SqlParameter("@ImgMess",System.Data.SqlDbType.NVarChar){Value=ImgMess},
                     new SqlParameter("@ImgCreator",System.Data.SqlDbType.Int){Value=uid},
                       new SqlParameter("@ImgType",System.Data.SqlDbType.Int){Value=imgType},
            };

            Sql.ExecuteNonQuery(su, System.Data.CommandType.Text, set);
            return 1;
        }
        //分类列表
        public DataTable SearchPhotoType(int userid)
        {
            string sql = "select*from T_PhotoType where AlbumCreator=1 or AlbumCreator=@uid order by ID";
            SqlParameter[] set = new SqlParameter[]{
              
                 new SqlParameter("@uid",System.Data.SqlDbType.Int){Value=userid},
            };
            return Sql.ExecuteDataTable(sql, System.Data.CommandType.Text, set);

        }
        //public int Up(int ImgCreator, string ImgPath,int ImgType)
        //{
        //    string su = "Insert into T_PhotoPath(ImgCreator,ImgPath,ImgType) values(@ImgCreator,@ImgPath,@ImgType)";
        //    SqlParameter[] set = new SqlParameter[]{
        //        new SqlParameter("@ImgCreator",System.Data.SqlDbType.Int){Value=ImgCreator},
        //         new SqlParameter("@ImgType",System.Data.SqlDbType.Int){Value=ImgType},
        //         new SqlParameter("@ImgPath",System.Data.SqlDbType.NVarChar){Value=ImgPath},
        //    };

        //    Sql.ExecuteNonQuery(su, System.Data.CommandType.Text, set);
        //    return 1;
        //}
        //DOWN
        public DataTable down(int imgType, int pageNumber)
        {
            int star = (pageNumber - 1) * 9 + 1;
            int end = pageNumber * 9;

            string sqlForSerch = @"WITH userOrder AS
            (SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM T_PhotoPath   where ImgType=@imgtype) SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end";

            //查询结果分页

            SqlParameter[] set = new SqlParameter[]{
                
                 new SqlParameter("@star",System.Data.SqlDbType.Int){Value=star},
                 new SqlParameter("@end",System.Data.SqlDbType.Int){Value=end},
                 new SqlParameter("@imgtype",System.Data.SqlDbType.Int){Value=imgType},

            };

            //string su = "select *from T_PhotoPath where ImgType=@imgtype";
            //SqlParameter[] set = new SqlParameter[]{
              
            //     new SqlParameter("@imgtype",System.Data.SqlDbType.Int){Value=imgType},
            //};

            return Sql.ExecuteDataTable(sqlForSerch, System.Data.CommandType.Text, set);
        }
       
        ////TurnImg
        public DataTable turn()
        {
            string su = "select top(4) *from T_PhotoPath order by ID desc";

            return Sql.ExecuteDataTable(su, System.Data.CommandType.Text);
        }

        public DataTable allPhotoList(int pageNumber)
        {

            int star = (pageNumber - 1) * 10 + 1;
            int end = pageNumber * 10;
            string sqlForSerch = @"WITH userOrder AS
            (SELECT ROW_NUMBER() OVER (ORDER BY id) RowNumber,*FROM T_PhotoPath ) SELECT * FROM userOrder WHERE RowNumber BETWEEN @star AND @end";

            //查询结果分页

            SqlParameter[] set = new SqlParameter[]{
                
                 new SqlParameter("@star",System.Data.SqlDbType.Int){Value=star},
                 new SqlParameter("@end",System.Data.SqlDbType.Int){Value=end},


            };
            return Sql.ExecuteDataTable(sqlForSerch, System.Data.CommandType.Text, set);


        }
        //软删除照片
        public void delPhoto(int id)
        {
            string sql = "update T_PhotoPath set IsDelete=1 where ID=@id";
            SqlParameter[] set = new SqlParameter[]{
              
                 new SqlParameter("@id",System.Data.SqlDbType.Int){Value=id},
            };
            Sql.ExecuteDataTable(sql, System.Data.CommandType.Text,set);
        }
        //批量软删除照片
        public void delPhotoAll(string ids)
        {
            string sql = "update T_PhotoPath set IsDelete=1 where ID in(" + ids + ")";
            Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
        }
    }
}