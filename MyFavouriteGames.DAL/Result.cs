using System.Collections.Generic;

namespace MyFavouriteGames.DAL
{
    public class Result
    {
        public bool IsSuccessful { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string ErrorsFormatted => string.Join(" ", Errors);

        public Result(bool isSuccessful) => IsSuccessful = isSuccessful;

        public Result(bool isSuccessful, params string[] errors)
        {
            IsSuccessful = isSuccessful;
            Errors.AddRange(errors);
        }
    }
}
