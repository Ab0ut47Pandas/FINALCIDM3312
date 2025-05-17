using System; 
namespace CardVaultApp.Models;

public class Grading
{
    public int ID { get; set; }
    public int Grade { get; set; }
    public DateTime GradedDate { get; set; }
    public string Comments { get; set; }

    public int PlayingCardID { get; set; }
    public PlayingCard PlayingCard { get; set; }
}
