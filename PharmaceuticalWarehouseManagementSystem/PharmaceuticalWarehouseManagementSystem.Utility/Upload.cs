using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PharmaceuticalWarehouseManagementSystem.Utility
{
  public class Upload
    {
        public static string ImageUpload(List<IFormFile> Files, IHostingEnvironment _env, out bool result)
        {
            //Resim yükleme işlemlerimizi gerçekleştiriyoruz. Geriye resim yolunu veya hata mesajını döndürüyoruz.Ayrıca dönen string'in başarı bilgisi mi veya hata mesajımı olduğunu anlamamızı kolaylaştırması açısından bir değer fırlatıyoruz.
            result = false;

            string uploads = Path.Combine(_env.WebRootPath, "Images");

            foreach (var file in Files)
            {
                if (file.FileName.Contains(".png") || file.FileName.Contains(".jpg") || file.FileName.Contains(".JPG") || file.FileName.Contains(".PNG"))
                {
                    if (file.Length <= 2097152)
                    {
                        string uniqueName = $"{Guid.NewGuid().ToString().Replace("-", "_").ToLower()}.{file.ContentType.Split('/')[1]}";
                        
                        var filePath = Path.Combine(uploads, uniqueName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            result = true;
                            return uniqueName;
                        }
                    }
                    else
                    {
                        return $"2MB'dan büyük boyutta resim yükleyemezsiniz.";
                    }
                }
                else
                {
                    return $"Lütfen sadece resim dosyası yükleyin.";
                }
            }
            return "Dosya bulunamadı! Lütfen en az bir dosya seçin.";
        }

    }
}
