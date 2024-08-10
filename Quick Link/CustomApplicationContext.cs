using QuickLink.Properties;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuickLink
{
    class CustomApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;

        private GlobalKeyboardHotkey hotkey = new GlobalKeyboardHotkey();

        private QuickInputForm QuickInputForm = new QuickInputForm();

        public CustomApplicationContext()
        {
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.QuickLinkIcon,
                Text = "Quick Link",
                ContextMenuStrip = new ContextMenuStrip()
                {
                    Items = {
                        new ToolStripMenuItem("SpiraPlan", null, ActionOpenSpiraPlan),
                        new ToolStripMenuItem("Exit", null, ActionExit),
                    }
                },
                Visible = true,

            };
            trayIcon.MouseClick += new MouseEventHandler(OnLeftClick);

            hotkey.KeyPressed += new EventHandler<KeyPressedEventArgs>((object sender, KeyPressedEventArgs e) => ShowQuickInputForm());
            hotkey.RegisterHotKey(ModifierKeys.Control | ModifierKeys.Win, Keys.R);
        }

        private void OnLeftClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowQuickInputForm();
            }
        }

        private void ShowQuickInputForm()
        {
            QuickInputForm.ShowAndInitialize();
        }

        private void ActionOpenSpiraPlan(object sender, EventArgs e)
        {
            Process.Start("https://safelog.spiraservice.net/1011/Requirement/Table.aspx");
        }

        void ActionExit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}