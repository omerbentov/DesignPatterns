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
    public partial class LoginForm : Form
    {
        private User m_LoggedInUser;
        private LoginResult m_LoginResult;

        public LoginForm()
        {
            InitializeComponent();

            FacebookWrapper.FacebookService.s_CollectionLimit = 200;
            FacebookWrapper.FacebookService.s_FbApiVersion = 2.8f;

            // if app settings was initialized then it will load from file and set
            // all the setting of the data form
            try
            {
                m_AppSettings = AppSettings.LoadFromFile();
            }
            catch (Exception e)
            {
                m_AppSettings = new AppSettings();
                MessageBox.Show("Sorry, there was a problem loading saved App Settings");
            }

            this.rememberMeCheckBox.Checked = m_AppSettings.RememberUser;
        }

        private void loginAndInit()
        {
            try
            {
                m_LoginResult = FacebookService.Login(" 1556806451170375",
                "public_profile",
                "email",
                "publish_to_groups",
                "user_birthday",
                "user_age_range",
                "user_gender",
                "user_link",
                "user_tagged_places",
                "user_videos",
                "publish_to_groups",
                "groups_access_member_info",
                "user_friends",
                "user_events",
                "user_likes",
                "user_location",
                "user_photos",
                "user_posts",
                "user_hometown"
                );

                if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
                {
                    m_LoggedInUser = m_LoginResult.LoggedInUser;
                    MessageBox.Show("You are logged in");

                    // if the previous and current login sessions were without remember me checked and
                    // then set to deafult setting and save to file 
                    if (!this.rememberMeCheckBox.Checked && !m_AppSettings.RememberUser)
                    {
                        this.m_AppSettings.SetDefaultSettings();
                    }
                    // update remember user field in app settings for next login session
                    else
                    {
                        this.m_AppSettings.RememberUser = true;
                        this.m_AppSettings.SaveToFile();
                    }

                    m_Form2 = new DataForm(m_LoggedInUser, m_AppSettings, m_LoginResult);
                    this.Hide();
                    m_Form2.ShowDialog();

                    // auto logout if user dosen't check remember me box
                    if (!this.rememberMeCheckBox.Checked)
                    {
                        try
                        {
                            this.m_AppSettings.SetDefaultSettings();
                            FacebookWrapper.FacebookService.Logout(new Action(logout));
                        }

                        catch (Exception err)
                        {
                            MessageBox.Show("There is a problem- you are not logged out");
                        }
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(m_LoginResult.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            loginAndInit();
        }

        private void logout()
        {
            this.Close();
        }
    }
}
