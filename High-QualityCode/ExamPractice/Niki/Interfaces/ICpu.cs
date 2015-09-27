namespace Computers.Interfaces
{
    public interface ICpu
    {
        byte NumberOfCores { get; set; }

        string SquareNumber(int data);

        int GetRandomValue(int a, int b);
    }
}