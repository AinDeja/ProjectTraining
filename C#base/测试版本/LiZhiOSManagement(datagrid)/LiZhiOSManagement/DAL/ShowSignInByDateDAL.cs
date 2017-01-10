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
            using (DataTable dt = SqlHelper.ExecuteDataTable("select distinct toDay,count(name) from T_SignIN group by toDay order by toDay", CommandType.Text))
            {
                foreach (DataRow rows in dt.Rows)
                {
                    Sign alla = new Sign()
                    {
                        //ID = Convert.ToInt32(rows["ID"]),
                        //IsDelete = rows["IsDelete"] == DBNull.Value ? false : Convert.ToBoolean(rows["IsDelete"]),
                        //CreateTime = Convert.ToDateTime(rows["CreateTime"]),
                        //Name = Convert.ToString(rows["name"]),
                        //Belong = Convert.ToString(rows["belong"]),
                        //Am = Convert.ToString(rows["am"]),
                        //Pm = Convert.ToString(rows["pm"]),
                        //Nm = Convert.ToString(rows["nm"]),
                        Today = Convert.ToString(rows["toDay"]),
                        SureNum = Convert.ToInt32(rows["Column1"]),
                        GroupNum =25

                    };
                    list.Add(alla);
                }
            }
            return list;
        }
    }
}