using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TplProducerConsumer.Interfaces
{
    public interface IProcessor<TData, TError>
    {
        void RunAndWait();
    }
}
