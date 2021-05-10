using System;

namespace MessageService.RestAPI.Objects
{
    /**
     * Structure used for request signature verification via MessageService.
     */
    public class Request
    {
        internal string Timestamp { get; private set; }
        internal string QueryParameters { get; private set; }
        internal byte[] Data { get; private set; }

        private const char QueryParametersDelimiter = '&';

        /**
         * Constructs a new request instance.
         */
        public Request(string timestamp, string queryParameters, byte[] data)
        {
            if (string.IsNullOrEmpty(timestamp))
            {
                throw new ArgumentNullException("timestamp");
            }

            Timestamp = timestamp;
            QueryParameters = queryParameters;
            Data = data;
        }


        internal string SortedQueryParameters()
        {
            var queryParams = QueryParameters.Split(QueryParametersDelimiter);
            Array.Sort(queryParams);
            return string.Join(QueryParametersDelimiter.ToString(), queryParams);
        }
    }
}
