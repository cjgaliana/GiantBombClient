using GiantBombClient.Linqify;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GiantBombClient.Games
{
    public class GameRequestProcessor<T> : IRequestProcessor<T> where T : class
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public IList<CustomApiParameter> CustomParameters { get; set; }

        public Dictionary<string, string> GetParameters(LambdaExpression lambdaExpression)
        {
            return
             new ParameterFinder<Game>(
                 lambdaExpression.Body,
                 new List<string> {
                        TakeClauseFinder.TakeMethodName, //Number of team projects to return.
                        SkipClauseFinder.SkipMethodName, //Number of team projects to skip
                        "Id" //If this parameter exists, gets the info for the given ID
                 })
                 .Parameters;
        }

        public Request BuildUrl(Dictionary<string, string> expressionParameters)
        {
            //if (expressionParameters.ContainsKey("Id"))
            //{
            //    return this.GetTGameDetailsUrl(expressionParameters);
            //}

            return this.GetGameListUrl(expressionParameters);
        }

        private Request GetGameListUrl(Dictionary<string, string> expressionParameters)
        {
            // Gerenic call
            var req = new Request(this.BaseUrl + "/games");
            var urlParams = req.RequestParameters;

            if (expressionParameters.ContainsKey(TakeClauseFinder.TakeMethodName))
            {
                var limit = 0;
                if (int.TryParse(expressionParameters[TakeClauseFinder.TakeMethodName], out limit))
                {
                    if (limit > GiantBombConstants.MAX_REQUEST_LIMIT)
                    {
                        throw new ArgumentOutOfRangeException("limit", "The number of results to display per page can not be greather than " + GiantBombConstants.MAX_REQUEST_LIMIT);
                    }
                    urlParams.Add(new QueryParameter("limit", limit.ToString()));
                }
                else
                {
                    throw new ArgumentException("It's not possible parse the TAKE value to a number", "limit");
                }
            }

            if (expressionParameters.ContainsKey(SkipClauseFinder.SkipMethodName))
            {
                urlParams.Add(new QueryParameter("offset", expressionParameters[SkipClauseFinder.SkipMethodName]));
            }

            urlParams.Add(new QueryParameter("api_key", this.ApiKey));
            urlParams.Add(new QueryParameter("format", "json"));

            return req;
        }

        private Request GetTeamProjectDetailsUrl(Dictionary<string, string> expressionParameters)
        {
            var id = expressionParameters["Id"];

            var url = string.Format("{0}{1}{2}", this.BaseUrl, "/game/{0}/", id);
            var req = new Request(url);
            var urlParams = req.RequestParameters;

            urlParams.Add(new QueryParameter("api_key", this.ApiKey));
            urlParams.Add(new QueryParameter("format", "json"));
            return req;
        }

        public List<T> ProcessResults(string vsoResponse)
        {
            return new List<T>();
        }

        //public List<T> ProcessResults(string vsoResponse)
        //{
        //    var json = JObject.Parse(vsoResponse);

        //    if (this.IsSingleProjectDetailsResponse(json))
        //    {
        //        return this.ProccessSinlgeResult(vsoResponse);
        //    }

        //    var serverData = json["value"].Children().ToList();
        //    return serverData.Select(item => JsonConvert.DeserializeObject<T>(item.ToString())).ToList();
        //}

        //private List<T> ProccessSinlgeResult(string vsoResponse)
        //{
        //    var item = JsonConvert.DeserializeObject<T>(vsoResponse);
        //    return new List<T>() { item };
        //}

        //private bool IsSingleProjectDetailsResponse(JObject json)
        //{
        //    JToken token = null;
        //    json.TryGetValue("value", out token);

        //    return token == null;
        //}
    }
}