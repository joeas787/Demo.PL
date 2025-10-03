using AutoMapper;
using Demo.BLL.DataTransferObject;
using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace Demo.PL.Controllers
{
    public class EmployeesController(IEmployeeServices employeeServices, ILogger<EmployeesController> logger, 
        IWebHostEnvironment webHost,IMapper mapper,IDepartmentServices services) : Controller
    {
        [HttpGet]
        
        public async Task<IActionResult> Index(string Value)
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                var emp = await employeeServices.GetAllAsync();
                return View(emp);
            }
                return  View(await employeeServices.GetAllAsync(Value));
           
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var dep= await services.GetAllAsync();
            var select =new SelectList(dep,"Id","Name");
            ViewBag.Department= select;

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequest employee)
        {

            if (!ModelState.IsValid)
                return View(employee);

            try
            {

                var emp =await employeeServices.AddAsync(employee);
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
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var emp = await employeeServices.GetByIdAsync(id.Value);
            if (emp == null)
                return NotFound();

            return View(emp);

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {


            if (!id.HasValue)
                return BadRequest();
            var emp =await employeeServices.GetByIdAsync(id.Value);
            if (emp == null)
                return NotFound();
            var dep =await services.GetAllAsync();
            var select = new SelectList(dep, "Id", "Name",emp.DepartmentId);
            ViewBag.Department = select;

            return View(mapper.Map<EmployeeUpdateRequest>(emp));

        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, EmployeeUpdateRequest employee)
        {
            if (!id.HasValue)
                return BadRequest();
            if (id.Value != employee.Id)
                return BadRequest();
            if (!ModelState.IsValid)
                return View(employee);

            try
            {

                var emp =await employeeServices.UpdateAsync(employee);
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
        public async Task<IActionResult> Delete(int? id)
        {


            if (!id.HasValue)
                return BadRequest();
            var emp =await employeeServices.GetByIdAsync(id.Value);
            if (emp == null)
                return NotFound();

            return View(emp);

        }
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();
            var employee =await employeeServices.GetByIdAsync(id.Value);
            try
            {

                var deleted =await employeeServices.DeleteAsync(id.Value);
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