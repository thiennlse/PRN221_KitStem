using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;


namespace Service
{
    public class FirebaseService
    {
        private readonly string _bucket;
        public FirebaseService(IConfiguration configuration)
        {
            _bucket = configuration["Firebase:StorageBucket"];
        }

        public async Task<string> GetImageUrlAsync(string? fileName)
        {
            var storage = new FirebaseStorage(_bucket);

            var imageUrl = await storage.Child("images").Child(fileName).GetDownloadUrlAsync();
            return imageUrl;
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCYs-f-LSG-8gLHNCboO8aaEf6D2Gur68k"));
            var storage = new FirebaseStorage(_bucket);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            using (var stream = file.OpenReadStream())
            {
                var uploadTask = await storage
                    .Child("images")
                    .Child(fileName)
                    .PutAsync(stream);

                return await storage.Child("images").Child(fileName).GetDownloadUrlAsync();
            }
        }

        public async Task DeleteImageAsync(string imageUrl)
        {
            var storage = new FirebaseStorage(_bucket);

            var fileName = Path.GetFileName(new Uri(imageUrl).LocalPath);

            await storage.Child("images").Child(fileName).DeleteAsync();
        }

        public async Task<string> UploadDocumentAsync(IFormFile file)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyCYs-f-LSG-8gLHNCboO8aaEf6D2Gur68k"));
            var storage = new FirebaseStorage(_bucket);

            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + fileExtension;

            if (fileExtension != ".docx" && fileExtension != ".pdf" && fileExtension != ".txt")
            {
                throw new InvalidDataException("Only .docx, .pdf, and .txt files are allowed.");
            }

            using (var stream = file.OpenReadStream())
            {
                var uploadTask = await storage
                    .Child("documents")
                    .Child(fileName)
                    .PutAsync(stream);

                return await storage.Child("documents").Child(fileName).GetDownloadUrlAsync();
            }
        }

        public async Task DeleteDocumentAsync(string documentUrl)
        {
            var storage = new FirebaseStorage(_bucket);

            var fileName = Path.GetFileName(new Uri(documentUrl).LocalPath);

            await storage.Child("documents").Child(fileName).DeleteAsync();
        }

        public async Task<string> GetDocumentUrlAsync(string? fileName)
        {
            var storage = new FirebaseStorage(_bucket);

            var documentUrl = await storage.Child("documents").Child(fileName).GetDownloadUrlAsync();
            return documentUrl;
        }
    }

}
