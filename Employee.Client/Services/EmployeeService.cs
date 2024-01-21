using Employee.Common.Models;

namespace Employee.Client.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly HttpClient _http;

        public EmployeeService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<EmployeeDto>?> GetEmployees()
        {
            var data = await _http.GetFromJsonAsync<List<EmployeeDto>>("api/employee");
            return data;

        }
        public async Task<EmployeeDto?> GetEmployee(int id)
        {
            var data = await _http.GetFromJsonAsync<EmployeeDto>("api/employee/" + id);
            return data;
        }
        public async Task DeleteEmployee(int id)
        {
            await _http.DeleteAsync("api/employee/" + id);
        }
        public async Task PostEmployee(EmployeeDto employee)
        {
            await _http.PostAsJsonAsync("api/employee/", employee);
        }


    }
}
