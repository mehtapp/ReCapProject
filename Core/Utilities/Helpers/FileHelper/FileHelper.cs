using Core.Utilities.Helpers.GuidHelpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHelper : IFileHelper
    {
        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);
                string guid = GuidHelper.CreateGuid();
                string filePath = guid + extension;
                //string filePath = Path.Combine(guid, extension);


                using (FileStream fileStream = File.Create(root + filePath))

                {
                    file.CopyTo(fileStream);//Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen IFromFile türündeki
                                            //file dosyasınınnereye kopyalacağını söyledik.
                    fileStream.Flush();//arabellekten siler.
                    return filePath;//burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi
                                    //için.
                }
            }
            return null;
        }
        public void Delete(string filePath , string root)
        {
            if (File.Exists(filePath))
            {   
                string deletedImagePath = Path.Combine(root, filePath);
                File.Delete(deletedImagePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
            {
                Delete(filePath , root);
            }
            return Upload(file , root);

        }


    }
}
