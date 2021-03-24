namespace SoccerGame.Models
{
    public class GameAssignment
    {
        public int TeamID { get; set; }
        public int CoachID { get; set; }
        public Team Team { get; set; }
        public Coach Coach { get; set; }
    }
}