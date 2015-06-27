using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

using FirstMillion_new.App_Code;

namespace FirstMillion_new
{
    public partial class Game : System.Web.UI.Page
    {

        #region Fields & Properties
        public IEnumerable<Question> allQuestions {get; set; }
        private int _step;
        Random rnd = new Random();
        private Button[] Buttons{  get;  set; }

        #endregion

        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            _step = (int)Session[SessionKeys.SessionStep];
            allQuestions = (IEnumerable<Question>)Session[SessionKeys.SessionRepo];
            Buttons = new Button[4] { BtnA, BtnB, BtnC, BtnD };
            FillCells(allQuestions.ElementAt(_step));

            if (((bool?)Session[SessionKeys.SessionKey5050]).GetValueOrDefault())
            {
                Btn5050.CssClass = "Btn5050Used";
                Btn5050.Enabled = false;
            }

            if (((bool?)Session[SessionKeys.SessionKeyCall]).GetValueOrDefault())
            {
                BtnCall.CssClass = "BtnCallUsed";
                BtnCall.Enabled = false;
            }

            if (((bool?)Session[SessionKeys.SessionKeyAsk]).GetValueOrDefault())
            {
                BtnAsk.CssClass = "BtnAskUsed";
                BtnAsk.Enabled = false;
            }     
        }

        #endregion

        #region Events
        protected void BtnA_Click(object sender, EventArgs e)
        {
            CheckAnswer(allQuestions.ElementAt(_step), 0);
        }

        protected void BtnB_Click(object sender, EventArgs e)
        {
            CheckAnswer(allQuestions.ElementAt(_step), 1);
        }

        protected void BtnC_Click(object sender, EventArgs e)
        {
            CheckAnswer(allQuestions.ElementAt(_step), 2);
        }

        protected void BtnD_Click(object sender, EventArgs e)
        {
            CheckAnswer(allQuestions.ElementAt(_step), 3);
        }

        protected void Btn5050_Click(object sender, EventArgs e)
        {
            Btn5050.CssClass = "Btn5050Used";
            Btn5050.Enabled = false;
            int number, number1;
            Fifty(out number, out number1);
            HoverButtons(number, number1);
            Session[SessionKeys.SessionKey5050] = true;
        }

        protected void BtnCall_Click(object sender, EventArgs e)
        {
            BtnCall.Enabled = false;
            TxtMail.CssClass = "MailVisible";
            BtnSend.CssClass = "SendVisible";
            TxtMymail.CssClass = "MyMailVisible";
            TxtPass.CssClass = "MyMailVisible";
            foreach (Button btn in Buttons)
            {
                btn.Enabled = false;
            }
        }

        protected void BtnAsk_Click(object sender, EventArgs e)
        {
            BtnAsk.CssClass = "BtnAskUsed";
            BtnAsk.Enabled = false;
            Session[SessionKeys.SessionKeyAsk] = true;

            ClientScript.RegisterStartupScript(this.GetType(), "window.open", "window.open('https://www.google.com.ua/search?q=" + allQuestions.ElementAt(_step).Quest + "')", true);
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            if ((TxtMail.Text != "") && (TxtMymail.Text != "") && (TxtPass.Text != ""))
            {
                var fromAddress = new MailAddress(TxtMymail.Text, "Ольга");
                var toAddress = new MailAddress(TxtMail.Text, "Володя");

                string fromPassword = TxtPass.Text;
                const string subject = "Допомога друга";
                string body = "Запитання: " + allQuestions.ElementAt(_step).Quest + " Відповіді: A: " + allQuestions.ElementAt(_step).Answers[0] +
                     ", B: " + allQuestions.ElementAt(_step).Answers[1] + ", C: " + allQuestions.ElementAt(_step).Answers[2] + ", D: " + allQuestions.ElementAt(_step).Answers[3] + ". ";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
                TxtMail.CssClass = "Mail";
                BtnSend.CssClass = "Send";
                TxtMymail.CssClass = "Mymail";
                TxtPass.CssClass = "Mymail";
                Session[SessionKeys.SessionKeyCall] = true;
                BtnCall.CssClass = "BtnCallUsed";
                foreach (Button btn in Buttons)
                {
                    btn.Enabled = true;
                }
            }

            if (TxtMail.Text == "")
            {
                TxtMail.Text = "Потрібно ввести адресу друга";
            }
            if (TxtMymail.Text == "")
            {
                TxtMymail.Text = "Введіть вашу адресу";
            }
            if (TxtPass.Text == "")
            {
                TxtPass.Text = "Введіть ваш пароль";
            }

        }



        #endregion

        #region Helpers
        private void FillCells(Question question)
        {
            ActiveScores.ActiveSum(_step+1);
            BtnQuestion.Text = question.Quest;
            for (int i = 0; i < 4; i++)
            {
                Buttons[i].Text = question.Answers[i];
            }
        }

        public void CheckAnswer(Question quest, int answerId)
        {

            if ((quest.RightAnswer == answerId) && (_step != 14))
            {
                _step += 1;
                Session[SessionKeys.SessionStep] = _step;
                FillCells(allQuestions.ElementAt(_step));
            }
            else if ((quest.RightAnswer == answerId) && (_step == 14))
            {
                GamеWin();
            }
            else
            {
                GameOver();
            }        
        }

        private void Fifty(out int button, out int button1)
        {
            int i = rnd.Next(0, 4);
            int j = rnd.Next(0, 4);
            if (((i != allQuestions.ElementAt(_step).RightAnswer) && (j != allQuestions.ElementAt(_step).RightAnswer) && (i != j)))
            {
                button = i;
                button1 = j;
            }
            else
            {
                Fifty(out button, out button1);
            }
        }


        private void HoverButtons(int i, int j)
        {
            Buttons[i].Text = "";
            Buttons[j].Text = "";
        }

           
        private void GameOver()
        {
            string result = "";
            int sumId = 0;
           
            if (_step <= 4)
            {
                result = Session[SessionKeys.SessionName] + ", ви програли. Ваш виграш становить 0 грн.";
                sumId = 15;
            }

            else if ((_step > 4) && (_step <= 9))
            {
                result = Session[SessionKeys.SessionName] + ", ви програли. Ваш виграш становить 1000 грн.";
                sumId = 10;
            }

            else if ((_step > 9) && (_step <= 14))
            {
                result = Session[SessionKeys.SessionName] + ", ви програли. Ваш виграш становить 32000 грн.";
                sumId = 5;            
            }

            Response.Redirect("~/TheEnd.aspx?str=" + result + "&activeSum=" + sumId.ToString());
        }

        private void GamеWin()
        {
            string result = "Вітаємо, " + Session[SessionKeys.SessionName] + "! Ви заробили свій перший мільйон!";
            int sumId = 0;
            Response.Redirect("~/TheEnd.aspx?str=" + result + "&activeSum=" + sumId.ToString());
        }

        #endregion

    }
}