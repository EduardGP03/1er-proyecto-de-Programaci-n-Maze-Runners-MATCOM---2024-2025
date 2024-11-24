using System;
using System.Collections.Generic;

public class GameSettings
{
    public int BoardSize { get; private set; }
    public List<Player> Players { get; private set; }
    public int NumberOfPieces { get; private set; } // Number of pieces for all players

    public GameSettings()
    {
        Players = new List<Player>();
    }

    public void ConfigureGame()
    {
        int numPlayers = ChooseNumberOfPlayers();
        BoardSize = DetermineBoardSize(numPlayers);
        
        for (int i = 0; i < numPlayers; i++)
        {
            Console.WriteLine($"Enter name for Player {i + 1}:");
            string name = Console.ReadLine();
            Players.Add(new Player(name));
        }

        // Add AI players if necessary
        if (numPlayers == 1)
        {
            int aiPlayersNeeded = 3; // To make it a total of 4 players
            for (int i = 0; i < aiPlayersNeeded; i++)
            {
                Players.Add(new AIPlayer($"AI Player {i + 1}"));
            }
        }

        // Allow players to choose the same number of pieces
        NumberOfPieces = ChooseNumberOfPieces();

        // Assign the chosen number of pieces to all players
        foreach (var player in Players)
        {
            for (int j = 0; j < NumberOfPieces; j++)
            {
                // Here you could implement logic to let players choose specific pieces
                player.AddPiece(new Piece($"Piece {j + 1}", "Basic Skill", 0, 1));
            }
        }
    }

    private int ChooseNumberOfPlayers()
    {
        int numPlayers;
        do
        {
            Console.WriteLine("Enter number of players (2, 3, or 4):");
            string input = Console.ReadLine();
            
            // Validate input
            if (!int.TryParse(input, out numPlayers) || (numPlayers < 2 || numPlayers > 4))
            {
                Console.WriteLine("Invalid input. Please enter 2, 3, or 4.");
                continue;
            }
            
        } while (numPlayers < 2 || numPlayers > 4);
        
        return numPlayers;
    }

    private int DetermineBoardSize(int numPlayers)
    {
        return numPlayers switch
        {
            4 => 12,
            3 => 10,
            _ => 8, // For 2 players
        };
    }

    private int ChooseNumberOfPieces()
    {
        int numPieces;
        do
        {
            Console.WriteLine("Enter the number of pieces for each player (1 to 3):");
            string input = Console.ReadLine();
            
            // Validate input
            if (!int.TryParse(input, out numPieces) || (numPieces < 1 || numPieces > 3))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                continue;
            }
            
        } while (numPieces < 1 || numPieces > 3);
        
        return numPieces;
    }
}
