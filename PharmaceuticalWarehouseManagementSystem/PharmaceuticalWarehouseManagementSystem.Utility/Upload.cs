using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PharmaceuticalWarehouseManagementSystem.Utility
{
  public static class Upload
    {
        public static string ImageUpload(List<IFormFile> files, IHostingEnvironment _env, out bool result)
        {
            //Resim yükleme işlemlerimizi gerçekleştiriyoruz. Geriye resim yolunu veya hata mesajını döndürüyoruz.Ayrıca dönen string'in başarı bilgisi mi veya hata mesajımı olduğunu anlamamızı kolaylaştırması açısından bir değer fırlatıyoruz.
            result = false;
            var uploads = Path.Combine(_env.WebRootPath, "Images");

            foreach (var file in files)
            {
                if (file.ContentType.Contains("image"))
                {
                    if (file.Length <= 2097152)
                    {
                        string uniqueName = $"{Guid.NewGuid().ToString().Replace("-", "_").ToLower()}.{file.ContentType.Split('/')[1]}";
                        var filePath = Path.Combine(uploads, uniqueName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            result = true;
                            return filePath.Substring(filePath.IndexOf("\\uploads\\"));
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
