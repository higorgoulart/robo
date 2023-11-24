using Microsoft.AspNetCore.Mvc;
using Robo.Context;
using Robo.Domain.Models;
using Robo.Domain.Utils;
using Robo.DTOs;

namespace Robo.Controllers;

[ApiController]
[Route("[controller]")]
public class RoboController : ControllerBase
{
    private readonly IDbContext _dbContext;

    private readonly ILogger<RoboController> _logger;

    public RoboController(IDbContext dbContext, ILogger<RoboController> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(_dbContext.GetRobo());
    }
    
    [HttpGet("cotovelo")]
    public ActionResult GetCotovelo()
    {
        return Ok(EnumUtils.ToDictionary<Cotovelo>());
    }
    
    [HttpGet("pulso")]
    public ActionResult GetPulso()
    {
        return Ok(EnumUtils.ToDictionary<Pulso>());
    }
    
    [HttpGet("inclinacao")]
    public ActionResult GetInclinacao()
    {
        return Ok(EnumUtils.ToDictionary<Inclinacao>());
    }
    
    [HttpGet("rotacao")]
    public ActionResult GetRotacao()
    {
        return Ok(EnumUtils.ToDictionary<Rotacao>());
    }
    
    [HttpPut]
    public Domain.Models.Robo Put([FromBody] PutBody body)
    {
        var robo = _dbContext.GetRobo();
        robo.Movimentar(body.Movimento, body.Valor);
        _dbContext.SaveRobo(robo);
        return robo;
    }
}