using System.Collections.Generic;
using System.Linq.Expressions;

namespace GiantBombClient.Linqify
{
    public interface IRequestProcessor<T>
    {
        string BaseUrl { get; set; }

        IList<CustomApiParameter> CustomParameters { get; set; }
        string ApiKey { get; set; }

        Dictionary<string, string> GetParameters(LambdaExpression lambdaExpression);

        Request BuildUrl(Dictionary<string, string> expressionParameters);

        List<T> ProcessResults(string apiResponse);
    }
}