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

}
