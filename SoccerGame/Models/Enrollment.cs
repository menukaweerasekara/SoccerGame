namespace SoccerGame.Models
{
   

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CoachID { get; set; }
        public int PlayerID { get; set; }
       

        public Coach Coach { get; set; }
        public Player Player { get; set; }
    }
}