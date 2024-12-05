using Microsoft.Data.SqlClient;
using System;
using System.Text.RegularExpressions;

public class ValidatorUtils
{
    // Text Box Cannot Be Empty
    public static bool IsTextBoxNotEmpty(TextBox textBox, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(textBox.Text))
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    // Text Box Cannot Exceed a Certain Number of Characters
    public static bool IsTextBoxWithinMaxLength(TextBox textBox, int maxLength, string errorMessage)
    {
        if (textBox.Text.Length > maxLength)
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    // Text Box Must Contain Non-Negative Decimal
    public static bool IsNonNegativeDecimal(TextBox textBox, string errorMessage)
    {
        if (!decimal.TryParse(textBox.Text, out decimal value) || value < 0)
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    // Phone Number Validation
    public static bool IsValidPhoneNumber(TextBox textBox, string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(textBox.Text) || !textBox.Text.All(char.IsDigit) || textBox.Text.Length != 10)
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    // Email Address Validation
    public static bool IsValidEmail(TextBox textBox, string errorMessage)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(textBox.Text);
            if (addr.Address == textBox.Text)
            {
                return true;
            }
        }
        catch
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        return false;
    }

    // Combo Box Must Be Selected
    public static bool IsComboBoxSelected(ComboBox comboBox, string errorMessage)
    {
        if (comboBox.SelectedItem == null)
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    // Postal Code Validation
    public static bool IsValidPostalCode(TextBox textBox, string errorMessage)
    {
        if (!Regex.IsMatch(textBox.Text, @"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$"))
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    // DateTimePicker must have a selected date
    public static bool IsDateTimePickerSelected(DateTimePicker dateTimePicker, string errorMessage)
    {
        if (dateTimePicker.Value == null)
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    // DateTimePicker End Date is Not Earlier Than Start Date
    public static bool IsEndDateAfterStartDate(DateTimePicker startDatePicker, DateTimePicker endDatePicker, string errorMessage)
    {
        if (endDatePicker.Value < startDatePicker.Value)
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    // DateTimePicker Start Date is Not Earlier Than Today
    public static bool IsStartDateNotEarlierThanToday(DateTimePicker startDatePicker, string errorMessage)
    {
        if (startDatePicker.Value.Date < DateTime.Now.Date)
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }

    // AgentID Validation 
    public static bool ValidateAgentID(TextBox textBox, string connectionString)
    {
        // Check if AgentID textbox is empty 
        if (string.IsNullOrWhiteSpace(textBox.Text))
        {
            MessageBox.Show("Agent ID must be present.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        // Check if AgentID is a non-negative integer 
        if (!int.TryParse(textBox.Text, out int agentID) || agentID < 0)
        {
            MessageBox.Show("Agent ID must be a non-negative integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Check if AgentID exists in the database 
        if (!IsAgentIDInDatabase(agentID, connectionString))
        {
            MessageBox.Show($"Agent with ID {agentID} does not exist.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        return true;
    }

    private static bool IsAgentIDInDatabase(int agentID, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Agents WHERE AgentID = @AgentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AgentID", agentID);
                    int count = (int)command.ExecuteScalar();

                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    //Login Page Validation
    // Method to validate that the input is either numeric or a valid email 

<<<<<<< HEAD
    public static bool IsValidEmailOrAgentID(string input)
    {
        // Regular expression to match valid emails and numeric values 
        string pattern = @"^(\d+|[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$";
        return Regex.IsMatch(input, pattern);
    }
    // Method to validate that the password does not contain spaces 
    public static bool IsValidPassword(string input)
    {
        // Ensure the password does not contain spaces 
        return !input.Contains(" ");
    }

}
=======
    public static bool IsValidEmailOrAgentID(string input, string errorMessage)
    {
        // Regular expression to match valid emails and numeric values 
        string pattern = @"^(\d+|[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})$";
        if(!Regex.IsMatch(input, pattern))
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
        }
        return Regex.IsMatch(input, pattern);
    }
    // Method to validate that the password does not contain spaces 
    public static bool IsValidPassword(string input, string errorMessage)
    {
        // Ensure the password does not contain spaces
        if(input.Contains(" "))
        {
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return !input.Contains(" ");
    }

}
>>>>>>> 5f1bd18 (Added validations comments and reordered code)
