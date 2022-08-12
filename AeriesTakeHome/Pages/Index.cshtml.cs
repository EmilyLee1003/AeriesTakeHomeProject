using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AeriesTakeHome.Pages
{
    public class IndexModel : PageModel
    {
        public List<StudentInfo> listStudents = new List<StudentInfo>();
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
    }
}