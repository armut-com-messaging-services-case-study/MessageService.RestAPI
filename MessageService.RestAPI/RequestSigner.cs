using MessageService.RestAPI.Objects;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MessageService.RestAPI
{
    public class RequestSigner
    {
        private readonly byte[] _secret;

        /**
         * Constructs a new RequestSigner instance.
         */
        public RequestSigner(byte[] secret)
        {
            _secret = secret;
        }


        public bool IsMatch(string encodedSignature, Request request)
        {
            using (var base64Transform = new FromBase64Transform())
            {
                var signatureBytes = Encoding.ASCII.GetBytes(encodedSignature);
                var decodedSignature = base64Transform.TransformFinalBlock(signatureBytes, 0, signatureBytes.Length);

                return IsMatch(decodedSignature, request);
            }
        }

        public bool IsMatch(byte[] expectedSignature, Request request)
        {
            var actualSignature = ComputeSignature(request);
            return expectedSignature.SequenceEqual(actualSignature);
        }

        private byte[] ComputeSignature(Request request)
        {
            var timestampAndQuery = request.Timestamp + '\n' + request.SortedQueryParameters() + '\n';
            var timestampAndQueryBytes = Encoding.UTF8.GetBytes(timestampAndQuery);
            var bodyHashBytes = SHA256.Create().ComputeHash(request.Data);

            var signPayload = new byte[timestampAndQueryBytes.Length + bodyHashBytes.Length];
            Array.Copy(timestampAndQueryBytes, signPayload, timestampAndQueryBytes.Length);
            Array.Copy(bodyHashBytes, 0, signPayload, timestampAndQueryBytes.Length, bodyHashBytes.Length);

            return new HMACSHA256(_secret).ComputeHash(signPayload, 0, signPayload.Length);
        }
    }
}
