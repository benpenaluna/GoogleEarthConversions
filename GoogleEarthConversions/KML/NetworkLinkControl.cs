using GoogleEarthConversions.Core.Common;
using GoogleEarthConversions.Core.KML.AbstractView;
using GoogleEarthConversions.Core.KML.TimePrimitive.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GoogleEarthConversions.Core.KML
{
    public class NetworkLinkControl : GoogleEarthObject, INetworkLinkControl
    {
        public GenericKML<double> MinRefreshPeriod { get; set; }
        public GenericKML<double> MaxSessionLength { get; set; }
        public GenericKML<string> Cookie { get; set; }
        public GenericKML<string> Message { get; set; }
        public GenericKML<string> LinkName { get; set; }
        public GenericKML<string> LinkDescription { get; set; }
        public ILinkSnippet LinkSnippet { get; set; }
        public GenericKML<ITimeSpanDateTime> Expires { get; set; }
        public GenericKML<NetworkLinkControlUpdate> Update { get; set; }
        public AbstractView.AbstractView AbstractView { get; set; }

        public NetworkLinkControl()
        {
            Id = string.Empty;
            TargetId = string.Empty;
            
            MinRefreshPeriod = new GenericKML<double>(nameof(MinRefreshPeriod).ConvertFirstCharacterToLowerCase(), value: 0.0, def: 0.0);
            MaxSessionLength = new GenericKML<double>(nameof(MaxSessionLength).ConvertFirstCharacterToLowerCase(), value: -1.0, def: -1.0);
            Cookie = new GenericKML<string>(nameof(Cookie).ConvertFirstCharacterToLowerCase(), value: string.Empty, def: string.Empty);
            Message = new GenericKML<string>(nameof(Message).ConvertFirstCharacterToLowerCase(), value: string.Empty, def: string.Empty);
            LinkName = new GenericKML<string>(nameof(LinkName).ConvertFirstCharacterToLowerCase(), value: string.Empty, def: string.Empty);
            LinkDescription = new GenericKML<string>(nameof(LinkDescription).ConvertFirstCharacterToLowerCase(), value: string.Empty, def: string.Empty);
            LinkSnippet = new LinkSnippet(string.Empty);
            Update = new GenericKML<NetworkLinkControlUpdate>(nameof(Update), value: NetworkLinkControlUpdate.Change, def: NetworkLinkControlUpdate.Change);
            AbstractView = new DummyAbstractView();

            InitialiseExpires();
        }

        private void InitialiseExpires()
        {
            var dateTimeValue = new TimeSpanDateTime(new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            var dateTimeDefault = new TimeSpanDateTime(new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc));
            Expires = new GenericKML<ITimeSpanDateTime>(nameof(Expires).ConvertFirstCharacterToLowerCase(), value: dateTimeValue, def: dateTimeDefault);
            Expires.SetSerialiseToKMLFunction(ConvertExpiresToKML);
        }

        private static string ConvertExpiresToKML(GenericKML<ITimeSpanDateTime> dateTime)
        {
            var dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";


            if (dateTime.Value.DateTime == dateTime.Default.DateTime)
                return string.Empty;

            var value = dateTime.Value.DateTime.ToString(dateTimeFormat);

            return string.Format("<{0}>{1}</{0}>", dateTime.KmlTagName, value);
        }

        public override bool Equals(object obj)
        {
            return obj.GetType() == typeof(NetworkLinkControl) && Equals((NetworkLinkControl)obj);
        }

        protected bool Equals(NetworkLinkControl other)
        {
            return Equals(Id, other.Id) &&
                   Equals(TargetId, other.TargetId) &&
                   Equals(MinRefreshPeriod, other.MinRefreshPeriod) &&
                   Equals(MaxSessionLength, other.MaxSessionLength) &&
                   Equals(Cookie, other.Cookie) &&
                   Equals(Message, other.Message) &&
                   Equals(LinkName, other.LinkName) &&
                   Equals(LinkDescription, other.LinkDescription) &&
                   Equals(LinkSnippet, other.LinkSnippet) &&
                   Equals(Expires, other.Expires) &&
                   Equals(Update, other.Update) &&
                   Equals(AbstractView, other.AbstractView);
        }

        public static bool operator ==(NetworkLinkControl a, NetworkLinkControl b)
        {
            return EqualityCheck.ObjectEquals(a, b);
        }

        public static bool operator !=(NetworkLinkControl a, NetworkLinkControl b)
        {
            return !EqualityCheck.ObjectEquals(a, b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public string SerialiseToKML()
        {
            StringWriter swBody = new StringWriter();

            swBody.Write(MinRefreshPeriod.SerialiseToKML());
            swBody.Write(MaxSessionLength.SerialiseToKML());
            swBody.Write(Cookie.SerialiseToKML());
            swBody.Write(Message.SerialiseToKML());
            swBody.Write(LinkName.SerialiseToKML());
            swBody.Write(LinkDescription.SerialiseToKML());
            swBody.Write(LinkSnippet.SerialiseToKML());
            swBody.Write(Expires.SerialiseToKML());
            swBody.Write(Update.SerialiseToKML());
            swBody.Write(AbstractView.SerialiseToKML());

            return swBody.ToString() == string.Empty ? string.Empty
                                                     : string.Format("<{0}>{1}</{0}>", nameof(NetworkLinkControl), swBody.ToString());
        }
    }
}
