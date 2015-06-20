using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using System.Net.Mail;


namespace FirstMillion_new
{
    public partial class MainForm : System.Web.UI.Page
    {
        static Question[] allQuestions;
        public static int step;
        Random rnd = new Random();
        public Button[] Buttons;
        private const string SessionKey5050 = "50x50";
        private const string SessionKeyCall = "Call";
        private const string SessionKeyAsk = "Ask";


        static MainForm()
        {
            //XmlSerializer formatter = new XmlSerializer(typeof(Question[]));
            
            //using (FileStream fs = new FileStream(@"Resources\myQuestions.xml", FileMode.OpenOrCreate))
            ////(@"D:\visual_studio\ASP\FirstMillion_new\FirstMillion_new\Resources\myQuestions.xml", FileMode.OpenOrCreate))
            //{
            //    allQuestions = (Question[])formatter.Deserialize(fs);
            //}
            step = 0;
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            var s = Server.MapPath("/Resources/myQuestions.xml");
            XmlSerializer formatter = new XmlSerializer(typeof(Question[]));

            using (FileStream fs = new FileStream(s, FileMode.OpenOrCreate))
            
            {
                allQuestions = (Question[])formatter.Deserialize(fs);
            }
            Buttons = new Button[4] { BtnA, BtnB, BtnC, BtnD };
            FillCells(allQuestions[step]);

            if (((bool?)Session[SessionKey5050]).GetValueOrDefault())
            {
                Btn5050.CssClass = "Btn5050Used";
                Btn5050.Enabled = false;
            }

            if (((bool?)Session[SessionKeyCall]).GetValueOrDefault())
            {
                BtnCall.CssClass = "BtnCallUsed";
                BtnCall.Enabled = false;
            }

            if (((bool?)Session[SessionKeyAsk]).GetValueOrDefault())
            {
                BtnAsk.CssClass = "BtnAskUsed";
                BtnAsk.Enabled = false;
            }

            {
                TblScores.Rows[15-step].Attributes.Add("class", "Red");
            }
            
        }

        

        protected void Btn5050_Click(object sender, EventArgs e)
        {
            Btn5050.CssClass = "Btn5050Used";
            Btn5050.Enabled = false;
            int number, number1;
            Fifty(out number, out number1);
            HoverButtons(number, number1);

            Session[SessionKey5050] = true;
        }

        protected void BtnCall_Click(object sender, EventArgs e)
        {

            BtnCall.Enabled = false;

            TxtMail.CssClass = "MailVisible";
            BtnSend.CssClass = "SendVisible";
            foreach (Button btn in Buttons)
            {
                btn.Enabled = false;
            }
            
        }

        protected void BtnAsk_Click(object sender, EventArgs e)
        {
            BtnAsk.CssClass = "BtnAskUsed";
            BtnAsk.Enabled = false;
            Session[SessionKeyAsk] = true;

            ClientScript.RegisterStartupScript(this.GetType(), "window.open", "window.open('https://www.google.com.ua/search?q=" + allQuestions[step].Quest + "')", true);
            
        }

        //private void ShowRightAnswer()
        //{
        //    switch (allQuestions[step].RightAnswer) 
        //    {
        //        case 0:
        //            BtnA.Attributes.Add("cssClass", "tableAnswerARight");
        //            break;
        //        case 1:
        //            BtnB.Attributes.Add("cssClass", "tableAnswerBRight");
        //            break;
        //        case 2:
        //            BtnC.Attributes.Add("cssClass", "tableAnswerCRight");
        //            break;
        //        case 3:
        //            BtnD.Attributes.Add("cssClass", "tableAnswerDRight");
        //            break;
        //    }
        //}

        protected void BtnA_Click(object sender, EventArgs e)
        {
            CheckAnswer(allQuestions[step], 0);
        }

        protected void BtnB_Click(object sender, EventArgs e)
        {
            CheckAnswer(allQuestions[step], 1);
        }

