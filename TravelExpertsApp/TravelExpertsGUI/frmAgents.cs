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
        // setting variables used by the program
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

        // method for when the form loads
        private void frmAgents_Load(object sender, EventArgs e)
        {
            Icon = Icon.ExtractAssociatedIcon(rootDir + "\\Images\\airplane.ico");
            picAgencies.Image = Image.FromFile(rootDir + "\\Images\\Agencies.jpg");
            picAgents.Image = Image.FromFile(rootDir + "\\Images\\Agents.jpg");

            txtAgentID.Text = defaultText;

        }

        // method to clear agentID field to make the form easier to use by users

        private void txtAgentID_Enter(object sender, EventArgs e)
        {
            txtAgentID.Clear();
        }

        // METHODS THAT ARE CALLED WHEN BUTTONS ARE CLICKED



        // method that is called when MANAGE AGENTS button is clicked
        private void btnManageAgents_Click(object sender, EventArgs e)
        {
            picAgencies.Visible = true;
            picAgencies.Image = Image.FromFile(rootDir + "\\Images\\Agents.jpg");
            picAgents.Visible = false;

            gbManageAgency.Visible = false;
            gbManageAgent.Visible = true;
            gbAgency.Visible = false;

        }

        // method that is called when MANAGE AGENCIES button is clicked
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

        // method that is called when ADD NEW AGENT button is clicked

        private void btnAgentAdd_Click(object sender, EventArgs e)
        {
            gbAgent.Visible = true;
            btnAgentAddSave.Enabled = true;
            btnAgentEdit.Enabled = false;
            btnAgentDelete.Enabled = false;
            selectedAgent = null;
            ClearAgent();
            LoadCities(cboAgentLocation);
            MakeAgentNotReadOnly();
        }

        // method that is called when ADD NEW AGENCY button is clicked

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

        // method that is called when GET AGENT button is clicked

        private void btnGetAgent_Click(object sender, EventArgs e)
        {
            string errorMessage = "Please Enter Valid Agent ID";
            if (ValidatorUtils.IsDefaultText(txtAgentID, defaultText, errorMessage) &&
                ValidatorUtils.ValidateAgentID(txtAgentID, connectionString))
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

        // method that is called when SAVE CHANGES button on AGENTS tab is clicked

        private void btnAgentAddSave_Click(object sender, EventArgs e)
        {
            if (ValidatorUtils.IsTextBoxNotEmpty(txtFName, errorMessageBlank(txtFName)) &&
                ValidatorUtils.IsTextBoxNotEmpty(txtLName, errorMessageBlank(txtLName)) &&
                ValidatorUtils.IsTextBoxNotEmpty(txtAgentPhone, errorMessageBlank(txtAgentPhone)) &&
                ValidatorUtils.IsTextBoxNotEmpty(txtEmail, errorMessageBlank(txtEmail)) &&
                ValidatorUtils.IsTextBoxNotEmpty(txtPosition, errorMessageBlank(txtPosition)) &&
                ValidatorUtils.IsValidPhoneNumberAgent(txtAgentPhone, errorMessagePhone(txtAgentPhone)) &&
                ValidatorUtils.IsValidEmail(txtEmail, "Email must be in format 'jsmith@example.com'") &&
                ValidatorUtils.IsTextBoxWithinMaxLength(txtFName, 20, errorMessageCharLimit(txtFName, 20)) &&
                ValidatorUtils.IsTextBoxWithinMaxLength(txtMiddle, 20, errorMessageCharLimit(txtMiddle, 5)) &&
                ValidatorUtils.IsTextBoxWithinMaxLength(txtPosition, 20, errorMessageCharLimit(txtPosition, 20)) &&
                ValidatorUtils.IsTextBoxWithinMaxLength(txtEmail, 50, errorMessageCharLimit(txtFName, 50))
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



            /* USED THIS LITTLE CODE BLOCK FOR DEBUGGING AN ISSUE THAT HAS BEEN RESOLVED
             * PLEASE DISREGARD                                                - KAZI
            // testing add agent functionality
            //using (TravelExpertsContext db = new TravelExpertsContext())
            //{


            //    newAgent.AgencyId = db.Agencies.Where(a => a.AgncyCity == selectedCity).Select(a => a.AgencyId).SingleOrDefault();


            //}

            //testBox1.Text = newAgent.AgencyId.ToString();
            //testBox1.Text = cboAgentLocation.SelectedValue.ToString();
            */
        }

        // method that is called when DELETE button on AGENTS tab is clicked

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

        // method that is called when EDIT button on AGENTS tab is clicked
        private void btnAgentEdit_Click(object sender, EventArgs e)
        {
            MakeAgentNotReadOnly();
            isAdd = false;
        }

        // method that is called when GET AGENCY button is clicked

        private void btnGetAgency_Click(object sender, EventArgs e)
        {
            gbAgency.Visible = true;

            btnAgencyEdit.Enabled = true;
            btnAgencyDelete.Enabled = true;
            agencyCity = cboAgencyLocation.SelectedValue.ToString();
            selectedAgency = AgenciesDB.GetAgency(agencyCity);
            DisplayAgency(selectedAgency);
            MakeAgencyReadOnly();

        }

        // method that is called when EDIT button on AGENCIES tab is clicked

        private void btnAgencyEdit_Click(object sender, EventArgs e)
        {
            MakeAgencyNotReadOnly();
            isAgencyAdd = false;
        }


        // method that is called when SAVE CHANGES button on AGENCIES tab is clicked
        private void btnAddLocSave_Click(object sender, EventArgs e)
        {
            if (ValidatorUtils.IsTextBoxNotEmpty(txtAddress, errorMessageBlank(txtAddress)) &&
                ValidatorUtils.IsTextBoxNotEmpty(txtPostal, errorMessageBlank(txtPostal)) &&
                ValidatorUtils.IsTextBoxNotEmpty(txtAgencyPhone, errorMessageBlank(txtAgencyPhone)) &&
                ValidatorUtils.IsValidPostalCode(txtPostal, "Postal Code in text box must be in correct format: 'A1A 1A1'") &&
                ValidatorUtils.IsValidPhoneNumber(txtAgencyPhone, errorMessagePhone(txtAgencyPhone)) &&
                ValidatorUtils.IsTextBoxWithinMaxLength(txtAddress, 50, errorMessageCharLimit(txtAddress, 50))

                )
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

        }

        // method that is called when DELETE button on AGENCIES tab is clicked

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

        // method that is called when CLOSE FORM button is clicked

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }



        // METHODS DEFINED BY ME (KAZI) TO MAKE THE PROGRAM FLOW BETTER

        // method used to load comboboxes with names of cities where the agencies are located

        private void LoadCities(ComboBox cboBox)
        {
            List<Agency> cityList = new List<Agency>();
            cityList = AgentsDB.GetCity();
            cboBox.DataSource = cityList;
            cboBox.DisplayMember = "AgncyCity";
            cboBox.ValueMember = "AgncyCity";
        }

        // PERTAINING TO AGENTS

        // method used to fetch agent info from db and display it on the form

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

        // method used to clear all fields on the Agents section

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

        // method used to make agent info READONLY i.e. uneditable

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

        // method to make agent info editable

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

        // method used to populate the object of selectedAgent with data entered by the user
        // this data is then sent to the db to add/edit agent info

        private void PopulateAgentInfo()
        {
            selectedAgent.AgtFirstName = txtFName.Text;
            selectedAgent.AgtLastName = txtLName.Text;
            selectedAgent.AgtMiddleInitial = txtMiddle.Text;
            selectedAgent.AgtBusPhone = txtAgentPhone.Text;
            selectedAgent.AgtEmail = txtEmail.Text;
            selectedAgent.AgtPosition = txtPosition.Text;
        }

        // PERTAINING TO AGENCIES

        // method used to fetch agency info from db and display it on the form

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

        // method used to clear all fields on the Agencies section

        private void ClearAgency()
        {
            txtAddress.Clear();
            txtCity.Clear();
            txtPostal.Clear();
            txtAgencyPhone.Clear();
            txtFax.Clear();
        }

        // method used to make agency info READONLY i.e. uneditable

        private void MakeAgencyReadOnly()
        {
            txtAddress.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtProvince.ReadOnly = true;
            txtPostal.ReadOnly = true;
            txtAgencyPhone.ReadOnly = true;
            txtFax.ReadOnly = true;
        }

        // method to make agency info editable

        private void MakeAgencyNotReadOnly()
        {
            txtAddress.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtProvince.ReadOnly = false;
            txtPostal.ReadOnly = false;
            txtAgencyPhone.ReadOnly = false;
            txtFax.ReadOnly = false;
        }

        // method used to populate the object of selectedAgency with data entered by the user
        // this data is then sent to the db to add/edit agency info

        private void PopulateAgencyInfo()
        {
            selectedAgency.AgncyAddress = txtAddress.Text;
            selectedAgency.AgncyCity = txtCity.Text;
            selectedAgency.AgncyProv = txtProvince.Text;
            selectedAgency.AgncyPostal = txtPostal.Text;
            selectedAgency.AgncyPhone = txtAgencyPhone.Text;
            selectedAgency.AgncyFax = txtFax.Text;
        }

        // ERROR MESSAGES

        // the following methods are used to generate error messages for form validation

        private string errorMessageBlank(TextBox textBox)
        {
            string errorMessage = $"{textBox.Tag} Field cannot be empty";
            return errorMessage;
        }

        private string errorMessagePhone(TextBox textBox)
        {
            string errorMessage = $"{textBox.Tag} must contain only numerical characters and have 10 digits";
            return errorMessage;
        }

        private string errorMessageCharLimit(TextBox textBox, int charLimit)
        {
            string errorMessage = $"{textBox.Tag} cannot have more than {charLimit} characters";
            return errorMessage;
        }
    }
}
