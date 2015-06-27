using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirstMillion_new.App_Code;
namespace FirstMillion_new
{
    public partial class Start : System.Web.UI.Page
    {

        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }  

        protected void BtnStart_Click(object sender, EventArgs e)
        {
            Initialize();
            Response.Redirect("~/Game.aspx");
        }


        #endregion

        #region Helpers
        private void Initialize() 
        {
                var repo = new XmlQuestionRepository(Server.MapPath("/App_Data/myQuestions.xml"));
                Session[SessionKeys.SessionRepo] = repo.GetQuestions();
                Session[SessionKeys.SessionStep] = 0;
                Session[SessionKeys.SessionName] = TxtName.Text;
        }

        #endregion
    }
}