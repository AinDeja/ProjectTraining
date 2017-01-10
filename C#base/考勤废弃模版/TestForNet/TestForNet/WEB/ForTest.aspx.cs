﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestForNet.DAL;

namespace TestForNet.WEB
{
    public partial class ForTest : System.Web.UI.Page
    {
        protected System.Text.StringBuilder tTr = new System.Text.StringBuilder(500);
        protected void Page_Load(object sender, EventArgs e)
        {
            T_SignIN showTime = new T_SignIN();
            DataTable showList = showTime.userSignInMess("王翔宇");
            foreach (DataRow dr in showList.Rows)
            {

                string pd = String.Format("{0:yyyy/MM/dd}", dr["CreateTime"]);//格式化时间


               
                    string am = String.Format("{0:HH:mm}", dr["am"]);
                    string pm = String.Format("{0:HH:mm}", dr["pm"]);
                    string nm = String.Format("{0:HH:mm}", dr["nm"]);


                    tTr.Append(" <td>" + dr["name"] + "</td>");
                    tTr.Append(" <td>" + pd + "</td>");
                    //早
                    if (am != null)
                    {
                        if (am.CompareTo("08:01") > 0 && am.CompareTo("08:10") < 0)//A,ComoareTo(B)  若A<B返回-1 ，A>B返回1，A=B 返回0。A<=B <0,A>=B  >0
                        {
                            tTr.Append(" <td><font color='blue'>" + am + "</font></td>");
                        }
                        else if (am == "08:01" || am == "08:10")
                        {
                            tTr.Append(" <td><font color='blue'>" + am + "</font></td>");
                        }
                        else if (am.CompareTo("08:11") > 0 && am.CompareTo("13:59") < 0)
                        {
                            tTr.Append(" <td><font color='#FF0000'>" + am + "</font></td>");
                        }
                        else if (am == "08:11" || am == "13:59")
                        {
                            tTr.Append(" <td><font color='#FF0000'>" + am + "</font></td>");
                        }

                        else if (am.CompareTo("08:00") < 0)
                        {
                            tTr.Append(" <td>" + am + "</td>");
                        }
                        else if (am == "08:00")
                        {
                            tTr.Append(" <td>" + am + "</td>");
                        }
                        else if (am == "wait" && am.CompareTo("13:59") < 0)
                        {
                            tTr.Append(" <td><font color='#FF0000'>O</font></td>");
                        }
                        else
                        {
                            tTr.Append(" <td><font color='#FF0000'>X</font></td>");
                        }
                    }
                    //中
                    if (pm != null)
                    {
                        if (pm.CompareTo("14:01") > 0 && pm.CompareTo("14:10") < 0)//A,ComoareTo(B)  若A<B返回-1 ，A>B返回1，A=B 返回0。A<=B <0,A>=B  >0
                        {
                            tTr.Append(" <td><font color='blue'>" + pm + "</font></td>");
                        }
                        else if (pm == "14:01" || pm == "14:10")
                        {
                            tTr.Append(" <td><font color='blue'>" + pm + "</font></td>");
                        }
                        else if (pm.CompareTo("14:11") > 0 && pm.CompareTo("18:59") < 0)
                        {
                            tTr.Append(" <td><font color='#FF0000'>" + pm + "</font></td>");
                        }
                        else if (pm == "14:11" || pm == "18:59")
                        {
                            tTr.Append(" <td><font color='#FF0000'>" + pm + "</font></td>");
                        }

                        else if (pm.CompareTo("12:01") > 0 && pm.CompareTo("14:00") < 0)
                        {
                            tTr.Append(" <td>" + pm + "</td>");
                        }
                        else if (pm == "14:00" || pm == "12:01")
                        {
                            tTr.Append(" <td>" + pm + "</td>");
                        }
                        else if (pm == "wait" && am.CompareTo("18:59") < 0)
                        {
                            tTr.Append(" <td><font color='#FF0000'>O</font></td>");
                        }
                        else
                        {
                            tTr.Append(" <td><font color='#FF0000'>X</font></td>");
                        }
                    }
                    //晚
                    if (pm != null)
                    {
                        if (nm.CompareTo("19:01") > 0 && nm.CompareTo("19:10") < 0)//A,ComoareTo(B)  若A<B返回-1 ，A>B返回1，A=B 返回0。A<=B <0,A>=B  >0
                        {
                            tTr.Append(" <td><font color='blue'>" + nm + "</font></td>");
                        }
                        else if (nm == "19:01" || nm == "19:10")
                        {
                            tTr.Append(" <td><font color='blue'>" + pm + "</font></td>");
                        }
                        else if (nm.CompareTo("19:11") > 0 && nm.CompareTo("23:59") < 0)
                        {
                            tTr.Append(" <td><font color='#FF0000'>" + nm + "</font></td>");
                        }
                        else if (nm == "19:11" || nm == "23:59")
                        {
                            tTr.Append(" <td><font color='#FF0000'>" + nm + "</font></td>");
                        }

                        else if (nm.CompareTo("18:01") > 0 && nm.CompareTo("19:00") < 0)
                        {
                            tTr.Append(" <td>" + nm + "</td>");
                        }
                        else if (nm == "19:00" || nm == "18:01")
                        {
                            tTr.Append(" <td>" + nm + "</td>");
                        }
                        else if (nm == "wait" && am.CompareTo("21:59") < 0)
                        {
                            tTr.Append(" <td><font color='#FF0000'>O</font></td>");
                        }
                        else
                        {
                            tTr.Append(" <td><font color='#FF0000'>X</font></td>");
                        }
                    }

                
                tTr.Append("</tr>");


            }
        }
    }
}
    