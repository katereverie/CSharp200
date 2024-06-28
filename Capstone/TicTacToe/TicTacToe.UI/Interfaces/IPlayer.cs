namespace TicTacToe.UI.Interfaces
{
    public interface IPlayer
    {
        /*  Players' output should be an integer (1-9)
         *  It is not the concern of players but rather of GameManager to track which positions have been picked or not;
         */
        char Symbol { get; set; }

        int GetPosition(char[] currentBoard);
    }
}
