using System;
namespace ImageStreaming.Api
{
	public class Urls
	{
		public const string Root = "/";

        public const string ApiRoot = "/api";

		public class V1
		{
			internal const string Version = ApiRoot + "/v1";

			public class Event
			{
				public const string Prefix = Version + "/event";

				public const string Get = Prefix + "/get-latest";
                public const string Post = Prefix + "/append";
            }
        }
    }
}

