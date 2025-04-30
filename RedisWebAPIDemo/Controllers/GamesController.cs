using Microsoft.AspNetCore.Mvc;
using RedisWebAPIDemo.Models;
using RedisWebAPIDemo.Services;

namespace RedisWebAPIDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    private readonly GamesService _gamesService;
    private readonly RedisCacheService _cacheService;
    private bool _isFromCache = false;
    public GamesController(GamesService gamesService, RedisCacheService cacheService)
    {
        _gamesService = gamesService;
        _cacheService = cacheService;
    }
    [HttpGet]
    public IActionResult GetAllGames()
    {
        var instanceId = GetInstanceId();
        var cacheKey = $"Games_Cache_{instanceId}";

        var games = _cacheService.GetCachedData<List<Game>>(cacheKey);

        if (games == null)
        {
            games = _gamesService.LoadGames();
            _cacheService.SetCachedData(cacheKey, games, TimeSpan.FromSeconds(60));
            _isFromCache = false;
        }
        else
            _isFromCache = true;
        return Ok(new
        {
            Games = games,
            IsFromCache = _isFromCache
        });
    }
    private string GetInstanceId()
    {
        var instanceId = HttpContext.Session.GetString("InstanceId");

        if (string.IsNullOrEmpty(instanceId))
        {
            instanceId = Guid.NewGuid().ToString();
            HttpContext.Session.SetString("InstanceId", instanceId);
        }

        return instanceId;
    }
}
