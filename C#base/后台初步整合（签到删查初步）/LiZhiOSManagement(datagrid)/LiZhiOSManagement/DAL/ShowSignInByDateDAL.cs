using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace LiZhiOSManagement.DAL
{
    public class ShowSignInByDateDAL
    {
        public List<Sign> ShowSignForAdmin()
        {
            List<Sign> list = new List<Sign>();
            using (DataTable dt = SqlHelper.ExecuteDataTable("select distinct toDay,'sum'=count(name) from T_SignIN group by toDay order by toDay", CommandType.Text))
            {
                int fid = 0;//数据库设计问题 以假ID代替
                foreach (DataRow rows in dt.Rows)
                {
                    Sign alla = new Sign()
                    {
                        ID =fid,// Convert.ToInt32(rows["ID"]),//数据库设计问题 以假ID代替
                        //IsDelete = Convert.ToBoolean(rows["IsDelete"]),
                        //CreateTime = Convert.ToDateTime(rows["CreateTime"]),
                        //Name = Convert.ToString(rows["name"]),
                        //Belong = Convert.ToString(rows["belong"]),
                        //Am = Convert.ToString(rows["am"]),
                        //Pm = Convert.ToString(rows["pm"]),
                        //Nm = Convert.ToString(rows["nm"]),
                        Today = Convert.ToString(rows["toDay"]),
                        SureNum = Convert.ToInt32(rows["sum"]),
                        GroupNum =25,
                        pid=fid

                    };
                    list.Add(alla);
                    fid++;
                }
            }
            return list;
        }
        /// <summary>
        /// 查询未删除
        /// </summary>
        /// <returns></returns>
        public List<Sign> showForDeleteFalse()
        {
       List<Sign> list = new List<Sign>();
       using (DataTable dt = SqlHelper.ExecuteDataTable("select distinct toDay,'sum'=count(name) from T_SignIN where IsDelete is null or IsDelete=0 group by toDay order by toDay", CommandType.Text))
            {
                int fid = 0;//数据库设计问题 以假ID代替
                foreach (DataRow rows in dt.Rows)
                {
                   
                    Sign alla = new Sign()
                    {
                        ID = fid,// Convert.ToInt32(rows["ID"]),//数据库设计问题 以假ID代替
                        //IsDelete = Convert.ToBoolean(rows["IsDelete"]),
                        //CreateTime = Convert.ToDateTime(rows["CreateTime"]),
                        //Name = Convert.ToString(rows["name"]),
                        //Belong = Convert.ToString(rows["belong"]),
                        //Am = Convert.ToString(rows["am"]),
                        //Pm = Convert.ToString(rows["pm"]),
                        //Nm = Convert.ToString(rows["nm"]),
                        Today = Convert.ToString(rows["toDay"]),
                        SureNum = Convert.ToInt32(rows["sum"]),
                        GroupNum = 25,
                        pid = fid

                    };
                    list.Add(alla);
                    fid++;
                }
            }
            return list;
        }
        /// <summary>
        /// 查询删除的记录
        /// </summary>
        /// <returns></returns>
        public List<Sign> showForDeleteTrue()
        {

            List<Sign> list = new List<Sign>();
            using (DataTable dt = SqlHelper.ExecuteDataTable("select distinct toDay,'sum'=count(name) from T_SignIN where IsDelete=1 group by toDay order by toDay", CommandType.Text))
            {
                int fid = 0;//数据库设计问题 以假ID代替
                foreach (DataRow rows in dt.Rows)
                {
                    Sign alla = new Sign()
                    {
                        ID = fid,// Convert.ToInt32(rows["ID"]),//数据库设计问题 以假ID代替
                        //IsDelete = Convert.ToBoolean(rows["IsDelete"]),
                        //CreateTime = Convert.ToDateTime(rows["CreateTime"]),
                        //Name = Convert.ToString(rows["name"]),
                        //Belong = Convert.ToString(rows["belong"]),
                        //Am = Convert.ToString(rows["am"]),
                        //Pm = Convert.ToString(rows["pm"]),
                        //Nm = Convert.ToString(rows["nm"]),
                        Today = Convert.ToString(rows["toDay"]),
                        SureNum = Convert.ToInt32(rows["sum"]),
                        GroupNum = 25,
                        pid = fid

                    };
                    list.Add(alla);
                    fid++;
                }
            }
            return list;
        }

        /// <summary>
        /// 按日期查询
        /// </summary>
        /// <returns></returns>
        public List<Sign> showForDate(string date)
        {

            List<Sign> list = new List<Sign>();
            using (DataTable dt = SqlHelper.ExecuteDataTable("select distinct toDay,'sum'=count(name) from T_SignIN where toDay='"+date+"'group by toDay order by toDay  ", CommandType.Text))
            {
                int fid = 0;//数据库设计问题 以假ID代替
                foreach (DataRow rows in dt.Rows)
                {
                    Sign alla = new Sign()
                    {
                        ID = fid,// Convert.ToInt32(rows["ID"]),//数据库设计问题 以假ID代替
                        //IsDelete = Convert.ToBoolean(rows["IsDelete"]),
                        //CreateTime = Convert.ToDateTime(rows["CreateTime"]),
                        //Name = Convert.ToString(rows["name"]),
                        //Belong = Convert.ToString(rows["belong"]),
                        //Am = Convert.ToString(rows["am"]),
                        //Pm = Convert.ToString(rows["pm"]),
                        //Nm = Convert.ToString(rows["nm"]),
                        Today = Convert.ToString(rows["toDay"]),
                        SureNum = Convert.ToInt32(rows["sum"]),
                        GroupNum = 25,
                        pid = fid

                    };
                    list.Add(alla);
                    fid++;
                }
            }
            return list;
        }
    }
}