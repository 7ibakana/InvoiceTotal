using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try /*try and catch error to try the code and if there is an exception, catch it and
			present a messagebox with an error for user to fix what was entered*/
            {
                if (IsValidData())
                {
                    decimal subtotal = Convert.ToDecimal(txtSubtotal.Text); //Converts subtotal text into a decimal
                    decimal discountPercent = 0m; //a decimal value
                    if (subtotal >= 500) //if the subtotal entered is greater or equal to 500 then the percentage off is 20 percent
                    {
                        discountPercent = .2m;
                    }
                    else if (subtotal >= 250 && subtotal < 500) //if the subtotal entered is 250 and less than 500 then the percentage off is 15 percent
                    {
                        discountPercent = .15m;
                    }
                    else if (subtotal >= 100 && subtotal < 250) //if the subtotal entered is 100 and less than 250 then the percentage off is 10 percent
                    {
                        discountPercent = .1m;
                    }
                    decimal discountAmount = subtotal * discountPercent; //the discount amount is the subtotal multiplied by discount percentage off
                    decimal invoiceTotal = subtotal - discountAmount; //the invoice total is the subtotal minus the discount amount

                    txtDiscountPercent.Text = discountPercent.ToString("p1");//formats the discountpercent text to a percent format with 1 decimal place
                    txtDiscountAmount.Text = discountAmount.ToString("c"); //formats the discountamount to a currency format
                    txtTotal.Text = invoiceTotal.ToString("c"); //formats the invoicetotal value into a currency format

                    txtSubtotal.Focus(); //moves the focus to the subtotal text box where the outcome will be
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid number for the Subutotal field", "Entry Error");
            }
        }
        public bool IsValidData() //validates data
        {
            return
                IsPresent(txtSubtotal, "Subtotal") &&
                IsWithinRange(txtSubtotal, "Subtotal", 0, 10000);
        }
        public bool IsPresent(TextBox textBox, string name) //validates the error that will show up with subtotal field is not present
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }
        public bool IsWithinRange(TextBox textBox, string name, decimal min, decimal max) //Validation for a range of numbers
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min + " and " + max + ".", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }


        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

