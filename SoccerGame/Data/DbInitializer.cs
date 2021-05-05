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
                new Player{PlayerName = "Mike Davis", Age = 16, Position = "Defender", TeamID = 1},
                new Player{PlayerName = "Mike Davis", Age = 16, Position = "Midfielder", TeamID = 1},
                new Player{PlayerName = "Mike Davis", Age = 16, Position = "Goalkeeper", TeamID = 1},
                new Player{PlayerName = "Mike Davis", Age = 16, Position = "Attacker", TeamID = 1},
                new Player{PlayerName = "Mike Davis", Age = 16, Position = "Attacker", TeamID = 1},
                new Player{PlayerName = "Mike Davis", Age = 16, Position = "Defender", TeamID = 1},


            };

            context.Players.AddRange(players);
            context.SaveChanges();

            var teams = new Team[]
            {
                new Team{TeamName = "Manchester", DivisionID = 1},
                new Team{TeamName = "LiverPool", DivisionID = 1},
                new Team{TeamName = "Chelsea", DivisionID = 1},
              

                  new Team{TeamName = "Arsenal  ", DivisionID = 2},
                   new Team{TeamName = "Inter Milan", DivisionID = 2},
                    new Team{TeamName = "Barcelona", DivisionID = 2},
                     

                     new Team{TeamName = "Tottemham", DivisionID = 3},
                      new Team{TeamName = "Juventus", DivisionID = 3},
                       new Team{TeamName = "A.C Milan", DivisionID = 3},
                        

                        new Team{TeamName = "Roma", DivisionID = 4},
                         new Team{TeamName = "Galaxy", DivisionID = 4},
                            new Team{TeamName = "Toronto", DivisionID = 4}
                              


            };

            context.Teams.AddRange(teams);
            context.SaveChanges();





            var divisions = new Division[]
            {
               new Division {Division_Name = "Major League", Location = "USA"},
            new Division { Division_Name = "USL Championship", Location = "UK" },
               new Division {Division_Name = "USL League One ", Location = "Canda"},
               new Division {Division_Name = "USL League Two ", Location = "New Zealand" }
            };

            context.Divisions.AddRange(divisions);
            context.SaveChanges();

           

           
           
        }
    }
}