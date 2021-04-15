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
                team.GameAssignments.Select(c => c.CoachID));
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
                teamToUpdate.GameAssignments = new List<GameAssignment>();
                return;
            }

            var selectedCoachesHS = new HashSet<string>(selectedCoaches);
            var teamCoaches = new HashSet<int>
                (teamToUpdate.GameAssignments.Select(c => c.Coach.CoachID));
            foreach (var coach in context.Coaches)
            {
                if (selectedCoachesHS.Contains(coach.CoachID.ToString()))
                {
                    if (!teamCoaches.Contains(coach.CoachID))
                    {
                        teamToUpdate.GameAssignments.Add(
                            new GameAssignment
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
                        GameAssignment coachtoremove
                            = teamToUpdate
                                .GameAssignments
                                .SingleOrDefault(i => i.CoachID == coach.CoachID);
                        context.Remove(coachtoremove);
                    }
                }
            }
        }
    }
}