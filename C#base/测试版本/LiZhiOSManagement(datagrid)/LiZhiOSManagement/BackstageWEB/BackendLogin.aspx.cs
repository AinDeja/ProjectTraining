using LiZhiOSManagement.BLL;
using LiZhiOSManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LiZhiOSManagement.WEB
{
    public partial class BackendLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.Params["name"]!=null)
                {
                    string name = Request.Params["name"].ToString();
                    string pwd = Request.Params["pwd"].ToString();
                    ShowManagersMessagesBLL smm = new ShowManagersMessagesBLL();
                    List<SuperManagers> list = new List<SuperManagers>();
                    list = smm.selectSM();
                    int s = smm.selectQuan(name, pwd);
                    Session["quan"] = "m";
                    if (s == 0)
                    {
                        Response.Write("<script>alert('登录失败');</script>");
                    }
                    else if (s == 1)
                    {
                        if (list.Exists(r => r.UserName == name))
                        {
                            Session["quan"] = "sm";
                            Session["name"] = name;
                            string ce1 = Session["quan"].ToString();
                            string ce2 = Session["name"].ToString();
                            Response.Redirect("Index.aspx");
                        }
                        else
                        {
                            Session["name"] = name;
                            Response.Redirect("Index.aspx");
                        }
                    }
                }
                else
                {

                }
                
            }
            
        }
    }
}