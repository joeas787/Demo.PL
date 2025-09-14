using Demo.BLL.DataTransferObject;
using Demo.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.PL.Controllers;

public class DepartmentsController(IDepartmentServices departmentServices,ILogger<DepartmentsController> logger,IWebHostEnvironment webHost) : Controller
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
}
