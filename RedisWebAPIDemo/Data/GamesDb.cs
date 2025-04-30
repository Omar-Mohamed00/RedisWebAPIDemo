using RedisWebAPIDemo.Models;

namespace RedisWebAPIDemo.Data
{
    public static class GamesDb
    {
        public static List<Game> GetAllGames() => new List<Game>
        {
            new Game { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Genre = "Action-adventure", Platform = "Nintendo Switch", ReleaseYear = 2017 },
            new Game { Id = 2, Title = "The Witcher 3: Wild Hunt", Genre = "Action role-playing", Platform = "PC, PS4, Xbox One, Nintendo Switch", ReleaseYear = 2015 },
            new Game { Id = 3, Title = "Dark Souls III", Genre = "Action role-playing", Platform = "PC, PS4, Xbox One", ReleaseYear = 2016 },
            new Game { Id = 4, Title = "God of War", Genre = "Action-adventure", Platform = "PS4", ReleaseYear = 2018 },
            new Game { Id = 5, Title = "Red Dead Redemption 2", Genre = "Action-adventure", Platform = "PC, PS4, Xbox One", ReleaseYear = 2018 }
        };
    }
}
