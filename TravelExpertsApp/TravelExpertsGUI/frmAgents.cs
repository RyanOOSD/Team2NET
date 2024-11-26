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
        bool isAdd = true;



        public frmAgents()
        {
            InitializeComponent();
        }

        private void frmAgents_Load(object sender, EventArgs e)
        {
            picAgencies.Image = Image.FromFile(rootDir + "\\Images\\Agencies.jpg");
            picAgents.Image = Image.FromFile(rootDir + "\\Images\\Agents.jpg");
            txtAgentID.Text = "Enter Agent ID";
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



        private void btnAgentAdd_Click(object sender, EventArgs e)
        {
            gbAgent.Visible = true;
            btnAgentAddSave.Enabled = true;
            btnAgentEdit.Enabled = false;
            btnAgentDelete.Enabled = false;
            selectedAgent = null;
            ClearAgent();
            LoadCities(cboAgentLocation);
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
            
            btnAgentEdit.Enabled = true;
            btnAgentDelete.Enabled = true;
            agentID = Convert.ToInt32(txtAgentID.Text);
            selectedAgent = AgentsDB.GetAgent(agentID);
            DisplayAgent(selectedAgent);
            MakeAgentReadOnly();
        }

        private void MakeAgentReadOnly()
        {
            txtFName.ReadOnly = true;
            txtLName.ReadOnly = true;
            txtMiddle.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtAgentPhone.ReadOnly = true;
            txtPosition.ReadOnly = true;
            cboAgentLocation.Enabled = false;
        }

        private void DisplayAgent(Agent selectedAgent)
        {

            if (selectedAgent != null)
            {
                txtAgentID.Text = selectedAgent.AgentId.ToString();
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

        private void LoadCities(ComboBox cboBox)
        {
            List<Agency> cityList = new List<Agency>();
            cityList = AgentsDB.GetCity();
            cboBox.DataSource = cityList;
            cboBox.DisplayMember = "AgncyCity";
            cboBox.ValueMember = "AgncyCity";
        }

        private void txtAgentID_Enter(object sender, EventArgs e)
        {
            txtAgentID.Clear();
        }

        private void btnAgentAddSave_Click(object sender, EventArgs e)
        {

            if (isAdd == true)
            {
                selectedAgent = new Agent();
                string selectedCity = cboAgentLocation.SelectedValue.ToString();
                PopulateAgentInfo();
                selectedAgent.AgencyId = null;
                AgentsDB.AddAgent(selectedAgent, selectedCity);
                MessageBox.Show("Agent has been added");
                DisplayAgent(selectedAgent);
                MakeAgentReadOnly();
            }

            if (isAdd == false)
            {
                PopulateAgentInfo();
                AgentsDB.ModifyAgent(selectedAgent.AgentId, selectedAgent);
                MessageBox.Show($"Agent Info Updated");
                MakeAgentReadOnly();
            }




            // testing add agent functionality
            //using (TravelExpertsContext db = new TravelExpertsContext())
            //{


            //    newAgent.AgencyId = db.Agencies.Where(a => a.AgncyCity == selectedCity).Select(a => a.AgencyId).SingleOrDefault();


            //}

            //testBox1.Text = newAgent.AgencyId.ToString();
            //testBox1.Text = cboAgentLocation.SelectedValue.ToString();
        }

        private void PopulateAgentInfo()
        {
            selectedAgent.AgtFirstName = txtFName.Text;
            selectedAgent.AgtLastName = txtLName.Text;
            selectedAgent.AgtMiddleInitial = txtMiddle.Text;
            selectedAgent.AgtBusPhone = txtAgentPhone.Text;
            selectedAgent.AgtEmail = txtEmail.Text;
            selectedAgent.AgtPosition = txtPosition.Text;
        }

        private void btnAgentDelete_Click(object sender, EventArgs e)
        {
            if (selectedAgent != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete Agent " +
                    $"{selectedAgent.AgtFirstName} {selectedAgent.AgtLastName}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AgentsDB.DeleteAgent(selectedAgent.AgentId);
                    MessageBox.Show("Agent has been deleted");
                    ClearAgent();
                    gbAgent.Visible = false;

                }
            }

        }

        private void btnAgentEdit_Click(object sender, EventArgs e)
        {
            MakeAgentNotReadOnly();
            isAdd = false;
        }

        private void MakeAgentNotReadOnly()
        {
            txtFName.ReadOnly = false;
            txtLName.ReadOnly = false;
            txtMiddle.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtAgentPhone.ReadOnly = false;
            txtPosition.ReadOnly = false;
            cboAgentLocation.Enabled = true;
        }
    }
}
