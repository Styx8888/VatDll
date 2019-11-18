using System;
using Flurl;
using Flurl.Http;
using RGiesecke.DllExport;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ApiVatEntity
{
    public static class Vat
    {
        public const string apiAddress = "https://wl-api.mf.gov.pl";

        public const string apiTestAddress = "https://wl-test.mf.gov.pl";

        public const string SaveFullPath = @"C:\Temp\vatentity.txt";

        [DllExport]
        public static string GetSubject(string nip, string date)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var endpoint = apiAddress.AppendPathSegment($"api/search/nip/{nip}");
            endpoint.SetQueryParam("date", date);
            //var response = endpoint.GetJsonAsync<SingleSubjectResponseRoot>().Result;

            var response = endpoint.GetStringAsync().Result;

            Console.WriteLine(response);

            SaveToFile(SaveFullPath, response);

            //return response.Result.subject;
            return response;
        }

        [DllExport]
        public static string GetTestSubject(string nip, string date)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var endpoint = apiTestAddress.AppendPathSegment($"api/search/nip/{nip}");
            endpoint.SetQueryParam("date", date);
            var response = endpoint.GetStringAsync().Result;
            //var response = endpoint.GetJsonAsync<RootObject>().Result;
            
            Console.WriteLine(response);

            SaveToFile(SaveFullPath, response);
            
            //return "test" + response.result.requestId;
            return response;
        }

        //public class Test
        //{
        //    public string requestId { get; set; }

        //    public object something { get; set; }

        //    public int counter { get; set; }
        //}

        [DllExport]
        public static string GetSubjects(string nips, string date)
        {
            var endpoint = apiAddress.AppendPathSegment($"api/search/nips/{nips}");
            endpoint.SetQueryParam("date", date);
            var response = endpoint.GetStringAsync().Result;
            // var response = endpoint.GetJsonAsync<MultipleSubjectResponseRoot>().Result;
            Console.WriteLine(response);

            SaveToFile(SaveFullPath, response);
            // return response.Result.subjects;
            return response;
        }

        private static void SaveToFile(string path, string content)
        {
            File.Delete(path);

            File.WriteAllText(path, content);
        }
    }
}
