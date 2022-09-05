using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    //Here we are inheriting all the Functions of the Generic Repository,
    //as well as adding a new Funciton ‘GetPopularDevelopers’.
    public interface IDeveloperRepository : IGenericRepository<Developer>
    {
        IEnumerable<Developer> GetPopularDevelopers(int count);
    }
}
