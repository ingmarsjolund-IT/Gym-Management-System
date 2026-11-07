using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    public partial class Form1 : Form
    {
        // Constructor for initializing the form
        public Form1()
        {
            InitializeComponent();  // Set up form controls
        }
        // Create an instance of the data handler class
        DataHandler handler = new DataHandler();

        // Create a new Members object to store user input
        Members members = new Members();

        // When Register button is clicked
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Assign user input from text boxes and date pickers to members object
            members.MemberID = Convert.ToInt32(txtMemberID.Text);
            members.Name = txtName.Text;
            members.Surname = txtSurname.Text;
            members.Gender = txtGender.Text;
            members.DateOfBirth = dateTimePickerDOB.Value;
            members.Number = txtNumber.Text;
            members.Email = txtEmail.Text;
            members.JoinDate = dateTimePickerJD.Value;
            members.MembershipType = txtMT.Text;
            members.Status = txtStatus.Text;

            // Pass the member data to the handler's Register method to save to DB
            handler.Register(members.MemberID, members.Name, members.Surname, members.Gender, members.DateOfBirth, members.Number, members.Email, members.JoinDate, members.MembershipType, members.Status);
        }

        // When Update button is clicked
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update the members object with the latest input
            members.MemberID = Convert.ToInt32(txtMemberID.Text);
            members.Name = txtName.Text;
            members.Surname = txtSurname.Text;
            members.Gender = txtGender.Text;
            members.DateOfBirth = dateTimePickerDOB.Value;
            members.Number = txtNumber.Text;
            members.Email = txtEmail.Text;
            members.JoinDate = dateTimePickerJD.Value;
            members.MembershipType = txtMT.Text;
            members.Status = txtStatus.Text;

            // Call the update method to save changes
            handler.Update(members.MemberID, members.Name, members.Surname, members.Gender, members.DateOfBirth, members.Number, members.Email, members.JoinDate, members.MembershipType, members.Status);
        }

        // Open Search form
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();   // Show the Search window
        }

        // Open Delete form
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete d = new Delete();
            d.Show();   // Show the Delete window
        }

        // Exit button: asks for confirmation before closing the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();   // Closes the form
            }

        }
    }
}
