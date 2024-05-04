using AutoMapper;
using Company.BLL.Interfaces;
using Company.DAL.Entities;
using Company.PL.Helper;
using Company.PL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public IActionResult Index(string SearchValue = "")
        {
            IEnumerable<Employee> employees;
            IEnumerable<EmployeeViewModel> employeeViewModel;
            if (string.IsNullOrEmpty(SearchValue)) 
            { 
                employees = _unitOfWork.EmployeeRepository.GetAll();
                employeeViewModel = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            }
            else 
            { 
                employees = _unitOfWork.EmployeeRepository.Search(SearchValue);
                employeeViewModel = _mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
            }

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
    if (ModelState.IsValid)
    {
        if (employeeViewModel.Image != null && employeeViewModel.Image.Length > 0)
        {
            try
            {
               

                employeeViewModel.ImageUrl = DocumentSettings.UploadFile(employeeViewModel.Image, "Images");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Image", "An error occurred while uploading the image: " + ex.Message);
                return View(employeeViewModel);
            }
        }

        var employee = _mapper.Map<Employee>(employeeViewModel);
        _unitOfWork.EmployeeRepository.Add(employee);
        _unitOfWork.Complete();

        return RedirectToAction(nameof(Index));
    }

    ViewBag.Departments = _unitOfWork.DepartmentRepository.GetAll();
    return View(employeeViewModel);
}
        [HttpPost]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return NotFound();
            
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.EmployeeRepository.Update(employee);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(employee);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

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
                return RedirectToAction("Error", "Home");
            }
        }
    }
    // DTO==> Data Transfer Object
}
