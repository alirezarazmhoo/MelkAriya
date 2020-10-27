using InstagramApiSharp.API;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MelkAria.instagram
{
    internal class UploadPhoto 
    {
        private readonly IInstaApi InstaApi;

        public UploadPhoto(IInstaApi instaApi)
        {
            InstaApi = instaApi;
        }

        //public async Task DoShow(InstaImageUpload mediaImage,string description)
        //{
        //    //var mediaImage = new InstaImageUpload
        //    //{  
        //    //    // leave zero, if you don't know how height and width is it.
        //    //    Height = 1080,
        //    //    Width = 1080,
        //    //    Uri = @"F:\download.jpg"
        //    //};
        //    // Add user tag (tag people)
        //    //mediaImage.UserTags.Add(new InstaUserTagUpload
        //    //{
        //    //    Username = "rmt4006",
        //    //    X = 0.5,
        //    //    Y = 0.5
        //    //});
          
        //    var result = await InstaApi.MediaProcessor.UploadPhotoAsync(mediaImage, description);
        //    Console.WriteLine(result.Succeeded
        //        ? $"Media created: {result.Value.Pk}, {result.Value.Caption}"
        //        : $"Unable to upload photo: {result.Info.Message}");
        //    string imageUrl = "/Upload/melks/123.txt";
        //        string path2 = HttpContext.Current.Server.MapPath(imageUrl);

        //        using (FileStream fs = System.IO.File.Create(path2))
        //        {
        //            Byte[] info = new UTF8Encoding(true).GetBytes("over");
        //            // Add some information to the file.
        //            fs.Write(info, 0, info.Length);
        //        }
        //}

        //public async Task DoShowWithProgress()
        //{
        //    var mediaImage = new InstaImageUpload
        //    {
        //        // leave zero, if you don't know how height and width is it.
        //        Height = 1080,
        //        Width = 1080,
        //        Uri = @"c:\someawesomepicture.jpg"
        //    };
        //    // Add user tag (tag people)
        //    mediaImage.UserTags.Add(new InstaUserTagUpload
        //    {
        //        Username = "rmt4006",
        //        X = 0.5,
        //        Y = 0.5
        //    });
        //    // Upload photo with progress
        //    var result = await InstaApi.MediaProcessor.UploadPhotoAsync(UploadProgress, mediaImage, "someawesomepicture");
        //    Console.WriteLine(result.Succeeded
        //        ? $"Media created: {result.Value.Pk}, {result.Value.Caption}"
        //        : $"Unable to upload photo: {result.Info.Message}");
        //}
        //void UploadProgress(InstaUploaderProgress progress)
        //{
        //    if (progress == null)
        //        return;
        //    Console.WriteLine($"{progress.Name} {progress.UploadState}");
        //}
    }
}