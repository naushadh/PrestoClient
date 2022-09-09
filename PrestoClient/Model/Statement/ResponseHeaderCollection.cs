using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;

namespace BAMCIS.PrestoClient.Model.Statement
{
    public class ResponseHeaderCollection
    {
        #region Public Properties

        public string Catalog { get; }

        public string Schema { get; }

        public IDictionary<string, string> SessionProperties { get; }

        public HashSet<string> ResetSessionProperties { get; }

        public IDictionary<string, string> AddedPrepare { get; }

        public HashSet<string> DeallocatedPreparedStatements { get; }

        public string StartedTransactionId { get; }

        public bool ClearTransactionId { get; }

        #endregion

        #region Constructors

        public ResponseHeaderCollection(HttpResponseHeaders headers, PrestoHeader prestoHeader)
        {
            IEnumerable<string> Temp;

            // Extract the catalog and schema
            if (headers.TryGetValues(prestoHeader.SetCatalog(), out Temp))
            {
                this.Catalog = Temp.FirstOrDefault();
            }

            if (headers.TryGetValues(prestoHeader.SetSchema(), out Temp))
            {
                this.Schema = Temp.FirstOrDefault();
            }

            // Extract the session properties
            this.SessionProperties = new Dictionary<string, string>();

            if (headers.TryGetValues(prestoHeader.SetSession(), out Temp))
            {
                foreach (string Value in Temp)
                {
                    string[] Parts = Value.Split('=').Select(x => x.Trim()).ToArray();

                    if (Parts.Length != 2)
                    {
                        continue;
                    }

                    this.SessionProperties.Add(Parts[0], Parts[1]);
                }
            }

            // Extract the reset session properties
            if (headers.TryGetValues(prestoHeader.ClearSession(), out Temp))
            {
                this.ResetSessionProperties = new HashSet<string>(Temp);
            }
            else
            {
                this.ResetSessionProperties = new HashSet<string>();
            }

            // Extract added prepare
            this.AddedPrepare = new Dictionary<string, string>();

            if (headers.TryGetValues(prestoHeader.AddedPrepare(), out Temp))
            {
                foreach (string Value in Temp)
                {
                    string[] Parts = Value.Split('=').Select(x => x.Trim()).ToArray();

                    if (Parts.Length != 2)
                    {
                        continue;
                    }

                    AddedPrepare.Add(WebUtility.UrlDecode(Parts[0]), WebUtility.UrlDecode(Parts[1]));
                }
            }

            // Get the deallocated prepared statements
            if (headers.TryGetValues(prestoHeader.DeallocatedPrepare(), out Temp))
            {
                this.DeallocatedPreparedStatements = new HashSet<string>(Temp.Select(x => WebUtility.UrlDecode(x)));
            }
            else
            {
                this.DeallocatedPreparedStatements = new HashSet<string>();
            }

            // Get the started transactionid
            if (headers.TryGetValues(prestoHeader.StartedTransactionId(), out Temp))
            {
                this.StartedTransactionId = Temp.FirstOrDefault();
            }

            // Check is clear transaction id was set
            bool ClearTransactionId = headers.Contains(prestoHeader.ClearTransactionId());
        }

        #endregion
    }
}
