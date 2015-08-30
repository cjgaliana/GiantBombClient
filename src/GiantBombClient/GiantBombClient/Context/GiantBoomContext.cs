using System;
using System.Threading;
using GiantBombClient.Linqify;

namespace GiantBombClient.Context
{
    public partial class GiantBoomContext : LinqifyContext
    {

        public GiantBoomContext(string apiKey)
        {
            this.ApiKey = apiKey;
            this.Executor = new GiantBoomExecutor();
           
        }

        public string ApiKey { get; set; }


        protected internal override IRequestProcessor<T> CreateRequestProcessor<T>(string requestType)
        {
            var request = RequestProcessorFactory.Create<T>(requestType);
            request.CustomParameters = this._customParameters;
            request.BaseUrl = GiantBombConstants.BASE_URL;
            request.ApiKey = this.ApiKey;
            return request;
        }
    }
}