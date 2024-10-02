using EXE201_2RE_API.DTOs;

namespace EXE201_2RE_API.Service
{
    public interface IFirebaseService
    {
        Task<ActionOutcome> UploadFileToFirebase(IFormFile file, string pathFileName);
        Task<ActionOutcome> UploadFilesToFirebase(List<IFormFile> files, string basePath);
        public Task<string> GetUrlImageFromFirebase(string pathFileName);
        public Task<ActionOutcome> DeleteFileFromFirebase(string pathFileName);
    }
}
