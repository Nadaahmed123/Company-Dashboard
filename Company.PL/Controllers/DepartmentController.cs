using Company.BLL.Interfaces;
using Company.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Company.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Department());
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.DepartmentRepository.Add(department);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(department);
            }
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest();

                var department = _unitOfWork.DepartmentRepository.GetById(id);

                if (department == null)
                    return NotFound();

                return View(department);
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

                var department = _unitOfWork.DepartmentRepository.GetById(id);

                if (department == null)
                    return NotFound();

                return View(department);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.DepartmentRepository.Update(department);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(department);
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

                var department = _unitOfWork.DepartmentRepository.GetById(id);

                if (department == null)
                    return NotFound();

                _unitOfWork.DepartmentRepository.Delete(department);
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