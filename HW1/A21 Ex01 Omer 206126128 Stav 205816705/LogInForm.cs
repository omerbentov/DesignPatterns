using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A21_Ex01_Omer_206126128_Stav_205816705
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            initializeChildrenComponents();
        }

        private void initializeChildrenComponents()
        {
            setComponentsLocations();
        }

        private void setComponentsLocations()
        {
            WelcomeLable.Location = new Point(Width / 2 - WelcomeLable.Width / 2, (int)(Height * 0.3));
            LogInBtn.Location = new Point(Width / 2 - LogInBtn.Width / 2, (int)(Height * 0.6));
        }

        private void LogInBtn_Click(object sender, EventArgs e)
        {
            LoginResult result = FacebookService.Login(Global.AppId, 
                "user_photos", 
                "email", 
                "user_posts", 
                "user_events", 
                "user_birthday", 
                "user_events", 
                "user_hometown",
                "user_gender",
                "user_location",
                "groups_access_member_info");
            Global.User = result.LoggedInUser;
            this.Hide();
            MainFeed mainFeed = new MainFeed();
            mainFeed.Show();
        }

        private void LogInForm_SizeChanged(object sender, EventArgs e)
        {
            setComponentsLocations();
        }
    }
}
