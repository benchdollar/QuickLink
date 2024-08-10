using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using QuickLink.Properties;

namespace QuickLink
{
    public partial class QuickInputForm : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;

        private readonly string ticketPattern = @"^(rq|in)?(\d+)$";
        private enum TicketType { REQUIREMENT, INCIDENT };

        public QuickInputForm()
        {
            InitializeComponent();
            this.Deactivate += new System.EventHandler((object sender, EventArgs e) => Hide());
            this.KeyDown += new KeyEventHandler(OnEnterPressed);
            TextBox.KeyDown += new KeyEventHandler(OnEnterPressed);
            TextBox.Select();
            this.TopMost = true;
        }

        public void ShowAndInitialize()
        {
            Hide();
            Show();
            BringToFront();
            Activate(); // steal the global window focus
            TextBox.SelectAll();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void OnEnterPressed(object sender, KeyEventArgs e)
        {
            ProcessDialogKey(e.KeyData);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Console.WriteLine("Enter pressed");
                ActionGo();
            }
            if (keyData == Keys.Escape)
            {
                Hide();
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            ActionGo();
        }

        private void ActionGo()
        {
            if (CheckForValidTicketString())
            {
                OpenTicket(TextBox.Text);
                Hide();
            }
            else
            {
                TextBox.SelectAll();
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ShowGuessedTicketTypeImage();
        }

        private Boolean CheckForValidTicketString() => Regex.IsMatch(TextBox.Text.ToLower(), ticketPattern);

        private void ShowGuessedTicketTypeImage()
        {
            if (CheckForValidTicketString())
            {
                string input = TextBox.Text.ToLower();
                if (input.Length >= 2)
                {
                    string type = input.Substring(0, 2);
                    if (type.Equals("in"))
                    {
                        TicketIcon.Image = Resources.Incident;
                        TicketIcon.Visible = true;
                    }
                    else
                    {
                        TicketIcon.Image = Resources.Requirement;
                        TicketIcon.Visible = true;
                    }
                }
            }
            else
            {
                TicketIcon.Visible = true;
                TicketIcon.Image = Resources.app_icon_SpiraPlan_192x192;
            }
        }
        private string CreateSpiraUrl(TicketType ticketType, string projectId, string ticketId)
        {
            if (ticketType == TicketType.INCIDENT)
            {
                return String.Format("https://safelog.spiraservice.net/{0}/Incident/{1}/Overview.aspx", projectId, ticketId);
            }
            else
            {
                return String.Format("https://safelog.spiraservice.net/{0}/Requirement/{1}/Overview.aspx", projectId, ticketId);
            }

        }

        private void OpenTicket(string validatedTicketString)
        {
            TicketType ticketType = TicketType.REQUIREMENT;
            string number;
            if (validatedTicketString.Length >= 2)
            {
                string type = validatedTicketString.ToLower().Substring(0, 2);
                if (type.Equals("rq"))
                {
                    ticketType = TicketType.REQUIREMENT;
                    number = validatedTicketString.Substring(2);
                }
                else if (type.Equals("in"))
                {
                    ticketType = TicketType.INCIDENT;
                    number = validatedTicketString.Substring(2);

                }
                else
                {
                    number = validatedTicketString;
                }
            }
            else
            {
                number = validatedTicketString;
            }
            string url = CreateSpiraUrl(ticketType, "1011", number);
            Console.WriteLine("Opening {0}", url);
            Process.Start(url);
        }

    }
}
