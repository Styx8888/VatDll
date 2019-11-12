using Flurl;
using Flurl.Http;
using RGiesecke.DllExport;
using System.Collections.Generic;

namespace ApiVatEntity
{
    public static class Vat
    {
        public const string apiAddress = "https://wl-api.mf.gov.pl";

        [DllExport]
        public static Subject GetSubject(string nip, string date)
        {
            var endpoint = apiAddress.AppendPathSegment($"api/search/nips/{nip}");
            endpoint.SetQueryParam("date", date);
            var response = endpoint.GetJsonAsync<SingleSubjectResponseRoot>().Result;

            return response.SingleResult.subject;
        }

        [DllExport]
        public static List<Subject> GetSubjects(string nips, string date)
        {
            var endpoint = apiAddress.AppendPathSegment($"api/search/nips/{nips}");
            endpoint.SetQueryParam("date", date);
            var response = endpoint.GetJsonAsync<MultipleSubjectResponseRoot>().Result;

            return response.MultipleResult.subjects;
        }
    }
}
