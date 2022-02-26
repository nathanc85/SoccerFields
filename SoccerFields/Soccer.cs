using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoccerFields
{
    class Soccer
    {
        /// <summary>
        ///     This is the manager method responsible with coordonating the pieces that will monitor the fields.
        /// </summary>
        public static void MonitorFields()
        {
            var tomorrow = DateTime.Today.AddDays(1).ToString("MM-dd-yyyy");
            Console.WriteLine($"Monitoring the soccer fields for tomorrow, {tomorrow}!");
            Console.WriteLine();

            var link = "https://strikers-soccer.myshopify.com/collections/indian-trail/products/" + tomorrow + "-8-00-pm-indian-trail-field-big";
            Console.WriteLine("Link: " + link);
            Console.WriteLine();

            var currentDate = DateTime.Now;
            Console.WriteLine($"The monitoring started at {currentDate.ToString()}");
            Console.WriteLine();

            var iteration = 0;
            var timeToWait = 10000;

            // Keeps checking that page until the conditions fail.
            while (!RemoteFileExistsUsingClient(link) && iteration < 3)
            {
                Console.WriteLine("    NOT AVAILABLE. Checked at " + currentDate.ToString());
                iteration++;

                Thread.Sleep(timeToWait);
                currentDate = DateTime.Now;
            }

            Console.WriteLine();
            Console.WriteLine($"The monitoring ended at {currentDate.ToString()}, after {iteration} iterations.");
            Console.WriteLine();

            Console.WriteLine();
            //Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"AVAILABLE NOW! You can now book the field for tomorrow, {tomorrow}!");
            Console.ResetColor();

            do
            {
                Console.Beep(1000,1000);
            } while (!Console.KeyAvailable);

        }

        /// <summary>
        ///     Checks to see if the url/file exists.
        /// </summary>
        /// <param name="url">
        ///     The url to check
        /// </param>
        /// <returns>
        ///     TRUE: if the the url/file/page exists
        ///     FALSE: otherwise
        /// </returns>
        private static bool RemoteFileExistsUsingClient(string url)
        {
            bool result = false;
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent", "Only a test!");
                try
                {
                    Stream stream = client.OpenRead(url);
                    if (stream != null)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }


        // OTHER THINGS I TRIED BUT FAILED
        ///
        /// Checks the file exists or not.
        ///
        /// The URL of the remote file.
        /// True : If the file exits, False if file not exists
        //private static bool RemoteFileExists(string url)
        //{
        //    try
        //    {
        //        //Creating the HttpWebRequest
        //        HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
        //        //Adding an agent
        //        request.Headers["user-agent"] = "only a test";
        //        //Setting the Request method HEAD, you can also use GET too.
        //        request.Method = "HEAD";
        //        //Getting the Web Response.
        //        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        //        //Returns TRUE if the Status code == 200
        //        response.Close();
        //        return (response.StatusCode == HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Any exception will returns false.
        //        return false;
        //    }
        //}

        //static async Task CallWebAPIAsync()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://strikers-soccer.myshopify.com/collections/");
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //        //GET Method
        //        HttpResponseMessage response = await client.GetAsync("indian-trail/products/02-23-2022-8-00-pm-indian-trail-field-big");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine("Success");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Internal server Error");
        //        }

        //    }
        //    Console.Read();
        //}

        //public static HttpStatusCode GetHeaders(string url)
        //{
        //    HttpStatusCode result = default(HttpStatusCode);

        //    var request = HttpWebRequest.Create(url);
        //    request.Method = "HEAD";
        //    using (var response = request.GetResponse() as HttpWebResponse)
        //    {
        //        if (response != null)
        //        {
        //            result = response.StatusCode;
        //            response.Close();
        //        }
        //    }

        //    return result;
        //}

        //private static async void Curl()
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var request = new HttpRequestMessage(new HttpMethod("HEAD"), "https://strikers-soccer.myshopify.com/collections/indian-trail/products/02-22-2022-8-00-pm-indian-trail-field-big"))
        //        {
        //            var response = await httpClient.SendAsync(request);
        //            Console.WriteLine(response);
        //        }
        //    }
        //}
    }
}
