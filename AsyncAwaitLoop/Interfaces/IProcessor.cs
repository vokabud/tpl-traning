using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitLoop.Interfaces
{
    public interface IProcessor<TData>
    {
        Task RunAndWait();
    }
}
