using AutoMapper;
using Demo.BLL.DataTransferObject;
using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.Arm;

namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeeServices employeeServices, ILogger<EmployeesController> logger, 
        IWebHostEnvironment webHost,IMapper mapper,IDepartmentServices services) : Controller
    {
        [HttpGet]
        
        public IActionResult Index(string Value)
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                var emp = employeeServices.GetAll();
                return View(emp);
            }
                return View(employeeServices.GetAll(Value));
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            var dep= services.GetAll();
            var select =new SelectList(dep,"Id","Name");
            ViewBag.Department= select;

            return View();

        }
        [HttpPost]
        public IActionResult Create(EmployeeRequest employee)
        {

            if (!ModelState.IsValid)
                return View(employee);

            try
            {

                var emp = employeeServices.Add(employee);
                if (emp > 0)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "cam,t");
            }
            catch (Exception ex)
            {
                if (webHost.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    logger.LogError("wrong", ex.Message);

            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var emp = employeeServices.GetById(id.Value);
            if (emp == null)
                return NotFound();

            return View(emp);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {


            if (!id.HasValue)
                return BadRequest();
            var emp = employeeServices.GetById(id.Value);
            if (emp == null)
                return NotFound();
            var dep = services.GetAll();
            var select = new SelectList(dep, "Id", "Name",emp.DepartmentId);
            ViewBag.Department = select;

            return View(mapper.Map<EmployeeUpdateRequest>(emp));

        }
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EmployeeUpdateRequest employee)
        {
            if (!id.HasValue)
                return BadRequest();
            if (id.Value != employee.Id)
                return BadRequest();
            if (!ModelState.IsValid)
                return View(employee);

            try
            {

                var emp = employeeServices.Update(employee);
                if (emp > 0)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "can,t");
            }
            catch (Exception ex)
            {
                if (webHost.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    logger.LogError("wrong", ex.Message);

            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {


            if (!id.HasValue)
                return BadRequest();
            var emp = employeeServices.GetById(id.Value);
            if (emp == null)
                return NotFound();

            return View(emp);

        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee = employeeServices.GetById(id.Value);
            try
            {

                var deleted = employeeServices.Delete(id.Value);
                if (deleted)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "cam,t");
            }
            catch (Exception ex)
            {
                if (webHost.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    logger.LogError("wrong", ex.Message);

            }
            return View(employee);

        }
    }
}