using AutoMapper;
using Demo.BLL.DataTransferObject;
using Demo.BLL.Services;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo.PL.Controllers;

public class DepartmentsController(IDepartmentServices departmentServices,ILogger<DepartmentsController> logger,IWebHostEnvironment webHost,IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var dep =await departmentServices.GetAllAsync();
        return View(dep);

    }
    [HttpGet]
    public IActionResult Create() { 
    
    return View();
    
    }
    [HttpPost]
    public async Task<IActionResult> Create(DepartmentRequest department)
    {

        if(!ModelState.IsValid)
            return View(department);

        try
        {

            var dep=await departmentServices.AddAsync(department);
            if(dep>0)
            return RedirectToAction(nameof(Index));
            ModelState.AddModelError(string.Empty, "cam,t" );
        }
        catch (Exception ex) { 
        if(webHost.IsDevelopment())
                ModelState.AddModelError(string.Empty, ex.Message);
        else
              logger.LogError("wrong",ex.Message);

        }
        return View(department);
    }
    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if(!id.HasValue)
            return BadRequest();
        var dep =await departmentServices.GetByIdAsync(id.Value);
        if(dep ==null)
            return NotFound();

        return View(dep);

    }
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {


        if (!id.HasValue)
            return BadRequest();
        var dep =await departmentServices.GetByIdAsync(id.Value);
        if (dep == null)
            return NotFound();

        return View(dep.ToUpdate());

    }
    [HttpPost]
    public async Task<IActionResult> Edit([FromRoute]int? id,DepartmentUpdateRequest department)
    {
        if (!id.HasValue)
            return BadRequest();
        if(id.Value!=department.Id)
            return BadRequest();
        if (!ModelState.IsValid)
            return View(department);

        try
        {

            var dep =await departmentServices.UpdateAsync(department);
            if (dep > 0)
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
        return View(department);
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {


        if (!id.HasValue)
            return BadRequest();
        var dep =await departmentServices.GetByIdAsync(id.Value);
        if (dep == null)
            return NotFound();

        return View(dep);

    }
    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> ConfirmDelete(int? id)
    {
        if(!id.HasValue)
            return BadRequest();
        var department =await departmentServices.GetByIdAsync(id.Value);
        try
        {

            var deleted =await departmentServices.DeleteAsync(id.Value);
            if (deleted )
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
        return View(department);

    }
}
