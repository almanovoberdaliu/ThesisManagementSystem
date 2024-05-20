using ThesisManagementSystem.Models;

namespace ThesisManagementSystem.Repositories
{
    public interface IFileRepository
    {
        public Task PostFileAsync(IFormFile fileData, FileType fileType);
        public Task PostMultiFileAsync(List<FileUploadModel> fileData);
        public Task DownloadFileById(int Id);

        public FileUploadModel GetFileById(int fileId);

        public List<FileUploadModel> GetAll();
    }
}
