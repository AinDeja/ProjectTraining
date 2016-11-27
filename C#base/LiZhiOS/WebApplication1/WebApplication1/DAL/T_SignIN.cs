using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestForNet.DAL
{
    public class T_SignIN
    {
       /* public DataTable searchByName(string name)
        {

        }*/
          public DataTable show()
        {
            string sql = "select*from T_SignIN order by belong ";
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return view;
        }

        
        /// <summary>
        /// DataTable两个时间间隔内的签到信息
        /// </summary>
        /// <param name="firstday"></param>
        /// <param name="lastday"></param>
        /// <returns></returns>
        public DataTable statisticalSign(string firstday, string lastday)
        {
            string sql = "select * from T_SignIN where toDay>='" + firstday + "' and toDay<='" + lastday + "'  order by toDay";
            DataTable statisticalTable = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return statisticalTable;
        }
        /// <summary>
        /// DataSet两个时间间隔内的签到信息
        /// </summary>
        /// <param name="firstday"></param>
        /// <param name="lastday"></param>
        /// <returns></returns>
        public DataSet outExcle(string firstday,string lastday)
        {
            
                 string sql = "select * from T_SignIN where toDay>='"+firstday+"' and toDay<='"+lastday+"' ";
                 DataSet tableExcle = Sql.ExecuteDataSet(sql, System.Data.CommandType.Text);
            return tableExcle;
        }
        /// <summary>
        /// Admin查看指定日期签到表
        /// </summary>
        /// <returns></returns>
        public DataTable showDay(string today)
        {
            string sql = "select*from T_SignIN order by belong where toDay='"+today+"' ";
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return view;
        }
        public DataRow serachSignIN(string userName)
        {
            string toDayTime = DateTime.Now.ToString("yyyy/MM/dd");
            DataRow startSignIN;
            string sql = "select*from T_SignIN where name='" + userName + "' and toDay='" + toDayTime + "' order by belong ";
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
          

            if (view.Rows.Count != 0)
                startSignIN = view.Rows[0];
            else
                startSignIN = null;
            return startSignIN;
            
        }
        /// <summary>
        /// 创建新一天的签到表
        /// </summary>
        /// <returns></returns>
        public DataTable newTables() {
            T_User numName = new T_User();
            DataTable names, view;
            names = numName.allId();
            string time = "wait";
            int i = names.Rows.Count;
            foreach (DataRow dr in names.Rows)
            {
                setNewSignIN(dr["UserName"].ToString(),time);
            }
            string sql = "select*from T_SignIN order by belong ";
            view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return view;
        }
        /// <summary>
        /// 创建新的签到记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="arType"></param>
        /// <param name="arTitle"></param>
        /// <param name="arCont"></param>
        public string setNewSignIN(string userName,string time)
        {
            string tip = "签到失败！";
            string toDayTime = DateTime.Now.ToString("yyyy/MM/dd");
            string sql;
            T_User userStuID = new T_User();
            DataRow Stu = userStuID.userStuIDByUserNameSearch(userName);
            DataRow serachEnd = serachSignIN(Stu["UserFname"].ToString());
            if ( serachEnd== null)
            {

            
            sql = "Insert into T_SignIN(name,belong,am,pm,nm,toDay) values(@name,@belong,@am,@pm,@nm,@today)";
            
            string am = "wait", pm = "wait", nm = "wait";
            if (time.CompareTo("05:00") > 0 && time.CompareTo("12:00") < 0)
                am = time;
            else if (time.CompareTo("13:00") > 0 && time.CompareTo("17:00") < 0)
                pm = time;
            else if (time.CompareTo("18:00") > 0 && time.CompareTo("22:00") < 0)
                nm = time;
            SqlParameter[] pms = new SqlParameter[] { 
                new SqlParameter("@name", System.Data.SqlDbType.NVarChar) { Value = Stu["UserFname"] } ,
                 new SqlParameter("@belong", System.Data.SqlDbType.NVarChar) { Value = Stu["belong"] } ,
                 
                 new SqlParameter("@am",System.Data.SqlDbType.NVarChar){Value=am},
                 new SqlParameter("@pm",System.Data.SqlDbType.NVarChar){Value=pm},
                  new SqlParameter("@nm",System.Data.SqlDbType.NVarChar){Value=nm},
                  new SqlParameter("@today",System.Data.SqlDbType.NVarChar){Value=toDayTime},
            };
           int newTime=Sql.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);//新增签到信息
                tip = "签到成功！";
            }
            else
            {
           
            sql = "update T_SignIN set am=@am,pm=@pm,nm=@nm where ID="+serachEnd["ID"]+" ";
            string am = "wait", pm = "wait", nm = "wait";
            if(serachEnd["am"].ToString()=="wait"){
                if (time.CompareTo("05:00") > 0 && time.CompareTo("12:00") < 0)
                am = time;}
            else am=serachEnd["am"].ToString();
            if(serachEnd["pm"].ToString()=="wait"){
                if (time.CompareTo("13:00") > 0 && time.CompareTo("17:00") < 0)
                pm = time;}
                 else pm=serachEnd["pm"].ToString();
            if(serachEnd["nm"].ToString()=="wait"){
                if (time.CompareTo("18:00") > 0 && time.CompareTo("22:00") < 0)
                nm = time;}
                 else nm=serachEnd["nm"].ToString();
            SqlParameter[] pms = new SqlParameter[] {          
                 new SqlParameter("@am",System.Data.SqlDbType.NVarChar){Value=am},
                 new SqlParameter("@pm",System.Data.SqlDbType.NVarChar){Value=pm},
                  new SqlParameter("@nm",System.Data.SqlDbType.NVarChar){Value=nm},
            };
           int newTime=Sql.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);//更新签到信息
                tip = "签到成功！";

        
        }
             return tip;
            }

        /// <summary>
        /// 查询当天签到
        /// </summary>
        /// <param name="today"></param>
        /// <returns></returns>
        public static DataTable selectDaySign(string today)
        {

            today=DateTime.Now.ToString("yyyy/MM/dd");
            string sql = "select*from T_SignIN where toDay='" + today + "' order by belong ";
            DataTable thisday = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return thisday;
        }
        /// <summary>
        /// 管理员查看签到列表
        /// </summary>
        /// <param name="whereDay"></param>
        /// <returns></returns>
        public  DataTable adminSginList()
        {
            string sql = "select distinct toDay,count(name) from T_SignIN group by toDay order by toDay";
            DataTable viewList = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return viewList;
        }

        public DataTable SginListCut(int pageNumber)
        {
           // string sql = "select distinct toDay,count(name) from T_SignIN group by toDay order by toDay";
            //--每页显示数据量top 
            // --pageNumber：当前页数减1乘6，每页显示6条数据
            string sql=("select top 6 toDay,count(name) from T_SignIN where toDay not in (select distinct top "+((pageNumber-1)*6)+" toDay from  T_SignIN order by toDay desc)group by toDay order by toDay desc");
            DataTable viewList = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return viewList;
        }

        }
    }
