class Program
{
    static void Main(string[] args)
    {
        GameSettings settings = new GameSettings();
        settings.ConfigureGame(); // Configures the game settings based on user input

        // Asegúrate de pasar el tamaño del tablero y el número total de jugadores
        Board board = new Board(settings.BoardSize, settings.Players.Count);
        board.ShowBoard();
    }
}
