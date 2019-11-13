using Flurl;
using Flurl.Http;
using RGiesecke.DllExport;
using System.Collections.Generic;
using System.Net;

namespace ApiVatEntity
{
    public static class Vat
    {
        public const string apiAddress = "https://wl-api.mf.gov.pl";

        public const string apiTestAddress = "https://wl-test.mf.gov.pl";

        [DllExport]
        public static Subject GetSubject(string nip, string date)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var endpoint = apiAddress.AppendPathSegment($"api/search/nip/{nip}");
            endpoint.SetQueryParam("date", date);
            var response = endpoint.GetJsonAsync<SingleSubjectResponseRoot>().Result;

            return response.Result.subject;
        }

        [DllExport]
        public static string GetTestSubject(string nip, string date)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var endpoint = apiTestAddress.AppendPathSegment($"api/search/nip/{nip}");
            endpoint.SetQueryParam("date", date);
            var response = endpoint.GetJsonAsync<RootObject>().Result;

            return "test" + response.result.requestId;
        }

        //public class Test
        //{
        //    public string requestId { get; set; }

        //    public object something { get; set; }

        //    public int counter { get; set; }
        //}

        [DllExport]
        public static List<Subject> GetSubjects(string nips, string date)
        {
            var endpoint = apiAddress.AppendPathSegment($"api/search/nips/{nips}");
            endpoint.SetQueryParam("date", date);
            var response = endpoint.GetJsonAsync<MultipleSubjectResponseRoot>().Result;

            return response.Result.subjects;
        }

        //private static void Somewhere()
        //{
        //    ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
        //}

        //private static bool AlwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        //{
        //    return true;
        //}
    }
}
