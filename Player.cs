public class Player
{
     public string Name { get; set; } // Player's name
     public List<Piece> PieceList { get; set; } // Player's pieces

     public Player(string name)
     {
         Name = name;
         PieceList = new List<Piece>();
     }

     public void AddPiece(Piece piece)
     {
         PieceList.Add(piece); // Add a piece to the player's collection
     }
}
