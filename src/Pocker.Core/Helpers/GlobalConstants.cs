namespace Pocker.Core.Helpers
{
    public class GlobalConstants
    {
        // Exceptions
        public const string INVALID_SUITE_EXCEPTION = "Suite type is not valid";
        public const string INVALID_RANK_EXCEPTION = "Rank type is not valid";
        public const string INVALID_NUMBEROFPLAYER_EXCEPTION = "Number of players is not between 2 - 6";
        public const string INVALID_NUMBEROFROUND_EXCEPTION = "Number of rounds is not between 2 - 5";
        // Suites
        public const string SUIT_SPADES = "Spades";
        public const string SUIT_CLUBS = "Clubs";
        public const string SUIT_HEARTS = "Hearts";
        public const string SUIT_DIAMONDS = "Diamonds";

        public static string[] SUITE_LIST = new string[]
        {
            SUIT_SPADES, SUIT_CLUBS, SUIT_HEARTS, SUIT_DIAMONDS
        };

        // Ranks
        public const string RANK_A = "A";
        public const string RANK_K = "K";
        public const string RANK_Q = "Q";
        public const string RANK_J = "J";
        public const string RANK_10 = "10";
        public const string RANK_9 = "9";
        public const string RANK_8 = "8";
        public const string RANK_7 = "7";
        public const string RANK_6 = "6";
        public const string RANK_5 = "5";
        public const string RANK_4 = "4";
        public const string RANK_3 = "3";
        public const string RANK_2 = "2";

        public static string[] RANK_LIST = new string[]
        {
            RANK_A, RANK_K, RANK_Q, RANK_J, RANK_10,
            RANK_9, RANK_8, RANK_7, RANK_6,
            RANK_5, RANK_4, RANK_3, RANK_2
        };
    }
}
