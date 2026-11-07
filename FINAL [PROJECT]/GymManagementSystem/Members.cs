using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementSystem
{
    // Defines a class to represent a gym member and store their details
    internal class Members
    {
        internal int MemberID { get; set; }         // Unique ID for each member
        internal string Name { get; set; }          // Member's first name
        internal string Surname { get; set; }       // Member's surname
        internal string Gender { get; set; }        // Gender
        internal DateTime DateOfBirth { get; set; } // Date of birth
        internal string Number { get; set; }        // Contact number
        internal string Email { get; set; }         // Email address
        internal DateTime JoinDate { get; set; }    // Date the member joined
        internal string MembershipType { get; set; }    // Type of membership (e.g., Monthly)
        internal string Status { get; set; }        // Active/Inactive, etc.

        public Members() { }
    }
}
