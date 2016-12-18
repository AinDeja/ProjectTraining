
using LiZhiOSManagement.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;


namespace WebApplication1.Management.AJAX
{
    /// <summary>
    /// ShowStatistics 的摘要说明
    /// </summary>
    public class ShowStatistics : IHttpHandler
    {

        //public void ProcessRequest(HttpContext context)
        //{
        //    context.Response.ContentType = "text/plain";
        //    //string Fday = context.Request.QueryString["Fday"];
        //    //string Lday = context.Request.QueryString["Lday"];
        //    //// string Path = context.Request.QueryString["Path"];
        //    ////格式转换 .replace
        //    //Fday = Fday.Replace("-", "/");
        //    //Lday = Lday.Replace("-", "/");
        //    ////**********路径获取有问题*************设置默认值，跳出下载窗口自行选择
        //    //string Path = @"H:/新建文件夹/outsign.xlsx";
        //    ////string pathSelf = @"H:/新建文件夹/outsign.xlsx";
        //    //T_SignIN SignTable = new T_SignIN();
        //    ////DataSet selectDateSign = SignTable.outExcle("2016/10/01", "2016/11/01");
        //    //DataSet selectDateSign = SignTable.outExcle(Fday, Lday);
        //    //OutForExcle outxls = new OutForExcle();
        //    //outxls.DataSetToLocalExcel(selectDateSign, Path, false);

        //    JavaScriptSerializer jss = new JavaScriptSerializer(); 


        //}
                public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            JavaScriptSerializer jss = new JavaScriptSerializer();


            string Fday = context.Request.QueryString["Fday"];
            string Lday = context.Request.QueryString["Lday"];

            // string Path = context.Request.QueryString["Path"];
            //格式转换 .replace
            Fday = Fday.Replace("-", "/");
            Lday = Lday.Replace("-", "/");
            //总天数
            DateTime F = Convert.ToDateTime(Fday);
            DateTime L = Convert.ToDateTime(Lday);
            int days = (int)(L - F).TotalDays+1;
            //**********路径获取有问题*************设置默认值，跳出下载窗口自行选择
            //string pathSelf = @"H:/新建文件夹/outsign.xlsx";
           

            //string[] ax=new string[]{"1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"};
            //double[] sr=new double[]{2.0, 4.9, 7.0, 23.2, 25.6, 76.7, 135.6, 162.2, 32.6, 20.0, 6.4, 3.3};
            //string[] ax2=new string[]{"1月", "2月", "3月", "4月", "5月", "6月", "7月", "8月", "9月", "10月", "11月", "12月"};
            //double[] sr2=new double[]{2.0, 4.9, 7.0, 23.2, 25.6, 76.7, 135.6, 162.2, 32.6, 20.0, 6.4, 3.3};
            SignGroups ps = new SignGroups();
            ps.legen = new string[2];
            ps.legen[0] = "签到人数";
            ps.legen[1] = "迟到人数";
            //ps.axis=ax;
            //ps.series = new double[2][];
            //ps.series[0] = sr;
            //ps.series[1] = sr2;


            T_SignIN SignTable = new T_SignIN();

            //DataTable statisticalTable = SignTable.statisticalSign("2016/04/15", "2016/05/10");
            DataTable statisticalTable = SignTable.statisticalSign(Fday, Lday);
            int dayNums=statisticalTable.Rows.Count;
            ps.axis = new string[days];//统计22天
            ps.series = new double[2][];//2为两类不同的统计数据 qiandaoshu和chidaoshu

            double[] q = new double[days];
            double[] c = new double[days];
            
            int j = 0,k=1,qiandaoshu=0,chidaoshu=0;
            foreach (DataRow charts in statisticalTable.Rows)
            {
                if (j==0)
                {
                    ps.axis[0] = charts["toDay"].ToString();
                    j++;
                }
                
                //时间遍历得到axis
                if (charts["toDay"].ToString()!=ps.axis[j-1])
                {
                    ps.axis[k] = charts["toDay"].ToString();
                    k++;
                    j++;
                    //横坐标+1 纵坐标归0
                    qiandaoshu = 0;
                    chidaoshu = 0;
                }
                
                //
                //当日nm签到数统计得到series
                if (charts["toDay"].ToString()==ps.axis[j-1])
                {
                    if (charts["nm"].ToString().CompareTo("18:01") > 0 && charts["nm"].ToString().CompareTo("19:00") < 0)
                    {
                        chidaoshu++;
                        c[j-1] = chidaoshu;
                        qiandaoshu++;
                        q[j - 1] = qiandaoshu;
                    }
                    else
                    {
                        qiandaoshu++; 
                        q[j-1] = qiandaoshu; }
                   
                }
                //
                //else if (nm.CompareTo("18:01") > 0 && nm.CompareTo("19:00") < 0)
                //{
                //    tTr.Append(" <td>" + nm + "</td>");
                //}
                //else if (nm == "19:00" || nm == "18:01")
                //{
                //    tTr.Append(" <td>" + nm + "</td>");
                //}
                
            }
            ps.series[0] = q;
            ps.series[1] = c;

            string json = jss.Serialize(ps);//json 序列化对象数组
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public struct  SignGroups
    {
        public string[] legen { get; set; }
        public string[] axis { get; set; }
        public double[][] series { get; set; }

    }

 
    }
