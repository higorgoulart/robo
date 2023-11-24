using Robo.Domain.Models;

namespace Robo.DTOs;

public class PutBody
{
    public Movimento Movimento { get; set; } 
    public string Valor { get; set; }
}