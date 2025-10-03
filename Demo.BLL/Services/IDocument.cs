using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services
{
    public interface IDocument
    {
        public Task<string> UploadAsync(IFormFile file,string Folder );
        public bool Delete(string file,string folder);
    }
}
