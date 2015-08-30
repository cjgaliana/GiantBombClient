using GiantBombClient.Games;
using GiantBombClient.Linqify;

namespace GiantBombClient.Context
{
    public partial class GiantBoomContext
    {
        public LinqifyQueryable<Game> Games
        {
            get
            {
                return new LinqifyQueryable<Game>(this);
            }
        }
    }
}