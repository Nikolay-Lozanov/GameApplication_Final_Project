using GameApplication_Final_Project.Exceptions;
using GamesApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication_Final_Project.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly List<Game> games;
       
        public GameRepository()
        {
            this.games = new List<Game>();
            this.games.Add(new Game
            {
                Id = 1,
                Name = "Arma 3",
                Age = 10,
                Type = "Strategy",
                Price = 40.00
            });
            this.games.Add(new Game
            {
                Id = 2,
                Name = "CS:GO",
                Age = 11,
                Type = "Action",
                Price = 0.00
            });
            this.games.Add(new Game
            {
                Id = 3,
                Name = "DayZ",
                Age = 10,
                Type = "Survival",
                Price = 80.00
            });
            this.games.Add(new Game
            {
                Id = 4,
                Name = "League Of Legents",
                Age = 14,
                Type = "Survival",
                Price = 0.00
            });            
        }

        public Game Create(Game game)
        {
            game.Id = games.Count + 1;
            games.Add(game);
            return game;
        }

        public Game Delete(int id)
        {
            var beerToDelete = this.Get(id);
            this.games.Remove(beerToDelete);
            return beerToDelete;
        }

        public List<Game> Get() //get na vsichkite igri
        {
            return this.games;
        }

        public List<Game> Get(GameQueryParameters filterParameters)
        {
            IEnumerable<Game> result = this.games;

            //Zaemane po Ime
            if (!string.IsNullOrEmpty(filterParameters.Name))
            {
                result = result.Where(b => b.Name.Contains(filterParameters.Name, StringComparison.InvariantCultureIgnoreCase)); //ignoring small or big letters
            }


            //Zaemane po Tip 
            if (!string.IsNullOrEmpty(filterParameters.Type))
            {
                result = result.Where(b => b.Type.Contains(filterParameters.Type, StringComparison.InvariantCultureIgnoreCase)); //ignoring small or big letters
            }

            //Zaemane po cena
            if (filterParameters.Price.HasValue)
            {
                result = result.Where(b => b.Price.HasValue && b.Price.Value == filterParameters.Price.Value);
            }

            //Zaemane po Age
            if (filterParameters.Age.HasValue)
            {
                result = result.Where(b => b.Age.HasValue && b.Age.Value == filterParameters.Age.Value);
            }

            //Sortirane
            if (!string.IsNullOrEmpty(filterParameters.SortBy))
            {
                if (filterParameters.SortBy.Equals("name", StringComparison.InvariantCultureIgnoreCase))
                {
                    result.OrderBy(b => b.Name).ToList();
                }
                else if (filterParameters.SortBy.Equals("name", StringComparison.InvariantCultureIgnoreCase))
                {
                    result.OrderBy(b => b.Price).ToList();
                }
            }
            return result.ToList();
        }

        public Game Get(int id)
        {
            var game = games.FirstOrDefault(b => b.Id == id);
            return game ?? throw new EntityNotFoundException();
        }

        public Game Get(string name)
        {
            var game = this.games.Where(b => b.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault(); //ignoring small or big letters
            return game ?? throw new EntityNotFoundException();
        }

        public Game Update(int id, Game game)
        {
            var beerToUpdate = this.Get(id);
            beerToUpdate.Name = game.Name;
            beerToUpdate.Price = game.Price;
            beerToUpdate.Age = game.Age;
            return beerToUpdate;
        }
    }
}
