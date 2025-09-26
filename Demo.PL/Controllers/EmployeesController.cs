using AutoMapper;
using Demo.BLL.DataTransferObject;
using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeeServices employeeServices, ILogger<EmployeesController> logger, IWebHostEnvironment webHost,IMapper mapper) : Controller
    {
        [HttpGet]
        
        public IActionResult Index()
        {
            var emp = employeeServices.GetAll();
           
            return View(emp);
           
           
        }
        [HttpGet]
        public IActionResult Create()
        {

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