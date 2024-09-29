using AutoMapper;
using Company.BLL.Interfaces;
using Company.DAL.Entities;
using Company.PL.Helper;
using Company.PL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Company.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IActionResult Index(string searchValue = "")
        {
            var employees = string.IsNullOrEmpty(searchValue)
                ? _unitOfWork.EmployeeRepository.GetAll()
                : _unitOfWork.EmployeeRepository.Search(searchValue);

            var employeeViewModel = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            return View(employeeViewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(new EmployeeViewModel());
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
                return View(employeeViewModel);
            }

            try
            {
                if (employeeViewModel.Image?.Length > 0)
                {
                    employeeViewModel.ImageUrl = DocumentSettings.UploadFile(employeeViewModel.Image, "Image");
                }

                var employee = _mapper.Map<Employee>(employeeViewModel);
                _unitOfWork.EmployeeRepository.Add(employee);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred while creating the employee: {ex.Message}");
            }

            ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(employeeViewModel);
        }

        // Other methods (Update, Delete) remain unchanged...
    }
}