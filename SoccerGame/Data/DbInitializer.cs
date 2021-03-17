using SoccerGame.Data;
using SoccerGame.Models;
using System;
using System.Linq;

namespace SoccerGame.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GameContext context)
        {
             context.Database.EnsureCreated();
          // DbInitializer.Initialize(context);

            // Look for any Players.
            if (context.Players.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
            {
                new Player{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2019-09-01")},
                new Player{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Player{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Player{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Player{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2017-09-01")},
                new Player{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2016-09-01")},
                new Player{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2018-09-01")},
                new Player{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2019-09-01")}
            };

            context.Players.AddRange(players);
            context.SaveChanges();

            var coaches = new Coach[]
            {
                new Coach{CoachID=1050,FirstMidName="Carson",LastName="Xander"},
                new Coach{CoachID=4022,FirstMidName="John",LastName="brown"},
                new Coach{CoachID=4041,FirstMidName="Barry",LastName="Avenger"},
                new Coach{CoachID=1045,FirstMidName="Geoge",LastName="Roger"},
                new Coach{CoachID=3141,FirstMidName="Mark",LastName="Stark"},
                new Coach{CoachID=2021,FirstMidName="Kevin",LastName="John"},
                new Coach{CoachID=2042,FirstMidName="Steven",LastName="Bob"}
            };

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{PlayerID=1,CoachID=1050},
                new Enrollment{PlayerID=1,CoachID=4022},
                new Enrollment{PlayerID=1,CoachID=4041},
                new Enrollment{PlayerID=2,CoachID=1045},
                new Enrollment{PlayerID=2,CoachID=3141},
                new Enrollment{PlayerID=2,CoachID=2021},
                new Enrollment{PlayerID=3,CoachID=1050},
                new Enrollment{PlayerID=4,CoachID=1050},
                new Enrollment{PlayerID=4,CoachID=4022},
                new Enrollment{PlayerID=5,CoachID=4041},
                new Enrollment{PlayerID=6,CoachID=1045},
                new Enrollment{PlayerID=7,CoachID=3141},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}