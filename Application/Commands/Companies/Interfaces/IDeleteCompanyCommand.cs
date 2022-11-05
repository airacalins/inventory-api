using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Commands.Companies.Interfaces
{
    public interface IDeleteCompanyCommand
    {
        Task ExecuteCommand(Guid id);
    }
}