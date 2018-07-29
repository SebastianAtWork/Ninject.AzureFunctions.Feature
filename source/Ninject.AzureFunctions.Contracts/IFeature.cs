using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject.AzureFunctions.Contracts
{
    public interface IFeature
    {
        Task Execute();
    }

    public interface IFeature<TA>
    {
        Task<TA> Execute();
    }

    public interface IFeature<in TA,TB>
    {
        Task<TB> Execute(TA param1);
    }

    public interface IFeature<in TA, in TB, TC>
    {
        Task<TC> Execute(TA param1,TB param2);
    }

    public interface IFeature<in TA, in TB, in TC, TD>
    {
        Task<TD> Execute(TA param1, TB param2, TC param3);
    }
}
