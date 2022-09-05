using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    //You can see that the interface and implementations are quite blank.
    //So why create new class and interface for Project?
    //This can also attribute to a good practice while developing applications.
    //We also anticipate that in future, there can be functions that are spcific to the Project Entity.
    //To support them later on, we provide with interfaces and classes. Future Proofing,
    public interface IProjectRepository : IGenericRepository<Project>
    {

    }
}
