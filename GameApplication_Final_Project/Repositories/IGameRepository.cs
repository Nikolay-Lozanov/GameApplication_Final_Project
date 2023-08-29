using GamesApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication_Final_Project.Repositories
{
    public interface IGameRepository
    {
        List<Game> Get();

        List<Game> Get(GameQueryParameters filterParameters);

        Game Get(int id);

        Game Get(string name);

        Game Create(Game game);

        Game Update(int id, Game game);

        Game Delete(int id);
    }
}
