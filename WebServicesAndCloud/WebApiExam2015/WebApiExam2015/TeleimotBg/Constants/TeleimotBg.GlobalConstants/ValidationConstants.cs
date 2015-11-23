namespace TeleimotBg.GlobalConstants
{
    using System;
    using System.Linq;

    public class ValidationConstants
    {
        public const int MinTitleLen = 5;
        public const int MaxTitleLen = 50;

        public const int MinDescriprionLen = 10;
        public const int MaxDescriptionLen = 1000;

        public const int MinAllowedYear = 1800;
        public const int MaxAllowedYear = 2015;

        public const int MinCommentLen = 10;
        public const int MaxCommentLen = 500;

        public const int PriceMinValue = 0;
        public const int PriceMaxValue = int.MaxValue;
    }
}
