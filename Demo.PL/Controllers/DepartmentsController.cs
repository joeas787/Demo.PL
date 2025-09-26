using AutoMapper;
using Demo.BLL.DataTransferObject;
using Demo.BLL.Services;
using Demo.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers;

public class DepartmentsController(IDepartmentServices departmentServices,ILogger<DepartmentsController> logger,IWebHostEnvironment webHost,IMapper mapper) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var dep = departmentServices.GetAll();
        return View(dep);

    }
    [HttpGet]
    public IActionResult Create() { 
    
    return View();
    
    }
    [HttpPost]
    public IActionResult Create(DepartmentRequest department)
    {

        if(!ModelState.IsValid)
            return View(department);

        try
        {

            var dep=departmentServices.Add(department);
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
    public IActionResult Details(int? id)
    {
        if(!id.HasValue)
            return BadRequest();
        var dep =departmentServices.GetById(id.Value);
        if(dep ==null)
            return NotFound();

        return View(dep);

    }
    [HttpGet]
    public IActionResult Edit(int? id)
    {


        if (!id.HasValue)
            return BadRequest();
        var dep = departmentServices.GetById(id.Value);
        if (dep == null)
            return NotFound();

        return View(dep.ToUpdate());

    }
    [HttpPost]
    public IActionResult Edit([FromRoute]int? id,DepartmentUpdateRequest department)
    {
        if (!id.HasValue)
            return BadRequest();
        if(id.Value!=department.Id)
            return BadRequest();
        if (!ModelState.IsValid)
            return View(department);

        try
        {

            var dep = departmentServices.Update(department);
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
    public IActionResult Delete(int? id)
    {


        if (!id.HasValue)
            return BadRequest();
        var dep = departmentServices.GetById(id.Value);
        if (dep == null)
            return NotFound();

        return View(dep);

    }
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult ConfirmDelete(int? id)
    {
        if(!id.HasValue)
            return BadRequest();
        var department = departmentServices.GetById(id.Value);
        try
        {

            var deleted = departmentServices.Delete(id.Value);
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
