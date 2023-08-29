using GameApplication_Final_Project.Exceptions;
using GameApplication_Final_Project.Repositories;
using GameApplication_Final_Project.Services;
using GamesApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesApplication.Controllers
{
    //Http Method (Ger Post ...) localhost:38661/api/Games/:id
    //route
    //attribute [api controler]
    //: Controller Base
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService gameService;
        public GamesController(IGameService gameService) 
        {
            this.gameService = gameService;
        }
        //GET localhost:38661/api/games
        [HttpGet]
        public IActionResult Get([FromQuery] GameQueryParameters filterParameters)
        {
            var games = this.gameService.Get(filterParameters);
            return this.StatusCode(StatusCodes.Status200OK, games);
        }

        //GET localhost:38661/api/games/id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var games = this.gameService.Get(id);

                return this.StatusCode(StatusCodes.Status200OK, games);
            }        
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(Game game)
        {
            try
            {
                var createdGame = this.gameService.Create(game);
                return this.StatusCode(StatusCodes.Status200OK, createdGame);
            }
            catch (DuplicateEntityException e)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] Game game)
        {
            if(id != game.Id)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, "Id mismatch");
            }
            try
            {
                var updatedGame = this.gameService.Update(id, game);
                return this.StatusCode(StatusCodes.Status200OK, updatedGame);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
            catch (DuplicateEntityException e)
            {
                return this.StatusCode(StatusCodes.Status409Conflict, e.Message);
            }

        }

        private static readonly List<Game> games = new List<Game>
        {
            new Game
            {
                Id = 1,
                Name = "Arma 3",
                Age = 10,
                Type = "Strategy",
                Price = 40.00
            },
            new Game
            {
                Id = 2,
                Name = "CS:GO",
                Age = 11,
                Type = "Action",
                Price = 0.00
            },
            new Game
            {
                Id= 3,
                Name = "DayZ",
                Age = 10,
                Type = "Survival",
                Price = 80.00
            },
            new Game
            {
                Id= 4,
                Name = "League Of Legents",
                Age = 14,
                Type = "Survival",
                Price = 0.00
            }
        };

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.gameService.Delete(id);
                return this.StatusCode(StatusCodes.Status200OK);
            }
            catch (EntityNotFoundException e)
            {
                return this.StatusCode(StatusCodes.Status404NotFound, e.Message);
            }
        }
    }
}