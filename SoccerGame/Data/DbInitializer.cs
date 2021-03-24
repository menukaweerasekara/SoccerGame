using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoccerGame.Models;

namespace SoccerGame.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GameContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Players.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
            {
                new Player { FirstMidName = "Carson",   LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2016-09-01") },
                new Player { FirstMidName = "Meredith", LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2018-09-01") },
                new Player { FirstMidName = "Arturo",   LastName = "Anand",
                    EnrollmentDate = DateTime.Parse("2019-09-01") },
                new Player { FirstMidName = "Gytis",    LastName = "Barzdukas",
                    EnrollmentDate = DateTime.Parse("2018-09-01") },
                new Player { FirstMidName = "Yan",      LastName = "Li",
                    EnrollmentDate = DateTime.Parse("2018-09-01") },
                new Player { FirstMidName = "Peggy",    LastName = "Justice",
                    EnrollmentDate = DateTime.Parse("2017-09-01") },
                new Player { FirstMidName = "Laura",    LastName = "Norman",
                    EnrollmentDate = DateTime.Parse("2019-09-01") },
                new Player { FirstMidName = "Nino",     LastName = "Olivetto",
                    EnrollmentDate = DateTime.Parse("2011-09-01") }
            };

            context.Players.AddRange(players);
            context.SaveChanges();

            var teams = new Team[]
            {
                new Team { Name = "Manchester",     
                    HireDate = DateTime.Parse("1995-03-11") },
                new Team { Name = "Liverpool",    
                    HireDate = DateTime.Parse("2002-07-06") },
                new Team { Name = "Arsenal",   
                    HireDate = DateTime.Parse("1998-07-01") },
              
            };

            context.Teams.AddRange(teams);
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "Goal Keepers",     Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    TeamID  = teams.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Strikers", Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    TeamID  = teams.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Defenders", Budget = 350000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    TeamID  = teams.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "MidFielder",   Budget = 100000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    TeamID  = teams.Single( i => i.LastName == "Kapoor").ID }
            };

            context.Departments.AddRange(departments);
            context.SaveChanges();

            var coaches = new Coach[]
            {
                new Coach {CoachID = 1050, FirstMidName = "James",     LastName = "Vvang",     
                    DepartmentID = departments.Single( s => s.Name == "Goal Keelpers").DepartmentID
                },
                new Coach {CoachID = 4022, FirstMidName = "Jesse",     LastName = "Pope",
                    DepartmentID = departments.Single( s => s.Name == "Midfielder").DepartmentID
                },
                new Coach {CoachID = 4041, FirstMidName = "Kevin",     LastName = "Pakkad",
                    DepartmentID = departments.Single( s => s.Name == "Defenders").DepartmentID
                },
                new Coach {CoachID = 1045,FirstMidName = "Peter",     LastName = "Brown",
                    DepartmentID = departments.Single( s => s.Name == "Strikers").DepartmentID
                },
                new Coach {CoachID = 3141,FirstMidName = "Ali",     LastName = "Mose",
                    DepartmentID = departments.Single( s => s.Name == "Midfielder").DepartmentID
                },
                new Coach {CoachID = 2021, FirstMidName = "Mark",     LastName = "Lang",
                    DepartmentID = departments.Single( s => s.Name == "Defenders").DepartmentID
                },
                new Coach {CoachID = 2042, FirstMidName = "Marcus",     LastName = "Babu",
                    DepartmentID = departments.Single( s => s.Name == "Strikers").DepartmentID
                },
            };

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            var soccerAssignments = new SoccerAssignment[]
            {
                new SoccerAssignment {
                    TeamID = teams.Single( i => i.LastName == "Manchester").ID,
                    Location = "Manchester UK" },
                new SoccerAssignment {
                    TeamID = teams.Single( i => i.LastName == "Liverpool").ID,
                    Location = "LiverPool England" },
                new SoccerAssignment {
                    TeamID = teams.Single( i => i.LastName == "Arsenal").ID,
                    Location = "London" },
            };

            context.SoccerAssignments.AddRange(soccerAssignments);
            context.SaveChanges();

            var gameAssignments = new GameAssignment[]
            {
                new GameAssignment {
                    CoachID = coaches.Single(c => c.FirstMidName == "Ali" ).CoachID,
                    TeamID = teams.Single(i => i.Name == "Liverpool").ID
                    },
                new GameAssignment {
                    CoachID = coaches.Single(c => c.FirstMidName == "Peter" ).CoachID,
                    TeamID = teams.Single(i => i.Name == "Manchester").ID
                    },
                new GameAssignment {
                    CoachID = coaches.Single(c => c.FirstMidName == "Mark" ).CoachID,
                    TeamID = teams.Single(i => i.Name == "Liverpool").ID
                    },
                new GameAssignment {
                    CoachID = coaches.Single(c => c.FirstMidName == "Marcus" ).CoachID,
                    TeamID = teams.Single(i => i.Name == "Arsenal").ID
                    },
                new GameAssignment {
                    CoachID = coaches.Single(c => c.FirstMidName == "Kevin" ).CoachID,
                    TeamID = teams.Single(i => i.Name == "Manchester").ID
                    },
                new GameAssignment {
                    CoachID = coaches.Single(c => c.FirstMidName == "Jesse" ).CoachID,
                    TeamID = teams.Single(i => i.Name == "Liverpool").ID
                    },
                new GameAssignment {
                    CoachID = coaches.Single(c => c.FirstMidName == "James" ).CoachID,
                    TeamID = teams.Single(i => i.Name == "Arsenal").ID
                    },
                new GameAssignment {
                    CoachID = coaches.Single(c => c.FirstMidName == "Literature" ).CoachID,
                    TeamID = teams.Single(i => i.Name == "Manchester").ID
                    },
            };

            context.SoccerAssignments.AddRange(soccerAssignments);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    PlayerID = players.Single(s => s.LastName == "Alexander").ID,
                    TeamID = teams.Single(c => c.Name == "Manchester" ).ID,
                    
                },
                    new Enrollment {
                    PlayerID = players.Single(s => s.LastName == "Alexander").ID,
                    TeamID = teams.Single(c => c.Name == "Arsenal" ).ID,
                   
                    },
                    new Enrollment {
                    PlayerID = players.Single(s => s.LastName == "Alexander").ID,
                    TeamID = teams.Single(c => c.Name == "Arsenal" ).ID,
                    
                    },
                    new Enrollment {
                        PlayerID = players.Single(s => s.LastName == "Alonso").ID,
                    TeamID = teams.Single(c => c.Name == "Arsenal" ).ID,
                   
                    },
                    new Enrollment {
                        PlayerID = players.Single(s => s.LastName == "Alonso").ID,
                    TeamID = teams.Single(c => c.Name == "Arsenal" ).ID,
                   
                    },
                    new Enrollment {
                    PlayerID = players.Single(s => s.LastName == "Alonso").ID,
                    TeamID = teams.Single(c => c.Name == "Liverpool" ).ID,
                
                    },
                    new Enrollment {
                    PlayerID = players.Single(s => s.LastName == "Anand").ID,
                    TeamID = teams.Single(c => c.Name == "Liverpool" ).ID
                    },
                    new Enrollment {
                    PlayerID = players.Single(s => s.LastName == "Anand").ID,
                    TeamID = teams.Single(c => c.Name == "Liverpool;").ID,
                 
                    },
                new Enrollment {
                    PlayerID = players.Single(s => s.LastName == "Barzdukas").ID,
                    TeamID = teams.Single(c => c.Name == "Manschester").ID,
 
                    },
                    new Enrollment {
                    PlayerID = players.Single(s => s.LastName == "Li").ID,
                    TeamID = teams.Single(c => c.Name == "Manschester").ID,

                    },
                    new Enrollment {
                    PlayerID = players.Single(s => s.LastName == "Justice").ID,
                    TeamID = teams.Single(c => c.Name == "Manschester").ID,

                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Player.ID == e.PlayerID &&
                            s.Coach.CoachID == e.CoachID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}