using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Logger;
using MelkAria.instagram;
using MelkAria.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using Telegram.Bot.Types.Enums;

namespace MelkAria.Models
{


    public class TelegramService
    {
        private static IInstaApi InstaApi;
        private static readonly HttpClient client = new HttpClient();
        string Msg = "";
        public async Task<bool> SendPhotoToChannel(string fileUrl, string title, string description, string imageUrl, string imageUrlInsta)
        {

            try
            {
                if (string.IsNullOrEmpty(fileUrl) || string.IsNullOrEmpty(title))
                {
                    Msg = "مسیر یا عنوان عکس نمیتواند خالی باشد.";
                    return false;
                }

                //var bot = new Telegram.Bot.Api("807702513:AAGQdMemT-z4TItD9tU11gBN_wHPBQNdJSM");
                 var bot = new Telegram.Bot.Api("782438940:AAER1LFspwUECMgOMldmrxBkT5J6w_kdgWk");

                //await bot.SendTextMessage("@Mychaneltesti", "<a href='" + fileUrl + "'>&quot;</a>&quot;<p>واحدهای متراژ</p> &quot;<hr /> &quot;<p>مشاور املاک: &quot;<span>08566 &quot;</span>&quot;</p>&quot;<hr />", false, false, 0, null, ParseMode.Html);

                 await bot.SendTextMessage("@ariiyaaa", "<a href='" + fileUrl + "'>&quot;</a><b>" + title + "</b>&quot;\n" + description, false, false, 0, null, ParseMode.Html);



                //ارسال به اینستاگرام
                //var userSession = new InstagramApiSharp.Classes.UserSessionData
                //{
                //    UserName = "ariaamlakir",
                //    Password = "zxcvbnm121212"

                //};

                //var delay = RequestDelay.FromSeconds(2, 2);

                //InstaApi = InstaApiBuilder.CreateBuilder()
                //    .SetUser(userSession)
                //    .UseLogger(new DebugLogger(LogLevel.All)) // use logger for requests and debug messages
                //    .SetRequestDelay(delay)
                //    .Build();
                //var mediaImage = new InstaImageUpload
                //{
                //    Height = 1080,
                //    Width = 1080,
                //    Uri = imageUrlInsta,

                //};


                //if (!InstaApi.IsUserAuthenticated)
                //{
                //    // login
                //    Console.WriteLine($"Logging in as {userSession.UserName}");
                //    delay.Disable();
                //    var logInResult = await InstaApi.LoginAsync();
                //    delay.Enable();
                //    if (!logInResult.Succeeded)
                //    {
                //        Console.WriteLine($"Unable to login: {logInResult.Info.Message}");
                //        return false;
                //    }
                //}
                //var state = InstaApi.GetStateDataAsStream();
                // in .net core or uwp apps don't use GetStateDataAsStream.
                // use this one:
                // var state = _instaApi.GetStateDataAsString();
                // this returns you session as json string.
                //using (var fileStream = File.Create(stateFile))
                //{
                //    state.Seek(0, SeekOrigin.Begin);
                //    state.CopyTo(fileStream);
                //}
                ////////////var a = new UploadPhoto(InstaApi);
                //var result =  await InstaApi.MediaProcessor.UploadPhotoAsync(mediaImage, "someawesomepicture");
                ////////////await a.DoShow(mediaImage, description);
                //اتمام ارسال به اینستاگرام


                Msg = "ارسال عکس با موفقیت انجام شد.";
                return true;












            }
            catch (Exception exception)
            {
                //7
                if (exception.Message.Contains("access denied"))
                {
                    Msg = "محل عکس را تغییر دهید.";
                    return false;
                }
                if (exception.Message.Contains("Could not find file"))
                {
                    Msg = "عکس مورد نظر پیدا نشد، دوباره امتحان کنید.";
                    return false;
                }
                Msg = "خطایی هنگام بارگذاری عکس رخ داد.";
                return false;
            }
        }
        [WebMethod, AllowCrossSiteJson]
        public async Task<bool> SendPhotoToInstagram(string fileUrl, string contentmsg,string imageName)
        {
            try
            {
               var request = new HttpRequestMessage(HttpMethod.Post,"http://salamat-koodak.ir/Apicall/AdduserFavorite");
               
                var content = new MultipartFormDataContent();
                request.Headers.Add("Accept-Language", "en-gb,en;q=0.5");
                request.Headers.Add("Accept-Charset", "ISO-8859-1,utf-8;q=0.7,*;q=0.7");
               
                byte[] byteArray = File.ReadAllBytes(fileUrl);
                content.Add(new ByteArrayContent(byteArray), "file", imageName);
                HttpContent fileStreamContent = new StringContent(contentmsg);
                content.Add(fileStreamContent,"p9");
                
                //content.Headers.Add("instacontent", contentmsg);
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return true;

            }
            catch (Exception ex)
            {
                string imageUrl = "/Upload/melks/a000999.txt";
                string path2 = HttpContext.Current.Server.MapPath(imageUrl);

                using (FileStream fs = System.IO.File.Create(path2))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(ex.Message + "\n" + ex.StackTrace + "\n" + ex.InnerException + "\n" + ex.InnerException.InnerException);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
                return false;

            }
            //return await response.Content.ReadAsStringAsync();
        }
    }
}