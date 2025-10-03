using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services
{
    public class Document : IDocument
    {
        private List<string> _Ex = [".png",".jpeg"];
        private const int Mx_si = 2097152;
        public bool Delete(string file, string folder)
        {

            var path =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", folder, file);
            if(!File.Exists(path))
                return false;
            File.Delete(path);
            return true;
                

        }

        public async Task<string> UploadAsync(IFormFile file, string Folder)
        {
            var ex = Path.GetExtension(file.FileName);
            if (!_Ex.Contains(ex))
                return null;
            if (file.Length > Mx_si)
                return null;
            var Fi_name = $"{Guid.NewGuid}{ex}";

           var Fo_path =Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", Folder);

            var FilePath=Path.Combine(Fo_path,Fi_name);

            using Stream stream = new FileStream(FilePath,FileMode.Create);

            await file.CopyToAsync(stream);
            return Fi_name;
        }
    }
}
