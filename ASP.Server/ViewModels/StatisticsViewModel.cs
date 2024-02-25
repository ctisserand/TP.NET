using System.Collections.Generic;

namespace ASP.Server.ViewModels
{
    public class StatisticsViewModel
    {
        public int TotalBooks { get; set; }
        public Dictionary<string, int> BooksPerAuthor { get; set; }
        public int MaxWords { get; set; }
        public int MinWords { get; set; }
        public double AverageWords { get; set; }
        public double MedianWords { get; set; }

    }
}