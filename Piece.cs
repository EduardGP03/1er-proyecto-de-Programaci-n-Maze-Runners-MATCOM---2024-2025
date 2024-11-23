public class Piece 
{
    public string Name { get; set; } // Name of the piece
    public string Skill { get; set; } // Special ability of the piece
    public int CooldownTime { get; set; } // Cooldown time for ability usage
    public int Speed { get; set; } // Number of cells that can be moved per turn

    public Piece(string name, string skill, int cooldownTime, int speed)
    {
         Name = name;
         Skill = skill;
         CooldownTime = cooldownTime;
         Speed = speed;
     }

}
