using System.IO;
using System.Threading.Tasks;

namespace Common
{
    public class FilesStorageService
    {
        public Task<string> UploadFile(string fileName, Stream file, string mimeType)
        {
            return Task.FromResult(string.Empty);
        }
    }
}