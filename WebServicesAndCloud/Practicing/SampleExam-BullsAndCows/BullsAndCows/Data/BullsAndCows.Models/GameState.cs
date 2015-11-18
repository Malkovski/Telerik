namespace BullsAndCows.Models
{
    using System;
    using System.Linq;

    public enum GameState
    {
        WaitingForOpponent = 0,
        BlueInTurn = 1,
        RedInTurn = 2,
        Finished = 3
    }
}
