using GamesApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication_Final_Project.Services
{
    public interface IGameService
    {
        List<Game> Get();

        List<Game> Get(GameQueryParameters filterParameters);

        Game Get(int id);

        Game Create(Game game);

        Game Update(int id, Game game);

        Game Delete(int id);
    }
}
