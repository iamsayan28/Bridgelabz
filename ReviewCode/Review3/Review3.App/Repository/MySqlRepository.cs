using MySqlConnector;
public class MySqlRepository : IRepository
{
    private readonly string _connectionString;

    public MySqlRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public bool Exists(int id)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT COUNT(1) FROM Employees WHERE EmployeeId = @Id";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }

    public void AddEmployee(Employee emp)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            string query = @"INSERT INTO Employees (EmployeeId, Name, Email, Department, Designation, Salary, JoiningDate, EmploymentType, Status)
                                 VALUES (@Id, @Name, @Email, @Dept, @Desig, @Salary, @Date, @Type, @Status)";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Dept", emp.Department);
                cmd.Parameters.AddWithValue("@Desig", emp.Designation);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@Date", emp.JoiningDate);
                cmd.Parameters.AddWithValue("@Type", emp.EmploymentType);
                cmd.Parameters.AddWithValue("@Status", emp.Status);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public Employee GetEmployeeById(int id)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Employees WHERE EmployeeId = @Id";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Employee(
                            Convert.ToInt32(reader["EmployeeId"]),
                            reader["Name"].ToString(),
                            reader["Email"].ToString(),
                            reader["Department"].ToString(),
                            reader["Designation"].ToString(),
                            Convert.ToDouble(reader["Salary"]),
                            Convert.ToDateTime(reader["JoiningDate"]),
                            reader["EmploymentType"].ToString(),
                            reader["Status"].ToString()
                        );
                    }
                }
            }
        }
        return null;
    }

    public IEnumerable<Employee> SearchByDepartment(string department)
    {
        var list = new List<Employee>();
        using (var conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Employees WHERE Department = @Dept";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Dept", department);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee(
                            Convert.ToInt32(reader["EmployeeId"]),
                            reader["Name"].ToString(),
                            reader["Email"].ToString(),
                            reader["Department"].ToString(),
                            reader["Designation"].ToString(),
                            Convert.ToDouble(reader["Salary"]),
                            Convert.ToDateTime(reader["JoiningDate"]),
                            reader["EmploymentType"].ToString(),
                            reader["Status"].ToString()
                        ));
                    }
                }
            }
        }
        return list;
    }

    public IEnumerable<Employee> SearchByStatus(string status)
    {
        var list = new List<Employee>();
        using (var conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT * FROM Employees WHERE Status = @Status";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Status", status);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Employee(
                            Convert.ToInt32(reader["EmployeeId"]),
                            reader["Name"].ToString(),
                            reader["Email"].ToString(),
                            reader["Department"].ToString(),
                            reader["Designation"].ToString(),
                            Convert.ToDouble(reader["Salary"]),
                            Convert.ToDateTime(reader["JoiningDate"]),
                            reader["EmploymentType"].ToString(),
                            reader["Status"].ToString()
                        ));
                    }
                }
            }
        }
        return list;
    }

    public void UpdateEmployee(Employee emp)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            string query = @"UPDATE Employees SET Name=@Name, Email=@Email, Department=@Dept, 
                                 Designation=@Desig, Salary=@Salary, JoiningDate=@Date, 
                                 EmploymentType=@Type, Status=@Status WHERE EmployeeId=@Id";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Email", emp.Email);
                cmd.Parameters.AddWithValue("@Dept", emp.Department);
                cmd.Parameters.AddWithValue("@Desig", emp.Designation);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@Date", emp.JoiningDate);
                cmd.Parameters.AddWithValue("@Type", emp.EmploymentType);
                cmd.Parameters.AddWithValue("@Status", emp.Status);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteEmployee(int id)
    {
        using (var conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            string query = "DELETE FROM Employees WHERE EmployeeId = @Id";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}