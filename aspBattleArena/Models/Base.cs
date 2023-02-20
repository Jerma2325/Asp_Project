using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aspBattleArena.Data;
using Microsoft.EntityFrameworkCore;

namespace aspBattleArena.Models;

public class Base
{
    [Key]
    
    public int BaseID { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public Organization Organization { get; set; }

    public Base()
    {
        
    }

    
}