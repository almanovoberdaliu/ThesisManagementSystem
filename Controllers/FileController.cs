using Microsoft.AspNetCore.Mvc;
using ThesisManagementSystem.Models;
using ThesisManagementSystem.Repositories;

namespace ThesisManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;

        public FileController(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpPost("PostSingleFile")]
        public async Task<ActionResult> PostSingleFile([FromForm] FileUploadModel fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                await _fileRepository.PostFileAsync(fileDetails.FileDetails, fileDetails.FileType);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("PostMultipleFile")]
        public async Task<ActionResult> PostMultipleFile([FromForm] List<FileUploadModel> fileDetails)
        {
            if (fileDetails == null)
            {
                return BadRequest();
            }

            try
            {
                await _fileRepository.PostMultiFileAsync(fileDetails);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("DownloadFile")]
        public async Task<ActionResult> DownloadFile(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            try
            {
                await _fileRepository.DownloadFileById(id);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
