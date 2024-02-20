using System.Collections.Generic;
using ASP.Server.Models;

namespace ASP.Server.Dtos;

public class BookWContentDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }
    public List<Genre> Genres { get; set; }
}