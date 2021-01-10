using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robson.Testes.DataBuilder
{
    public interface IBuilder<T>
    {
        T BuildSingleState();
        List<T> BuildListState();
        void Reset();
    }
}
