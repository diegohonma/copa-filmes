﻿using MoviesCup.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesCup.Application.Interfaces
{
    public interface ICreateChampionshipService
    {
        Task<ChampionshipModel> CreateChampionship(List<MovieModel> moviesModel);
    }
}
