using GameApplication_Final_Project.Exceptions;
using GameApplication_Final_Project.Repositories;
using GamesApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameApplication_Final_Project.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository repository;
        public GameService(IGameRepository repository)
        {
            this.repository = repository;
        }

        public List<Game> Get()
        {
            return this.repository.Get();
        }

        public Game Get(int id)
        {
            return this.repository.Get(id);
        }

        public List<Game> Get(GameQueryParameters filterParameters)
        {
            return this.repository.Get(filterParameters);
        }

        public Game Create(Game game)
        {
            bool duplicateExist = true;
            try
            {
                this.repository.Get(game.Name); 
            }
            catch(EntityNotFoundException)
            {
                duplicateExist = false;
            }

            if(duplicateExist)
            {
                throw new DuplicateEntityException();
            }

            var createdGame = this.repository.Create(game);
            return createdGame;
        }

        public Game Update(int id, Game game)
        {
            bool duplicateExist = true;
            try
            {
                var existingGame = this.repository.Get(game.Name);
                if (existingGame.Id == game.Id)
                {
                    duplicateExist = false;
                }
            }
            catch (EntityNotFoundException)
            {
                duplicateExist = false;
            }

            if (duplicateExist)
            {
                throw new DuplicateEntityException();
            }

            var createdGame = this.repository.Update(id, game);
            return createdGame;
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        Game IGameService.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
