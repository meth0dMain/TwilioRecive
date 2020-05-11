using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;

namespace TwilioRecive
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string accountSid = "ACc7fadfaa91ce7b3b287ecba70d62ad67";
            const string authToken = "8d2320ebba7d993d33a0ff38a85ee575";
            
            TwilioClient.Init(accountSid, authToken);
            
            //try
            {
                var message = MessageResource.Create(
                    body: "I AM YOUR FATHER, DOG",
                    from: new Twilio.Types.PhoneNumber("+12057829342"),
                    statusCallback: new Uri("http://postb.in/1589191864752-1382141765207"),
                    to: new Twilio.Types.PhoneNumber("+37253236685")
                );
            
                Console.WriteLine(message.Sid);
            }
            // catch (ApiException e)
            // {
            //     Console.WriteLine(e.Message);
            //     Console.WriteLine($"Twilio Error {e.Code} - {e.MoreInfo}");
            // }
            //Console.Write("Press any key to continue.");
            //Console.ReadKey();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
