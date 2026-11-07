using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagementSystem
{
    // Internal class to handle SQL Server operations
    internal class DataHandler
    {
        // Empty constructor
        public DataHandler() { }

        // Connection string to connect to local SQL Server instance and GymDB
        public static string connectionString = @"Server=.\SQLEXPRESS;Database=GymDB;Trusted_Connection=True;";

        // Declare SQL objects
        SqlConnection con;
        SqlCommand command;
        SqlDataAdapter adapt;

        // Register method inserts a new member record into the database
        public void Register(int mID, string n, string s, string g, DateTime dob, string num, string e, DateTime jb, string mt, string st)
        {
            // Create insert query
            string query = "INSERT INTO Members VALUES (@MemberID, @Name, @Surname, @Gender, @DOB, @Number, @Email, @JoinDate, @MembershipType, @Status)";
            command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@MemberID", mID);
            command.Parameters.AddWithValue("@Name", n);
            command.Parameters.AddWithValue("@Surname", s);
            command.Parameters.AddWithValue("@Gender", g);
            command.Parameters.AddWithValue("@DOB", dob);
            command.Parameters.AddWithValue("@Number", num);
            command.Parameters.AddWithValue("@Email", e);
            command.Parameters.AddWithValue("@JoinDate", jb);
            command.Parameters.AddWithValue("@MembershipType", mt);
            command.Parameters.AddWithValue("@Status", st);

            // Initialize connection
            con = new SqlConnection(connectionString);

            // Open connection
            con.Open();

            // Prepare SQL command
            command = new SqlCommand(query, con);

            try
            {
                command.ExecuteNonQuery();  // Run the query
                MessageBox.Show("Details Saved");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Details Not Saved" + ex.Message);  // Show error if any
            }
            finally
            {
                con.Close();    // Always close connection
            }
        }

        // Update method modifies existing member data
        public void Update(int mID, string n, string s, string g, DateTime dob, string num, string e, DateTime jb, string mt, string st)
        {
            string query = $"UPDATE Members SET [MemberID] = '{mID}', [Name] = '{n}', [Surname] = '{s}', [Gender] = '{g}' , [DateOfBirth] = '{dob}' , [Number] = '{num}', " +
                $"[Email] = '{e}' , [JoinDate] = '{jb}' , [MembershipType] = '{mt}' , [Status] = '{st}' WHERE [MemberID] = '{mID}'" ;

            con = new SqlConnection(connectionString);

            con.Open();

            command = new SqlCommand(query, con);

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Details Updated");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Details Not Updated" + ex.Message);
            }
            finally
            {

            con.Close(); 
            }
        }

        // Delete a member by ID
        public void Delete(int mID)
        {
            string query = $"DELETE FROM Members WHERE MemberID = '{mID}'";

            con = new SqlConnection(connectionString);

            con.Open();

            command = new SqlCommand(query, con);

            try
            {
                command.ExecuteNonQuery();  // Delete record
                MessageBox.Show("Details deleted");

            }
            catch( Exception ex)
            {
                MessageBox.Show("Details Not Deleted" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        // Search for a member by ID and return the result as a DataTable
        public DataTable Search(int mID)
        {
            string query = $"SELECT * FROM Members WHERE MemberID = '{mID}';";

            con = new SqlConnection(connectionString);
            adapt = new SqlDataAdapter(query, con);

            DataTable table = new DataTable();

            adapt.Fill(table);  // Fill table with result

            return table;
        }

        
    }
}
