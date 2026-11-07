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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();  // Set up form
        }

        // When delete button is clicked
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Members members = new Members();    // Create new member object
            members.MemberID = Convert.ToInt32(txtDelete.Text);     // Get ID from input

            DataHandler handler = new DataHandler();    // Create data handler
            handler.Delete(members.MemberID);   // Call delete method
        }

        // Exit button to close the form
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();   // Close form
            }
        }
    }
}
