﻿using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public Movie Movie { get; set; }

        public string PageHeader
        {
            get
            {
                if (Movie != null && Movie.Id != 0)
                    return "Edit movie";
                else
                    return "New movie";
            }
        }
    }
}