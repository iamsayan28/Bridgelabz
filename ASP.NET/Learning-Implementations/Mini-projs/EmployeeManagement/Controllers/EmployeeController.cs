using EmployeeManagement.Data;
using EmployeeManagement.Filters;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [LoginRequired]
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: /Employee/Index
        public IActionResult Index()
        {
            var employees = _employeeRepository.GetAllEmployees();

            ViewBag.PageTitle = "Employee List";
            ViewBag.TotalEmployees = employees.Count;
            ViewBag.LoggedInUser = HttpContext.Session.GetString("Username");

            return View(employees);
        }

        // GET: /Employee/Details/101
        public IActionResult Details(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            ViewBag.PageTitle = "Employee Details";
            return View(employee);
        }

        // GET: /Employee/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.PageTitle = "Add Employee";
            return View();
        }

        // POST: /Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            ViewBag.PageTitle = "Add Employee";

            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            _employeeRepository.AddEmployee(employee);
            TempData["Message"] = "Employee added successfully.";

            return RedirectToAction("Index");
        }

        // GET: /Employee/Edit/101
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }

            ViewBag.PageTitle = "Edit Employee";
            return View(employee);
        }

        // POST: /Employee/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
            ViewBag.PageTitle = "Edit Employee";

            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            _employeeRepository.UpdateEmployee(employee);
            TempData["Message"] = "Employee updated successfully.";

            return RedirectToAction("Index");
        }

        // POST: /Employee/Delete/101
        // The confirmation itself ("Are you sure...") happens client-side via jQuery
        // before this form ever submits (see wwwroot/js/site.js).
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            TempData["Message"] = "Employee deleted successfully.";

            return RedirectToAction("Index");
        }
    }
}
