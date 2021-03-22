﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SoccerGame.Data;
using SoccerGame.Models;

namespace SoccerGame.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly SoccerGame.Data.GameContext _context;

        public IndexModel(SoccerGame.Data.GameContext context)
        {
            _context = context;
        }



        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }


        public PaginatedList<Player> Players { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Player> playersIQ = from s in _context.Players
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                playersIQ = playersIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    playersIQ = playersIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    playersIQ = playersIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    playersIQ = playersIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    playersIQ = playersIQ.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            Players = await PaginatedList<Player>.CreateAsync(
                playersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
