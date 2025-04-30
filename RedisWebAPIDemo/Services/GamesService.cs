using RedisWebAPIDemo.Data;
using RedisWebAPIDemo.Models;
using System.Text.Json;

namespace RedisWebAPIDemo.Services
{
    public class GamesService
    {
        public List<Game> LoadGames() => GamesDb.GetAllGames();
        public Game LoadGame() => GamesDb.GetAllGames().Single(g=>g.Id == 1);

    }
}
