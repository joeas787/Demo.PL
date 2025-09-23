using Demo.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Demo.BLL.DataTransferObject;

public static class DepartmentFactory
{
    public static Department ToEntity(this DepartmentRequest request)
    {



        return new()
        {
            Name = request.Name,
            Code = request.Code,
            CreatedAt = request.CreatedAt,
            Description = request.Description


        };
    }//
    public static Department ToEntity(this DepartmentUpdateRequest request)
    {



        return new()
        {
            Id = request.Id,
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            CreatedAt = request.CreatedAt


        };
    }//
    public static DepartmentDetailsResponse ToDetails(this Department department)
    {
        return new()
        {

            Id = department.Id,
            Name = department.Name,
            CreatedAt = department.CreatedAt,
            Description = department.Description,
            Code = department.Code,
            CreatedBy = department.CreatedBy,
            IsDeleted = department.IsDeleted,
            LastModifiedBy = department.LastModifiedBy,
            LastModifiedOn = department.LastModifiedOn,
            CreatedOn = department.CreatedOn,




        };



    }//
    public static DepartmentResponse ToResponse(this Department department) { 
    
    return new() { Code = department.Code, CreatedAt =department.CreatedAt, Description = department.Description,
        Name= department.Name,
        Id = department.Id
    
    
    
    
    };
    
    
    
    }//

    public static DepartmentUpdateRequest ToUpdate(this DepartmentDetailsResponse request) {


        return new()
        {
            Id = request.Id,
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            CreatedAt = request.CreatedAt


        };
    
    
    
    
    
    
    }

    public static DepartmentRequest ToRequest(this DepartmentUpdateRequest request) {


        return new()
        {
            Name = request.Name,
            Description = request.Description,
            Code = request.Code



        };
    
    
    }

}
