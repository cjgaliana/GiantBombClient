using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using GiantBombClient.Exceptions;
using GiantBombClient.Linqify;

namespace GiantBombClient.Context
{
    public class GiantBoomExecutor : ILinqifyExecutor
    {
        internal const string DefaultUserAgent = "GiantBoomClient/0.1";
        internal const int DefaultReadWriteTimeout = 300000;
        internal const int DefaultTimeout = 100000;

        public void Dispose()
        {

        }

        public HttpClientHandler HttpClientHandler { get; }
        public CancellationToken CancellationToken { get; set; }
        public Uri LastUrl { get; private set; }
        public IDictionary<string, string> ResponseHeaders { get; set; }
        public string UserAgent { get; set; }
        public int ReadWriteTimeout { get; set; }
        public int Timeout { get; set; }
        public async Task<string> QueryApiAsync<T>(Request request, IRequestProcessor<T> reqProc)
        {
            try
            {
                var req = new HttpRequestMessage(HttpMethod.Get, new Uri(request.FullUrl));

                Dictionary<string, string> parms = request.RequestParameters
                    .ToDictionary(
                        key => key.Name,
                        val => val.Value);

                using (var client = new HttpClient(this.HttpClientHandler))
                {
                    if (this.Timeout != 0)
                    {
                        client.Timeout = TimeSpan.FromSeconds(this.Timeout);
                    }
                    HttpResponseMessage msg = await client.SendAsync(req, this.CancellationToken).ConfigureAwait(false);

                    return await this.HandleResponseAsync(msg).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }

        public Task<string> PostToApiAsync<T>(string url, IDictionary<string, string> postData, CancellationToken cancelToken)
        {
            throw new NotImplementedException();
        }

        private async Task<string> HandleResponseAsync(HttpResponseMessage msg)
        {
            this.LastUrl = msg.RequestMessage.RequestUri;

            this.ResponseHeaders =
                (from header in msg.Headers
                 select new
                 {
                     header.Key,
                     Value = string.Join(", ", header.Value)
                 })
                    .ToDictionary(
                        pair => pair.Key,
                        pair => pair.Value);

            await GiantBoomApiErrorHandler.ThrowIfErrorAsync(msg).ConfigureAwait(false);

            return await msg.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }
}