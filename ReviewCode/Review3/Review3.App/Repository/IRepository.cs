public interface IRepository
{
    void AddEmployee(Employee emp);
    Employee GetEmployeeById(int id);
    IEnumerable<Employee> SearchByDepartment(string department);
    IEnumerable<Employee> SearchByStatus(string status);
    void UpdateEmployee(Employee emp);
    void DeleteEmployee(int id);
    bool Exists(int id);
}