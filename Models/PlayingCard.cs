
namespace CardVaultApp.Models;

public class PlayingCard
{
    public int ID { get; set; }
    public string Suit { get; set; }
    public string Value { get; set; }
    public string Condition { get; set; }
    public int Year { get; set; }
    public string ImageUrl { get; set; }

    public List<Grading> Gradings { get; set; } = new();

}
