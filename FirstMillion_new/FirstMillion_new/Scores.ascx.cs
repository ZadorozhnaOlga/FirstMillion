using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstMillion_new
{
    public partial class Scores : System.Web.UI.UserControl
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        #region Helpers

        public void ActiveSum(int i)   
        {
            if (i == 0)
            {
                TblScores.Rows[15].Attributes.Add("class", "Red");
            }
            else 
            {
                TblScores.Rows[15 - i].Attributes.Add("class", "Red");
                TblScores.Rows[15 - i + 1].Attributes.Add("class", "tableCell");
                if ((i == 5) || (i == 10))
                {
                    TblScores.Rows[15 - i + 1].Attributes.Add("class", "tableCellUnFired");
                }
            }     
        }

        public void YourSum(int i) 
        {  
            TblScores.Rows[i].Attributes.Add("class", "Red");
        }


        #endregion

    }
}