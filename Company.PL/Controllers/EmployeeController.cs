using Company.BLL.Interfaces;
using Company.DAL.Entities;
using Company.PL.Helper;
using Company.PL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IUnitOfWork unitOfWork, ILogger<EmployeeController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(string searchValue = "")
        {
            try
            {
                var employees = string.IsNullOrEmpty(searchValue)
                    ? _unitOfWork.EmployeeRepository.GetAll()
                    : _unitOfWork.EmployeeRepository.Search(searchValue);

                var employeeViewModels = employees.Select(e => new EmployeeViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Address = e.Address,
                    Email = e.Email,
                    Salary = e.Salary,
                    isActive = e.isActive,
                    HireDate = e.HireDate,
                    ImageUrl = e.ImageUrl,
                    DepartmentId = e.DepartmentId
                }).ToList();

                return View(employeeViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

       [HttpGet]
public IActionResult Create()
{
    try
    {
      
       ViewBag.Departments = new SelectList(_unitOfWork.DepartmentRepository.GetAll(), "Id", "Name");
        return View(new EmployeeViewModel());
    }
    catch (Exception ex)
    {
        _logger.LogError(ex.Message);
        return RedirectToAction("Error", "Home");
    }
}


        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var mappedEmployee = new Employee
                    {
                        Name = employeeViewModel.Name,
                        Age = employeeViewModel.Age,
                        Address = employeeViewModel.Address,
                        Email = employeeViewModel.Email,
                        Salary = employeeViewModel.Salary,
                        isActive = employeeViewModel.isActive,
                        HireDate = employeeViewModel.HireDate,
                        DepartmentId= employeeViewModel.DepartmentId,
                        ImageUrl = employeeViewModel.ImageUrl
                    };

                    _unitOfWork.EmployeeRepository.Add(mappedEmployee);
                    _unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
               ViewBag.Departments = new SelectList(_unitOfWork.DepartmentRepository.GetAll(), "Id", "Name");

                    return View(employeeViewModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest();

                var employee = _unitOfWork.EmployeeRepository.GetById(id);

                if (employee == null)
                    return NotFound();

                var mappedEmployee = new EmployeeViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    isActive = employee.isActive,
                    HireDate = employee.HireDate,
                    ImageUrl = employee.ImageUrl,
                    DepartmentId = employee.DepartmentId
                };

                return View(mappedEmployee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest();

                var employee = _unitOfWork.EmployeeRepository.GetById(id);

                if (employee == null)
                    return NotFound();

                var departments = _unitOfWork.DepartmentRepository.GetAll();
                ViewBag.Departments = new SelectList(departments, "Id", "Name");

                var mappedEmployee = new EmployeeViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    isActive = employee.isActive,
                    HireDate = employee.HireDate,
                    ImageUrl = employee.ImageUrl,
                    DepartmentId = employee.DepartmentId
                };

                return View(mappedEmployee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Update(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var employee = _unitOfWork.EmployeeRepository.GetById(employeeViewModel.Id);

                    if (employee == null)
                        return NotFound();

                    employee.Name = employeeViewModel.Name;
                    employee.Age = employeeViewModel.Age;
                    employee.Address = employeeViewModel.Address;
                    employee.Email = employeeViewModel.Email;
                    employee.Salary = employeeViewModel.Salary;
                    employee.isActive = employeeViewModel.isActive;
                    employee.HireDate = employeeViewModel.HireDate;
                    employee.DepartmentId = employeeViewModel.DepartmentId;
                    employee.ImageUrl = employeeViewModel.ImageUrl;

                    _unitOfWork.EmployeeRepository.Update(employee);
                    _unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var departments = _unitOfWork.DepartmentRepository.GetAll();
                    ViewBag.Departments = new SelectList(departments, "Id", "Name");
                    return View(employeeViewModel);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest();

                var employee = _unitOfWork.EmployeeRepository.GetById(id);

                if (employee == null)
                    return NotFound();

                _unitOfWork.EmployeeRepository.Delete(employee);
                _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }
    }
}