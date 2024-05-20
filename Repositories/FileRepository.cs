using Microsoft.EntityFrameworkCore;
using ThesisManagementSystem.Data;
using ThesisManagementSystem.Exceptions;
using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly DbContextClass dbContext;

        public FileRepository(DbContextClass dbContextClass)
        {
            dbContext = dbContextClass;
        }
        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = dbContext.FileDetails.Where(x => x.ID == Id).FirstOrDefaultAsync();

                var content = new System.IO.MemoryStream(file.Result.FileData);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.Result.FileName);

                await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public List<FileUploadModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public FileUploadModel GetFileById(int fileId)
        {
            throw new NotImplementedException();
        }

        public async Task PostFileAsync(IFormFile fileData, FileType fileType)
        {
            try
            {
                var fileDetails = new FileDetails()
                {
                    ID = 0,
                    FileName = fileData.FileName,
                    FileType = fileType,
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    fileDetails.FileData = stream.ToArray();
                }
                var result = dbContext.FileDetails.Add(fileDetails);
                await dbContext.SaveChangesAsync();

            }
            catch
            {
                throw new FileNotAdded("File not added!");
            }
        }

        public async Task PostMultiFileAsync(List<FileUploadModel> fileData)
        {
            try 
            {
                foreach(FileUploadModel file in fileData)
                {
                    var fileDetails = new FileDetails()
                    {
                        ID = 0,
                        FileName = file.FileDetails.FileName,
                        FileType = file.FileType,
                    };

                    using (var stream = new MemoryStream())
                    {
                        file.FileDetails.CopyTo(stream);
                        fileDetails.FileData = stream.ToArray();
                    }

                    var result = dbContext.FileDetails.Add(fileDetails);
                }
                await dbContext.SaveChangesAsync();
            }

            catch 
            {
                throw new FileNotAdded("File Not Added");
            }
        }
    }
}
