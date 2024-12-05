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
            _context = new TravelExpertsContext();

            SetupButtonStyles(); // Initialize button styling
            txtBoxPassword.UseSystemPasswordChar = true; // Set password text box to hide characters
            picBoxLogo.Image = TravelExpertsGUI.Properties.Resources.appLogo1; // Set the application logo
            picBoxPassword.Image = Properties.Resources.eye_open; // Default password visibility icon

            this.KeyPreview = true; // Allow form to capture key presses
            this.KeyDown += FrmLogin_KeyDown; // Bind Enter key press handler
        }

        #region UI Event Handlers

        // Handle Enter key to trigger login
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin_Click(sender, e);
            }
        }

        // Toggle password visibility on clicking the eye icon
        private void picBoxPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            picBoxPassword.Image = passwordVisible ? Properties.Resources.eye_closed : Properties.Resources.eye_open;
            txtBoxPassword.UseSystemPasswordChar = !passwordVisible;
        }

        // Change button appearance on mouse hover
        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = ColorTranslator.FromHtml("#234165"); // Background color
            btnLogin.ForeColor = Color.White;                        // Text color
            btnLogin.FlatAppearance.BorderColor = Color.White;       // Border color
        }

        // Revert button appearance on mouse leave
        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = SystemColors.Control;               // Default background color
            btnLogin.ForeColor = SystemColors.ControlText;           // Default text color
            btnLogin.FlatAppearance.BorderColor = Color.Gray;        // Default border color
        }

        #endregion

        #region Core Functionality

        // Handle the login button click
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txtBoxUsername.Text.Trim();
            string Password = txtBoxPassword.Text;

            // Validate user inputs
            if (ValidatorUtils.IsValidEmailOrAgentID(UserName, "Username doesn't match email pattern or is not an agent ID") &&
                ValidatorUtils.IsValidPassword(Password, "Password must not contain spaces") &&
                ValidatorUtils.IsTextBoxNotEmpty(txtBoxUsername, "Username must contain some value") &&
                ValidatorUtils.IsTextBoxNotEmpty(txtBoxPassword, "Password should not be empty"))
            {
                try
                {
                    // Check if user exists in the database
                    var LoggedInAgent = await _context.Agents.Include(a => a.UserLogin)
                        .FirstOrDefaultAsync(a => (a.AgtEmail == UserName || Convert.ToString(a.AgentId) == UserName));

                    if (LoggedInAgent == null || LoggedInAgent.UserLogin == null)
                    {
                        MessageBox.Show("Invalid email or password.");
                        return;
                    }

                    // Hash the input password
                    byte[] hashedInputPassword = HashPassword(Password);
                    byte[] hashedPassword = LoggedInAgent.UserLogin.HashedPassword;

                    // Compare hashed passwords
                    if (hashedPassword.SequenceEqual(hashedInputPassword))
                    {
                        UserSession.Login(LoggedInAgent.AgentId, LoggedInAgent.AgtEmail, LoggedInAgent.UserLogin.IsAdmin); // Set user session
                        RedirectMainMenu(); // Redirect to dashboard
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
        }

        // Redirect user to the main menu/dashboard
        private void RedirectMainMenu()
        {
            var dashboard = new HomeDashboard(UserSession.GetCurrentSession());
            this.Hide();
            dashboard.ShowDialog();
        }

        // Hash the password using SHA512
        private byte[] HashPassword(string password)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        #endregion

        #region UI Setup

        // Set up button styles and event handlers
        private void SetupButtonStyles()
        {
            btnLogin.MouseEnter += BtnLogin_MouseEnter;
            btnLogin.MouseLeave += BtnLogin_MouseLeave;

            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 1;
            btnLogin.FlatAppearance.BorderColor = Color.Gray;
        }

        #endregion
    }
}
