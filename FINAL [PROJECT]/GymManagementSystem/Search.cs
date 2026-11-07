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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();  // Set up form controls
        }

        // When search button is clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Members members = new Members();    // Create new member object
            members.MemberID = Convert.ToInt32(txtSearch.Text); // Get ID from input

            DataHandler handler = new DataHandler();    // Create handler

            // Use handler to get member data and display it in the DataGridView
            dataGridViewSearch.DataSource = handler.Search(members.MemberID);
        }

        // Exit button to close the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();   // Close search form
            }
        }
    }
}
