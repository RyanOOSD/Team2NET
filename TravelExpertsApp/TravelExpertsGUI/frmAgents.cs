using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        Agency? selectedAgency = null;
        int agentID = 0;
        string agencyCity;
        string rootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        bool isAdd = true;
        bool isAgencyAdd = true;
        string defaultText = "Enter Agent ID";
        string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True; TrustServerCertificate=true";



        public frmAgents()
        {
            InitializeComponent();
        }

        private void frmAgents_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(rootDir + "\\Images\\airplane.ico");
            picAgencies.Image = Image.FromFile(rootDir + "\\Images\\Agencies.jpg");
            picAgents.Image = Image.FromFile(rootDir + "\\Images\\Agents.jpg");

            txtAgentID.Text = defaultText;

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
            LoadCities(cboAgencyLocation);

            gbManageAgent.Visible = false;
            gbManageAgency.Visible = true;
            gbAgent.Visible = false;
            txtPostal.Text = AgenciesDB.LoadProvince();
            testBox1.Text = AgenciesDB.LoadProvince();


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
            selectedAgency = null;
            ClearAgency();
            txtProvince.Text = AgenciesDB.LoadProvince();
            MakeAgencyNotReadOnly();
        }

        private void ClearAgency()
        {
            txtAddress.Clear();
            txtCity.Clear();
            txtPostal.Clear();
            txtAgencyPhone.Clear();
            txtFax.Clear();
        }

        private void btnGetAgent_Click(object sender, EventArgs e)
        {
            string errorMessage = "Please Enter Valid Agent ID";
            if (
                ValidatorUtils.ValidateAgentID(txtAgentID, connectionString) &&
                ValidatorUtils.IsDefaultText(txtAgentID, defaultText, errorMessage)
                )
            {
                gbAgent.Visible = true;

                btnAgentEdit.Enabled = true;
                btnAgentDelete.Enabled = true;
                agentID = Convert.ToInt32(txtAgentID.Text);
                selectedAgent = AgentsDB.GetAgent(agentID);
                LoadCities(cboAgentLocation);
                DisplayAgent(selectedAgent);
                MakeAgentReadOnly();
            }

            
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
                cboAgentLocation.SelectedValue = AgentsDB.AgencyIDtoCity(selectedAgent.AgencyId);

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
            

            if (ValidatorUtils.IsTextBoxNotEmpty(txtFName, generateErrorMessage(txtFName)) &&
                ValidatorUtils.IsTextBoxNotEmpty(txtLName, generateErrorMessage(txtLName)) &&
                ValidatorUtils.IsTextBoxNotEmpty(txtAgentPhone, generateErrorMessage(txtAgentPhone)) &&
                ValidatorUtils.IsTextBoxNotEmpty(txtEmail, generateErrorMessage(txtEmail)) &&
                ValidatorUtils.IsTextBoxNotEmpty(txtPosition, generateErrorMessage(txtPosition))
                )

                
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
                    string selectedCity = cboAgentLocation.SelectedValue.ToString();
                    AgentsDB.ModifyAgent(selectedAgent.AgentId, selectedAgent, selectedCity);
                    MessageBox.Show($"Agent Info Updated");
                    MakeAgentReadOnly();
                } 
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

        private void btnGetAgency_Click(object sender, EventArgs e)
        {
            gbAgency.Visible = true;

            btnAgencyEdit.Enabled = true;
            btnAgencyDelete.Enabled = true;
            agencyCity = cboAgencyLocation.SelectedValue.ToString();
            selectedAgency = AgenciesDB.GetAgency(agencyCity);
            DisplayAgency(selectedAgency);
            MakeAgencyReadOnly();
            //testBox1.Text = agencyCity;
        }

        private void MakeAgencyReadOnly()
        {
            txtAddress.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtProvince.ReadOnly = true;
            txtPostal.ReadOnly = true;
            txtAgencyPhone.ReadOnly = true;
            txtFax.ReadOnly = true;
        }

        private void DisplayAgency(Agency selectedAgency)
        {
            if (selectedAgency != null)
            {
                txtAddress.Text = selectedAgency.AgncyAddress;
                txtProvince.Text = selectedAgency.AgncyProv;
                txtPostal.Text = selectedAgency.AgncyPostal;
                txtAgencyPhone.Text = selectedAgency.AgncyPhone;
                txtFax.Text = selectedAgency.AgncyFax;
                txtCity.Text = selectedAgency.AgncyCity;
            }
        }

        private void btnAgencyEdit_Click(object sender, EventArgs e)
        {
            MakeAgencyNotReadOnly();
            isAgencyAdd = false;
        }

        private void MakeAgencyNotReadOnly()
        {
            txtAddress.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtProvince.ReadOnly = false;
            txtPostal.ReadOnly = false;
            txtAgencyPhone.ReadOnly = false;
            txtFax.ReadOnly = false;
        }

        private void btnAddLocSave_Click(object sender, EventArgs e)
        {
            if (isAgencyAdd == true)
            {
                selectedAgency = new Agency();

                PopulateAgencyInfo();

                AgenciesDB.AddAgency(selectedAgency);
                MessageBox.Show("Agency has been added");
                LoadCities(cboAgencyLocation);
                DisplayAgency(selectedAgency);
                MakeAgencyReadOnly();
            }

            if (isAgencyAdd == false)
            {
                PopulateAgencyInfo();

                AgenciesDB.ModifyAgency(selectedAgency.AgencyId, selectedAgency);
                MessageBox.Show($"Agency Info Updated");
                MakeAgencyReadOnly();
            }

        }

        private void PopulateAgencyInfo()
        {
            selectedAgency.AgncyAddress = txtAddress.Text;
            selectedAgency.AgncyCity = txtCity.Text;
            selectedAgency.AgncyProv = txtProvince.Text;
            selectedAgency.AgncyPostal = txtPostal.Text;
            selectedAgency.AgncyPhone = txtAgencyPhone.Text;
            selectedAgency.AgncyFax = txtFax.Text;
        }

        private void btnAgencyDelete_Click(object sender, EventArgs e)
        {
            if (selectedAgency != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete Agency " +
                    $"{selectedAgency.AgncyCity}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AgenciesDB.DeleteAgency(selectedAgency.AgencyId);
                    MessageBox.Show("Agency has been deleted");
                    ClearAgency();
                    gbAgency.Visible = false;
                    LoadCities(cboAgencyLocation);

                }
            }

        }

        private string generateErrorMessage(TextBox textBox)
        {
            string errorMessage = $"{textBox.Tag} Field cannot be empty";
            return errorMessage;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
