using System.Text;

namespace MessageService.RestAPI.Resources.Voice
{
    public class VoiceBaseLists<T> : MessageService.RestAPI.Resources.Voice.VoiceBaseResource<T>
    {
        public VoiceBaseLists(string name, MessageService.RestAPI.Objects.Voice.VoiceBaseList<T> attachedObject)
            : base(name, attachedObject)
        {
        }

        public override string QueryString
        {
            get
            {
                var baseList = (MessageService.RestAPI.Objects.Voice.VoiceBaseList<T>)Object;

                var builder = new StringBuilder();

                if (!string.IsNullOrEmpty(base.QueryString))
                {
                    builder.AppendFormat("{0}&", base.QueryString);
                }

                builder.AppendFormat("limit={0}", baseList.Limit);
                builder.AppendFormat("&");
                builder.AppendFormat("page={0}", baseList.Page);

                return builder.ToString();
            }
        }
    }
}