        protected void BtnC_Click(object sender, EventArgs e)
        {
            CheckAnswer(allQuestions[step], 2);
            
        }

        protected void BtnD_Click(object sender, EventArgs e)
        {
            CheckAnswer(allQuestions[step], 3);
        }

        private void FillCells(Question question)
        {
            BtnQuestion.Text = question.Quest;
            for (int i = 0; i < 4; i++) 
            {
                Buttons[i].Text = question.Answers[i];
            }

        }

        private void Fifty(out int button, out int button1)
        {
            int i = rnd.Next(0, 4);
            int j = rnd.Next(0, 4);
            if (((i != allQuestions[step].RightAnswer) && (j != allQuestions[step].RightAnswer) && (i != j)))
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

        private void ActiveSum(int i)
        {
            TblScores.Rows[15-i].Attributes.Add("class", "Red");
            TblScores.Rows[15-i+1].Attributes.Add("class", "tableCell");
            if ((i == 5) || (i == 10))
            {
                TblScores.Rows[15 - i + 1].Attributes.Add("class", "tableCellUnFired");
            }
        }

        private void EnableAllButtonsFalse() 
        {
            Btn5050.Enabled = false;
            BtnCall.Enabled = false;
            BtnAsk.Enabled = false;
            foreach (Button btn in Buttons) 
            {
                btn.Enabled = false;
            }
        }
        

        private void VisibleAnswersFalse() 
        {
            foreach (Button btn in Buttons)
            {
                btn.Visible = false;
            }
        }
        public void CheckAnswer(Question quest, int answerId)
        {
            
            if ((quest.RightAnswer == answerId) && (step != 14))
            {
                
                step += 1;
                FillCells(allQuestions[step]);
                ActiveSum(step);
                
            }
            else if ((quest.RightAnswer == answerId) && (step == 14))
            {
                GamеWin();
                
            }
            else
            {
                GameOver();
                
            }

            //ShowRightAnswer();
        }

        

        private void GameOver()
        {
            string result = "";
            TblScores.Rows[15 - step].Attributes.Add("class", "tableCell");
            if (step <= 4)
            {
                result = "Ви програли. Ваш виграш становить 0 грн.";
                TblScores.Rows[16].Attributes.Add("class", "Red");
                
            }

            else if ((step > 4) && (step <= 9))
            {
                result = "Ви програли. Ваш виграш становить 1000 грн.";
                TblScores.Rows[11].Attributes.Add("class", "Red");
            }

            else if ((step > 9) && (step <= 14))
            {
                result = "Ви програли. Ваш виграш становить 32000 грн.";
                TblScores.Rows[6].Attributes.Add("class", "Red");
            }

            BtnQuestion.Text = result;
            VisibleAnswersFalse();
            EnableAllButtonsFalse();

        }

        private void GamеWin()
        {
            BtnQuestion.Text = "Вітаємо! Ви заробили свій перший мільйон!";
            VisibleAnswersFalse();
            EnableAllButtonsFalse();
        }



        protected void BtnSend_Click(object sender, EventArgs e)
        {
            
            if (TxtMail.Text != "")
            {
                var fromAddress = new MailAddress("olzadorozhna@gmail.com", "Ольга");
                var toAddress = new MailAddress(TxtMail.Text, "Володя");

                const string fromPassword = "мій пароль";
                const string subject = "Допомога друга";
                string body = "Запитання: " + allQuestions[step].Quest + " Відповіді: A: " + allQuestions[step].Answers[0] +
                     ", B: " + allQuestions[step].Answers[1] + ", C: " + allQuestions[step].Answers[2] + ", D: " + allQuestions[step].Answers[0] + ". ";

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
                Session[SessionKeyCall] = true;
                BtnCall.CssClass = "BtnCallUsed";
                foreach (Button btn in Buttons)
                {
                    btn.Enabled = true;
                }
            }
            else
            {
                TxtMail.Text = "Потрібно ввести адресу";
            }

            
        }

        

        
    }
}