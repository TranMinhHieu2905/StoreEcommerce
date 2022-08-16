using LibraryStoreEcommerce;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreEcommerceaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment env;

        public FileController(IWebHostEnvironment env)
        {
            this.env = env;
        }
        /// <summary>
        /// Upload File
        /// </summary>
        /// <param name="uploadedFile"></param>
        /// <returns></returns>
        [HttpPost("Upload")]
        public ActionResult Post(UploadedFile uploadedFile)
        {
            string path;
            if (CheckIfExcelFile(uploadedFile))
            {
                WriteFile(uploadedFile, out path);
            }
            else
            {
                return BadRequest("");
            }
            return Ok(path);
        }
        private string WriteFile(UploadedFile uploadedFile, out string path)
        {
            path = "";
            //path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files", uploadedFile.FileName);
            path = Path.Combine(@".\Upload\", @"files\" + uploadedFile.FileName + "");
            var fs = System.IO.File.Create(path);
            fs.Write(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
            fs.Close();
            return path;
        }
        private bool CheckIfExcelFile(UploadedFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            if ((extension == ".png") || (extension == ".jpg") || (extension == ".docx"))
            {
                return true;
            }
            return false;
        }

        [HttpPost("UploadIMG")]
        public ActionResult Post([FromBody] ImageFile[] files)
        {
            string path="";
            foreach (var file in files)
            {
                var buf = Convert.FromBase64String(file.base64data);
              
                System.IO.File.WriteAllBytesAsync(env.ContentRootPath + System.IO.Path.DirectorySeparatorChar + Guid.NewGuid().ToString("N") + "-" + file.fileName, buf);
                path = Path.Combine(env.ContentRootPath + file.fileName + "");
            }
            return Ok(files);
        }

        // POST api/<FileController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FileController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FileController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
