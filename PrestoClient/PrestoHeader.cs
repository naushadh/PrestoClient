namespace BAMCIS.PrestoClient
{
    /// <summary>
    /// Available Presto headers
    /// https://github.com/prestodb/presto/blob/master/presto-client/src/main/java/com/facebook/presto/client/PrestoHeaders.java
    /// </summary>
    public class PrestoHeader
    {
        public PrestoHeader(string prefix) { Prefix = prefix; }

        public string Prefix { get; }

        public string User() { return $"X-{Prefix}-User"; }
        public string Source() { return $"X-{Prefix}-Source"; }
        public string Catalog() { return $"X-{Prefix}-Catalog"; }
        public string Schema() { return $"X-{Prefix}-Schema"; }
        public string TimeZone() { return $"X-{Prefix}-Time-Zone"; }
        public string Language() { return $"X-{Prefix}-Language"; }
        public string Session() { return $"X-{Prefix}-Session"; }
        public string SetCatalog() { return $"X-{Prefix}-Set-Catalog"; }
        public string SetSchema() { return $"X-{Prefix}-Set-Schema"; }
        public string SetSession() { return $"X-{Prefix}-Set-Session"; }
        public string ClearSession() { return $"X-{Prefix}-Clear-Session"; }
        public string PreparedStatement() { return $"X-{Prefix}-Prepared-Statement"; }
        public string AddedPrepare() { return $"X-{Prefix}-Added-Prepare"; }
        public string DeallocatedPrepare() { return $"X-{Prefix}-Deallocated-Prepare"; }
        public string TransactionId() { return $"X-{Prefix}-Transaction-Id"; }
        public string StartedTransactionId() { return $"X-{Prefix}-Started-Transaction-Id"; }
        public string ClearTransactionId() { return $"X-{Prefix}-Clear-Transaction-Id"; }
        public string ClientInfo() { return $"X-{Prefix}-Client-Info"; }
        public string ClientTags() { return $"X-{Prefix}-Client-Tags"; }

        public string CurrentState() { return $"X-{Prefix}-Current-State"; }
        public string MaxWait() { return $"X-{Prefix}-Max-Wait"; }
        public string MaxSize() { return $"X-{Prefix}-Max-Size"; }
        public string TaskInstanceId() { return $"X-{Prefix}-Task-Instance-Id"; }
        public string PageToken() { return $"X-{Prefix}-Page-Sequence-Id"; }
        public string PageNextToken() { return $"X-{Prefix}-Page-End-Sequence-Id"; }
        public string BufferComplete() { return $"X-{Prefix}-Buffer-Complete"; }

        public string DataNextUri() { return $"X-{Prefix}-Data-Next-Uri"; }

        public override string ToString()
        {
            return this.Prefix;
        }
    }
}
