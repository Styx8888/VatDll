using System.Collections.Generic;

namespace ApiVatEntity
{
    public class Subject
    {
        public string name { get; set; }
        public string nip { get; set; }
        public string statusVat { get; set; }
        public string regon { get; set; }
        public object pesel { get; set; }
        public string krs { get; set; }
        public object residenceAddress { get; set; }
        public string workingAddress { get; set; }
        public List<object> representatives { get; set; }
        public List<object> authorizedClerks { get; set; }
        public List<object> partners { get; set; }
        public string registrationLegalDate { get; set; }
        public object registrationDenialBasis { get; set; }
        public object registrationDenialDate { get; set; }
        public object restorationBasis { get; set; }
        public object restorationDate { get; set; }
        public object removalBasis { get; set; }
        public object removalDate { get; set; }
        public List<string> accountNumbers { get; set; }
        public bool hasVirtualAccounts { get; set; }
    }

    public class SingleResult
    {
        public Subject subject { get; set; }
        public string requestId { get; set; }
    }

    public class SingleSubjectResponseRoot
    {
        public SingleResult Result { get; set; }
    }

    public class MultipleResult
    {
        public List<Subject> subjects { get; set; }
        public string requestId { get; set; }
    }

    public class MultipleSubjectResponseRoot
    {
        public MultipleResult Result { get; set; }
    }

    public class Result
    {
        public object subject { get; set; }
        public string requestId { get; set; }
    }

    public class RootObject
    {
        public Result result { get; set; }
    }
}
