using AutoMapper;
using Company.BLL.Interfaces;
using Company.DAL.Entities;
using Company.PL.Helper;
using Company.PL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Company.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IMapper mapper;

        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitofwork = unitOfWork;
            this.mapper = mapper;
        }
        public IActionResult Index(String SearchValue = "")
        {
            IEnumerable<Employee> employees;
            IEnumerable<EmployeeViewModel> employeeViewModel;
            if (string.IsNullOrEmpty(SearchValue)) { 
            employees = _unitofwork.EmployeeRepository.GetAll();
            employeeViewModel = mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
        }



            else { 
                employees = _unitofwork.EmployeeRepository.Search(SearchValue);
            employeeViewModel = mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
        }

         return View(employeeViewModel);
           
        }
        public IActionResult Create()
        {
            ViewBag.Departments = _unitofwork.DepartmentRepository.GetAll();
            return View(new EmployeeViewModel());
        }

        
             
    [HttpPost]
public IActionResult Create(EmployeeViewModel employeeViewModel)
{
    try
    {
        if (ModelState.IsValid)
        {
            // Map the view model to the entity
            var employee = mapper.Map<Employee>(employeeViewModel);

            // Upload the image and set the ImageUrl property
            employee.ImageUrl = DocumentSettings.UploadFile(employeeViewModel.Image, "Images");

            // Add the employee to the repository
            _unitofwork.EmployeeRepository.Add(employee);

            // Save changes to the database
            _unitofwork.Complete();

            // Redirect to the index action
            return RedirectToAction(nameof(Index));
        }

        // If model state is not valid, reload the create view with validation errors
        ViewBag.Departments = _unitofwork.DepartmentRepository.GetAll();
        return View(employeeViewModel);
    }
    catch (Exception ex)
    {
        // Log the exception
        ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again or contact support.");

        // Return the create view with an error message
        ViewBag.Departments = _unitofwork.DepartmentRepository.GetAll();
        return View(employeeViewModel);
    }
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
                    _unitofwork.EmployeeRepository.Update(employee);
                    _unitofwork.Complete();
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

                var employee = _unitofwork.EmployeeRepository.GetById(id);

                if (employee == null)
                    return NotFound();

                _unitofwork.EmployeeRepository.Delete(employee);
                _unitofwork.Complete();


                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return RedirectToAction("Error", "Home");
            }
        }
    }
    //DTO==> Data Transfer Object
}
