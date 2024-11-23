public class Board
{
    private Cell[,] CellArray;
    private List<Exit> ExitList;
    private int n;

    public Board(int size, int numberPlayers)
    {
        n = size;
        CellArray = new Cell[n, n];
        ExitList = new List<Exit>();

        InitializeCells();
        GenerateExit(numberPlayers);
        GenerateMaze();
        PlaceObstacles();
        PlaceTraps();
    }

    private void InitializeCells()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                CellArray[i, j] = new Cell(i, j); // Initialize all cells with their positions
            }
        }
    }

    private void GenerateExit(int numberPlayers)
    {
        Random random = new Random();

        for (int i = 0; i < numberPlayers; i++)
        {
            while (true)
            {
                int row = random.Next(n);
                int col = random.Next(n);

                if (!ExitList.Exists(e => e.Row == row && e.Col == col))
                {
                    ExitList.Add(new Exit(row, col));
                    CellArray[row, col].Type = 'S'; // Mark as exit
                    break;
                }
            }
        }
    }

    private void GenerateMaze()
    {
        Stack<Cell> stack = new Stack<Cell>();
        Random random = new Random();

        // Start from a random cell
        int startRow = random.Next(n);
        int startCol = random.Next(n);

        stack.Push(CellArray[startRow, startCol]);
        CellArray[startRow, startCol].Visited = true;

        while (stack.Count > 0)
        {
            Cell currentCell = stack.Peek();
            List<Cell> neighbors = GetNeighbors(currentCell);

            if (neighbors.Count > 0)
            {
                Cell chosenCell = neighbors[random.Next(neighbors.Count)];
                stack.Push(chosenCell);
                chosenCell.Visited = true;
            }
            else
            {
                stack.Pop();
            }
        }
    }

  private List<Cell> GetNeighbors(Cell cell)
{
    List<Cell> neighbors = new List<Cell>();
    
    // Define relative positions for neighbors
    int[,] directions = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

    for (int i = 0; i < directions.GetLength(0); i++) // Iterate over the rows of the directions array
    {
        int newRow = cell.Row + directions[i, 0]; // Access the first element of the current direction
        int newCol = cell.Col + directions[i, 1]; // Access the second element of the current direction

        // Check if newRow and newCol are within bounds
        if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n)
        {
            if (!CellArray[newRow, newCol].Visited)
            {
                neighbors.Add(CellArray[newRow, newCol]); // Add to neighbors if not visited
            }
        }
    }

    return neighbors;
}




    private void PlaceObstacles()
    {
        Random random = new Random();

        int numberObstacles = (int)(n * n * 0.1); // For example, 10% of the board as obstacles

        for (int i = 0; i < numberObstacles; i++)
        {
            while (true)
            {
                int row = random.Next(n);
                int col = random.Next(n);

                if (CellArray[row, col].Type == ' ') // Only place in empty cells
                {
                    CellArray[row, col].Type = 'O'; // Mark as obstacle
                    break;
                }
            }
        }
    }

    private void PlaceTraps()
    {
        Random random = new Random();

        int numberTraps = (int)(n * n * 0.05); // For example, 5% of the board as traps

        for (int i = 0; i < numberTraps; i++)
        {
            while (true)
            {
                int row = random.Next(n);
                int col = random.Next(n);

                if (CellArray[row, col].Type == ' ') // Only place in empty cells
                {
                    CellArray[row, col].Type = 'T'; // Mark as trap
                    break;
                }
            }
        }
    }

    public void ShowBoard()
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(CellArray[i, j].Type + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Exits:");
        foreach (var exit in ExitList)
        {
            Console.WriteLine($"Exit at: ({exit.Row}, {exit.Col})");
        }
    }
}
