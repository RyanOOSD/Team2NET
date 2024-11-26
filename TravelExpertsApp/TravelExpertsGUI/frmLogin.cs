using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;

namespace TravelExpertsGUI
{
    public partial class frmLogin : Form
    {
        private bool passwordVisible = false;
        private TravelExpertsContext _context;
        public frmLogin()
        {
            InitializeComponent();
            SetupButtonStyles();
            _context = new TravelExpertsContext();
            txtBoxPassword.UseSystemPasswordChar = true;
            picBoxLogo.Image = TravelExpertsGUI.Properties.Resources.appLogo1;
            picBoxPassword.Image = Properties.Resources.eye_open;

            this.KeyPreview = true; // Allow the form to capture key presses
            this.KeyDown += FrmLogin_KeyDown;

        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; 
                btnLogin_Click(sender, e);
            }
        }

        private void SetupButtonStyles()
        {
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;

            // Set the default border style
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 1;
            btnLogin.FlatAppearance.BorderColor = Color.Gray;
        }

        private void picBoxPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            picBoxPassword.Image = passwordVisible ? Properties.Resources.eye_closed : Properties.Resources.eye_open;
            txtBoxPassword.UseSystemPasswordChar = !passwordVisible;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtBoxUsername.Text.Trim();
            string Password = txtBoxPassword.Text;

            try
            {
                var LoggedInAgent = await _context.Agents.Include(a => a.UserLogin).FirstOrDefaultAsync(a => (a.AgtEmail == UserName || Convert.ToString(a.AgentId) == UserName));

                if (LoggedInAgent == null || LoggedInAgent.UserLogin == null)
                {
                    MessageBox.Show("Invalid email or password.");
                    return;
                }

                byte[] hashedInputPassword = HashPassword(Password);


                byte[] hashedPassword = LoggedInAgent.UserLogin.HashedPassword;
                if (hashedPassword.SequenceEqual(hashedInputPassword))
                {
                    // Set user session
                    UserSession.Login(LoggedInAgent.AgentId, LoggedInAgent.AgtEmail, LoggedInAgent.UserLogin.IsAdmin);
                    RedirectMainMenu();
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private byte[] HashPassword(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
                return hashBytes;
            }
        }

        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = ColorTranslator.FromHtml("#234165"); // Background color
            btnLogin.ForeColor = Color.White;                        // Text color
            btnLogin.FlatAppearance.BorderColor = Color.White;       // Border color
        }

        // Event handler to revert changes (MouseLeave)
        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = SystemColors.Control;               // Default background color
            btnLogin.ForeColor = SystemColors.ControlText;           // Default text color
            btnLogin.FlatAppearance.BorderColor = Color.Gray;        // Default border color
        }

        private void RedirectMainMenu()
        {
            var dashboard = new HomeDashboard(UserSession.GetCurrentSession());
            this.Hide();
            dashboard.ShowDialog();
        }
    }
}
