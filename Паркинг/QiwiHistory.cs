using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Паркинг
{
    public class QiwiHistory
    {
        public List<Datum> history { get; set; }
    }

    public class Sum
    {
        public double amount { get; set; }
        public int currency { get; set; }
    }

    public class Commission
    {
        public double amount { get; set; }
        public int currency { get; set; }
    }

    public class Total
    {
        public double amount { get; set; }
        public int currency { get; set; }
    }

    public class Provider
    {
        public int id { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public object logoUrl { get; set; }
        public object description { get; set; }
        public string keys { get; set; }
        public object siteUrl { get; set; }
        public IList<object> extras { get; set; }
    }

    public class Extra
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class Source
    {
        public int id { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public string logoUrl { get; set; }
        public object description { get; set; }
        public string keys { get; set; }
        public string siteUrl { get; set; }
        public IList<Extra> extras { get; set; }
    }

    public class Features
    {
        public bool chequeReady { get; set; }
        public bool bankDocumentReady { get; set; }
        public bool regularPaymentEnabled { get; set; }
        public bool bankDocumentAvailable { get; set; }
        public bool repeatPaymentEnabled { get; set; }
        public bool favoritePaymentEnabled { get; set; }
        public bool chatAvailable { get; set; }
        public bool greetingCardAttached { get; set; }
    }

    public class ServiceExtras
    {
    }

    public class View
    {
        public string title { get; set; }
        public string account { get; set; }
    }

    public class Datum
    {
        public long txnId { get; set; }
        public long personId { get; set; }
        public DateTime date { get; set; }
        public int errorCode { get; set; }
        public object error { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public string statusText { get; set; }
        public string trmTxnId { get; set; }
        public string account { get; set; }
        public Sum sum { get; set; }
        public Commission commission { get; set; }
        public Total total { get; set; }
        public Provider provider { get; set; }
        public Source source { get; set; }
        public string comment { get; set; }
        public int currencyRate { get; set; }
        public IList<object> paymentExtras { get; set; }
        public Features features { get; set; }
        public ServiceExtras serviceExtras { get; set; }
        public View view { get; set; }
    }
}
