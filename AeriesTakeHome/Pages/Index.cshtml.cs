using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AeriesTakeHome.Pages
{
    public class IndexModel : PageModel
    { 
        public List<StudentInfo> listStudents = new List<StudentInfo>();
        public List<ContactInfo> listContacts = new List<ContactInfo>();
        public List<SelectedInfo> listSelected =new List<SelectedInfo>(); 
       
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=localhost;Initial Catalog=AeriesData;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Students";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StudentInfo studentInfo = new StudentInfo();
                                studentInfo.SchoolCode = "" + reader.GetInt32(0);
                                studentInfo.StudentID = reader.GetInt32(1);
                                studentInfo.FirstName = reader.GetString(2);
                                studentInfo.LastName = reader.GetString(3);
                                studentInfo.Address = reader.GetString(4);
                                studentInfo.City = reader.GetString(5);
                                studentInfo.State = reader.GetString(6);
                                studentInfo.ZipCode = reader.GetInt32(7);

                                listStudents.Add(studentInfo);
                            }
                        }
                    }

                    String sql_Contacts = "SELECT * FROM Contacts";
                    using(SqlCommand command = new SqlCommand(sql_Contacts, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                ContactInfo contactInfo = new ContactInfo();
                                contactInfo.Student_ID= reader.GetInt32(0);
                                contactInfo.FirstName=reader.GetString(1);
                                contactInfo.LastName=reader.GetString(2);
                                contactInfo.Relationship=reader.GetString(3);
                                contactInfo.Email=reader.GetString(4);
                                contactInfo.Mobile=reader.GetString(5);
                                contactInfo.Address=reader.GetString(6);
                                contactInfo.City=reader.GetString(7);
                                contactInfo.State=reader.GetString(8);
                                contactInfo.ZipCode=reader.GetInt32(9);
                               
                                listContacts.Add(contactInfo);
                            }
                        }
                    }
                   
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR" + ex.ToString());
            }
        }

        public void viewButton(object sender,EventArgs e)
        {
            Console.WriteLine("button clicked");

        }
      
        protected void buttonSelected( object sender,EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine(e.ToString(), "Button clicked");

              String connectionString = "Data Source=localhost;Initial Catalog=AeriesData;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                     String sql_Selected = "SELECT * FROM Contacts WHERE Student_ID =99400001";
                    using(SqlCommand command = new SqlCommand(sql_Selected, connection))
                    {
                        using(SqlDataReader reader=command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                SelectedInfo selectedInfo = new SelectedInfo();
                                selectedInfo.Student_ID= reader.GetInt32(0);
                                selectedInfo.FirstName=reader.GetString(1);
                                selectedInfo.LastName=reader.GetString(2);
                                selectedInfo.Relationship=reader.GetString(3);
                                selectedInfo.Email=reader.GetString(4);
                                selectedInfo.Mobile=reader.GetString(5);
                               selectedInfo.Address=reader.GetString(6);
                                selectedInfo.City=reader.GetString(7);
                                selectedInfo.State=reader.GetString(8);
                                selectedInfo.ZipCode=reader.GetInt32(9);
                                
                                listSelected.Add(selectedInfo);

                            }
                        }
                    }  

                }
            }
              catch (Exception ex)
            {
                Console.WriteLine("ERROR" + ex.ToString());
            }
        }

        public class StudentInfo
        {
            public string SchoolCode;
            public int StudentID;
            public string FirstName;
            public string LastName;
            public string Address;
            public string City;
            public string State;
            public int ZipCode;

        }

        public class ContactInfo
        {
            public int Student_ID;
            public string FirstName;
            public string LastName;
            public string Relationship;
            public string Email;
            public string Mobile;
            public string Address;
            public string City;
            public string State;
            public int ZipCode;
        }

        public class SelectedInfo
        {
            public int Student_ID;
            public string FirstName;
            public string LastName;
            public string Relationship;
            public string Email;
            public string Mobile;
            public string Address;
            public string City;
            public string State;
            public int ZipCode;
        }
    }
}

