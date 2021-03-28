using SoccerGame.Data;
using SoccerGame.Models;
using SoccerGame.Models.GamelViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace SoccerGame.Pages.Teams
{
    public class TeamCoachesPageModel : PageModel
    {

        public List<AssignedCoachData> AssignedCoachDataList;

        public void PopulateAssignedCoachData(GameContext context,
                                               Team team)
        {
            var allcoach = context.Coaches;
            var teamCoaches = new HashSet<int>(
                team.SoccerAssignment.Select(c => c.CoachID));
            AssignedCoachDataList = new List<AssignedCoachData>();
            foreach (var coach in allcoach)
            {
                AssignedCoachDataList.Add(new AssignedCoachData
                {
                    CoachID = coach.CoachID,
                    FirstMidName = coach.FirstMidName,
                    Assigned = teamCoaches.Contains(coach.CoachID)
                });
            }
        }

        public void UpdateTeamCoaches(GameContext context,
            string[] selectedCoaches, Team teamToUpdate)
        {
            if (selectedCoaches == null)
            {
                teamToUpdate.SoccerAssignment = new List<SoccerAssignment>();
                return;
            }

            var selectedCoachesHS = new HashSet<string>(selectedCoaches);
            var teamCoaches = new HashSet<int>
                (teamToUpdate.SoccerAssignment.Select(c => c.Coach.CoachID));
            foreach (var coach in context.Coaches)
            {
                if (selectedCoachesHS.Contains(coach.CoachID.ToString()))
                {
                    if (!teamCoaches.Contains(coach.CoachID))
                    {
                        teamToUpdate.SoccerAssignment.Add(
                            new SoccerAssignment
                            {
                                TeamID = teamToUpdate.ID,
                                CoachID = coach.CoachID
                            });
                    }
                }
                else
                {
                    if (teamCoaches.Contains(coach.CoachID))
                    {
                        SoccerAssignment coachtoremove
                            = teamToUpdate
                                .SoccerAddignment
                                .SingleOrDefault(i => i.CoachID == coach.CoachID);
                        context.Remove(coachtoremove);
                    }
                }
            }
        }
    }
}