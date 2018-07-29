using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ninject.AzureFunctions.Contracts
{
    public interface IFeature
    {
        Task<IActionResult> Execute();
    }

    public interface IFeature<in TA>
    {
        Task<IActionResult> Execute(TA param1);
    }

    public interface IFeature<in TA, in TB>
    {
        Task<IActionResult> Execute(TA param1,TB param2);
    }

    public interface IFeature<in TA, in TB, in TC>
    {
        Task<IActionResult> Execute(TA param1, TB param2, TC param3);
    }
}
