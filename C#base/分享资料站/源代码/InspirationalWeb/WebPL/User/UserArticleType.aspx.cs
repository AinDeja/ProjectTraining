using InspirationalWeb.BLL;
using InspirationalWeb.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InspirationalWeb.WebPL.User
{
    public partial class UserArticleType : System.Web.UI.Page
    {
        protected System.Text.StringBuilder fatherTr = new System.Text.StringBuilder(500);
        protected System.Text.StringBuilder sonTr = new System.Text.StringBuilder(500);
        protected int fts = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Distinguish.CheckLogin();
            T_User list = new T_User();
            DataTable father=list.SearchArticleTypeFather();
         
            foreach (DataRow ddf in father.Rows)
            {
                if ((bool)ddf["IsDelete"] == false)
                {
                    fatherTr.Append("<dd class='fathertypes' onclick=\"turnto('/WebPL/User/UserArticleType.aspx?fts=" + ddf["ID"] + "')\">" + ddf["TypeName"] + " </dd> ");
                }

            }


            fts = Convert.ToInt32(Context.Request["fts"]);
            if (Convert.ToInt32(Session["FTS"]) != fts && fts != 0)
                Session["FTS"] = fts;
            DataTable son = list.SearchArticleTypeSon(fts);
            foreach (DataRow dds in son.Rows)
            {
                if ((bool)dds["IsDelete"] == false)
                {
                    sonTr.Append("<dd>" + dds["TypeName"] + " </dd>");
                }
            }

            if (Request.HttpMethod.ToLower() == "post")
            {

                B_Admin newT = new B_Admin();
                string newSon = Context.Request["newSon"];
                newT.newArticleTypeSon(Convert.ToInt32(Session["FTS"]), newSon);
                Response.Redirect("UserArticleType.aspx?fts=" + Convert.ToInt32(Session["FTS"]) + "");
            }
            
        }
    }
}