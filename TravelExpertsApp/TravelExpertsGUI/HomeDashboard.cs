using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExpertsGUI
{
    public partial class HomeDashboard : Form
    {
        public HomeDashboard()
        {
            InitializeComponent();
        }

        public HomeDashboard(UserSessionDetails UserInfo)
        {
            InitializeComponent();
            Debug.WriteLine(UserInfo.IsAdmin);

            if (!UserInfo.IsAdmin)
            {
                btnAgentsAndAgencies.Visible = false;
            }

        }
    }
}
