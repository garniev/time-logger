using System;
using System.Windows.Forms;

namespace TimeLogger
{
    public partial class MainWindow : Form
    {
        private DateTime _currentDatetime;
        private const string DatetimeFormat = "yyyy-MM-dd HH:mm:ss";

        public MainWindow()
        {
            InitializeComponent();

            UpdateTime();

            var clock = new Timer {Interval = 1000};
            clock.Start();
            clock.Tick += Timer_Tick; 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            _currentDatetime = DateTime.Now;
            lblDateTime.Text = _currentDatetime.ToString(DatetimeFormat);
        }

        private void LogTime()
        {
            var timeStr = _currentDatetime.ToString(DatetimeFormat);
            var messageStr = txtMessage.Text;

            var loggerMsg = "";
            if (string.IsNullOrEmpty(messageStr))
            {
                loggerMsg = string.Format("{0}{1}", timeStr, Environment.NewLine);
                txtLogger.Text = loggerMsg + txtLogger.Text;
            }
            else
            {
                loggerMsg = string.Format("{0}.- {1}{2}", timeStr, messageStr, Environment.NewLine);
                txtLogger.Text = loggerMsg + txtLogger.Text;
                txtMessage.Text = string.Empty;
            }
            
        }

        private void btnLogTime_Click(object sender, EventArgs e)
        {
            LogTime();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ModifierKeys != Keys.Control)
            {
                e.SuppressKeyPress = true;
                LogTime();
            }
        }

    }
}
