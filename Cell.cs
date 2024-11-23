public class Cell
{
    public char Type { get; set; } // ' ', 'S', 'O', 'T'
    public bool Visited { get; set; } // For the generation algorithm
    public int Row { get; set; } // Row position of the cell
    public int Col { get; set; } // Column position of the cell

    public Cell(int row, int col)
    {
        Type = ' '; // Initially empty
        Visited = false;
        Row = row; // Set the row position
        Col = col; // Set the column position
    }
}
