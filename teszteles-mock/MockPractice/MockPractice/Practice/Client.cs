using System;

namespace MockPractice.Practice
{
    public class Client : IDisposable
    {
		private IService Service { get; }
		private IContentFormatter ContentFormatter { get; }
		private int Identity { get;  }

		public Client(IService service, IContentFormatter contentFormatter, int identity = 2)
        {
			Service = service ?? throw new ArgumentNullException(nameof(service));
			ContentFormatter = contentFormatter ?? throw new ArgumentNullException(nameof(contentFormatter));
			Identity = identity;
		}

        public string GetIdentity()
        {
            return Identity.ToString();
        }

        public string GetIdentityFormatted()
        {
            return $"<formatted> {Identity} </formatted>";
        }

        public string GetServiceName()
        {
            return Service.Name;
        }

        public void Dispose()
        {
			Service.Dispose();
        }

        public string GetContent(long id)
        {
            if(!Service.IsConnected)
            {
                Service.Connect();
            }
            
            var content = Service.GetContent(id);
            return content;
        }

		public string GetContentFormatted(long id)
		{
			var content = GetContent(id);
			var formattedContent = ContentFormatter.Format(content);
			return formattedContent;
		}
	}
}
