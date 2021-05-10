namespace MessageService.RestAPI.Resources.Voice
{
    public class VoiceBaseResource<T> : Resource
    {
        public static string baseUrl = "https://localhost:8080";

        public VoiceBaseResource(string name, MessageService.RestAPI.Objects.IIdentifiable<string> attachedObject) :
            base(name, attachedObject)
        {
            //
        }

        public override string BaseUrl
        {
            get
            {
                return baseUrl;
            }
        }
    }
}