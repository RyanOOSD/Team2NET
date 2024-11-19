using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExpertsGUI
{
    public partial class frmAgents : Form
    {
        string rootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public frmAgents()
        {
            InitializeComponent();
        }

        private void frmAgents_Load(object sender, EventArgs e)
        {
            picAgencies.Image = Image.FromFile(rootDir + "\\Images\\Agencies.jpg");
            picAgents.Image = Image.FromFile(rootDir + "\\Images\\Agents.jpg");
            
            


        }

        private void btnManageAgents_Click(object sender, EventArgs e)
        {
            picAgencies.Visible = true;
            picAgencies.Image = Image.FromFile(rootDir + "\\Images\\Agents.jpg");
            picAgents.Visible = false;
            label1.Visible = true;
            txtAgentID.Visible = true;
            btnGetAgent.Visible = true;
            btnAgentAdd.Visible = true;
            label1OR.Visible = true;
            label2.Visible = false;
            cboAgencyLocation.Visible = false;
            btnGetAgency.Visible = false;
            btnAddLoc.Visible = false;
            label2OR.Visible = false;





        }

        private void btnManageAgencies_Click(object sender, EventArgs e)
        {
            picAgents.Visible = true;
            picAgents.Image = Image.FromFile(rootDir + "\\Images\\Agencies.jpg");
            picAgencies.Visible = false;
            label1.Visible = false;
            txtAgentID.Visible = false;
            btnGetAgent.Visible = false;
            btnAgentAdd.Visible = false;
            label1OR.Visible = false;
            label2.Visible = true;
            cboAgencyLocation.Visible = true;
            btnGetAgency.Visible = true;
            btnAddLoc.Visible = true;
            label2OR.Visible = true;
        }

        private static void ChangeVisibility(Label labelbox)
        {
            if (labelbox.Visible = true)
            {
                labelbox.Visible = false;
            } else { labelbox.Visible = true;}
            
            
        }
    }
}
