using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirstMillion_new.App_Code;

namespace FirstMillion_new
{
    public partial class TheEnd : System.Web.UI.Page
    {

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnRestart.Text = Request.QueryString["str"] + " Натисніть тут, щоб спробувати ще раз.";
            int i = int.Parse(Request.QueryString["activeSum"]);
            Scores.YourSum(i);       
        }

        protected void BtnRestart_Click(object sender, EventArgs e)
        {
            Session[SessionKeys.SessionKey5050] = false;
            Session[SessionKeys.SessionKeyCall] = false;
            Session[SessionKeys.SessionKeyAsk] = false;
            Session[SessionKeys.SessionStep] = 0;
            Response.Redirect("~/Game.aspx");
        }

        #endregion
    }
}