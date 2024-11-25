using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertsData;

namespace TravelExpertsGUI
{
    public partial class frmAgents : Form
    {
        Agent? selectedAgent = null;
        int agentID = 0;
        string rootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

        public frmAgents()
        {
            InitializeComponent();
        }

        private void frmAgents_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(rootDir + "\\Images\\airplane.ico");
            picAgencies.Image = Image.FromFile(rootDir + "\\Images\\Agencies.jpg");
            picAgents.Image = Image.FromFile(rootDir + "\\Images\\Agents.jpg");




        }

        private void btnManageAgents_Click(object sender, EventArgs e)
        {
            picAgencies.Visible = true;
            picAgencies.Image = Image.FromFile(rootDir + "\\Images\\Agents.jpg");
            picAgents.Visible = false;

            gbManageAgency.Visible = false;
            gbManageAgent.Visible = true;
            gbAgency.Visible = false;






        }

        private void btnManageAgencies_Click(object sender, EventArgs e)
        {
            picAgents.Visible = true;
            picAgents.Image = Image.FromFile(rootDir + "\\Images\\Agencies.jpg");
            picAgencies.Visible = false;

            gbManageAgent.Visible = false;
            gbManageAgency.Visible = true;
            gbAgent.Visible = false;


        }

        

        private void btnAgentAdd_Click(object sender, EventArgs e)
        {
            gbAgent.Visible = true;
            btnAgentAddSave.Enabled = true;
            btnAgentEdit.Enabled = false;
            btnAgentDelete.Enabled = false;
            selectedAgent = null;
            ClearAgent();
            LoadCities();
        }

        

        private void btnAddLoc_Click(object sender, EventArgs e)
        {
            gbAgency.Visible = true;
            btnAddLocSave.Enabled = true;
            btnAgencyEdit.Enabled = false;
            btnAgencyDelete.Enabled = false;
        }

        private void btnGetAgent_Click(object sender, EventArgs e)
        {
            gbAgent.Visible = true;
            btnAgentAddSave.Enabled = false;
            btnAgentEdit.Enabled = true;
            btnAgentDelete.Enabled = true;
            agentID = Convert.ToInt32(txtAgentID.Text);
            selectedAgent = AgentsDB.GetAgent(agentID);
            DisplayAgent(selectedAgent);

        }

        private void DisplayAgent(Agent selectedAgent)
        {
            
            if (selectedAgent != null)
            {
                txtFName.Text = selectedAgent.AgtFirstName;
                txtMiddle.Text = selectedAgent.AgtMiddleInitial;
                txtLName.Text = selectedAgent.AgtLastName;
                txtAgentPhone.Text = selectedAgent.AgtBusPhone;
                txtEmail.Text = selectedAgent.AgtEmail;
                txtPosition.Text = selectedAgent.AgtPosition;
            }
        }

        private void ClearAgent()
        {
            txtFName.Clear();
            txtLName.Clear();
            txtMiddle.Clear();
            txtEmail.Clear();
            txtAgentPhone.Clear();
            txtPosition.Clear();
            txtAgentID.Clear();
        }

        private void LoadCities()
        {
            List<Agency> cityList = new List<Agency>();
            cityList = AgentsDB.GetCity();
            cboAgentLocation.DataSource = cityList;
            cboAgentLocation.DisplayMember = "AgncyCity";
        }
    }
}
