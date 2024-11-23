class Program
{
    static void Main(string[] args)
    {
        int n = 10; // Size of the board
        int numPlayers = 3; // Number of players
        Board board = new Board(n, numPlayers);
        
        // Display the generated board
        board.ShowBoard();
    }
}
