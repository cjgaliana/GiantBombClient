using GiantBombClient.Linqify;
using System;
using GiantBombClient.Games;

namespace GiantBombClient.Context
{
    public static class RequestProcessorFactory
    {
        public static IRequestProcessor<T> Create<T>(string requestType) where T : class
        {
            switch (requestType)
            {
                case "Game":
                    return new GameRequestProcessor<T>();

                default:
                    throw new ArgumentException("Type " + requestType + "is not a supportend entity", "requestType");
            }
        }
    }
}