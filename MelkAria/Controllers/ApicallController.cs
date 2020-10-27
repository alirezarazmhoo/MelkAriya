using InstagramApiSharp.API;
using InstagramApiSharp.API.Builder;
using InstagramApiSharp.Classes;
using InstagramApiSharp.Classes.Models;
using InstagramApiSharp.Logger;
using MelkAria.DAL;
using MelkAria.instagram;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace MelkAria.Controllers
{
    public class ApicallController : ApiController
    {
        private static IInstaApi InstaApi;
        DataBaseContext db = new DataBaseContext();

        [HttpPost]
        [Route("Apicall/AdduserFavorite")]

        public async Task<object> AdduserFavorite()
        {
            var httpRequest = HttpContext.Current.Request.Files["file"];  
            var b = HttpContext.Current.Request.Form["p9"];
            string Url = "";
            if (httpRequest.ContentLength > 0)
            {
                string fileNameExternal = Path.GetFileName(httpRequest.FileName);
                var namefile = Guid.NewGuid().ToString().Replace('-', '0') + Path.GetExtension(fileNameExternal);
                var filePath = HttpContext.Current.Server.MapPath(httpRequest.FileName);
                Url = httpRequest.FileName;
                httpRequest.SaveAs(filePath);
            }
            var userSession = new InstagramApiSharp.Classes.UserSessionData
            {
                UserName = "ariaamlak6",
                Password = "zxcvbnm12"
            };

            var delay = RequestDelay.FromSeconds(2, 2);

            InstaApi = InstaApiBuilder.CreateBuilder()
                .SetUser(userSession)
                .UseLogger(new DebugLogger(LogLevel.All)) // use logger for requests and debug messages
                .SetRequestDelay(delay)
                .Build();
            string pth = HostingEnvironment.MapPath(@"~"+Url);
            var mediaImage = new InstaImageUpload
            {
                Height = 1080,
                Width = 1080,
                Uri = pth,
            };

            if (!InstaApi.IsUserAuthenticated)
            {
                Console.WriteLine($"Logging in as {userSession.UserName}");
                delay.Disable();
                var logInResult = await InstaApi.LoginAsync();
                delay.Enable();
                if (!logInResult.Succeeded)
                {
                    Console.WriteLine($"Unable to login: {logInResult.Info.Message}");
                    return false;
                }
            }
            //var a = new UploadPhoto(InstaApi);
            // await a.DoShow(mediaImage, b);

            try
            {
               System.IO.File.Delete(HttpContext.Current.Server.MapPath(Url));

            }
            catch (Exception ex)
            { }
            return true;

        }
    }
}
