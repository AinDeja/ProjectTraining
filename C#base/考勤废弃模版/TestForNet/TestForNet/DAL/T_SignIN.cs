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
            string sql = "select*from T_SignIN";
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return view;
        }
        /// <summary>
        /// 查找用户所有签到记录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable userSignInMess(string userName)
        {
            string sql = "select*from T_SignIN where name='" + userName + "' order by toDay";
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
            return view;
        }
        /// <summary>
        /// 按日期和姓名查找签到记录
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataRow serachSignIN(string userName)
        {
            string toDayTime = DateTime.Now.ToString("yyyy/MM/dd");
            DataRow startSignIN;
            string sql = "select*from T_SignIN where name='"+userName+"' and toDay='"+toDayTime+"' ";
            DataTable view = Sql.ExecuteDataTable(sql, System.Data.CommandType.Text);
          

            if (view.Rows.Count != 0)
                startSignIN = view.Rows[0];
            else
                startSignIN = null;
            return startSignIN;
            
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
            if (time.CompareTo("13:00") > 0 && time.CompareTo("17:00") < 0)
                pm = time;
            if (time.CompareTo("18:00") > 0 && time.CompareTo("22:00") < 0)
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
           int newTime=Sql.ExecuteNonQuery(sql, System.Data.CommandType.Text, pms);//新增签到信息
                tip = "签到成功！";

        
        }
             return tip;
            }
          

        }
    }
