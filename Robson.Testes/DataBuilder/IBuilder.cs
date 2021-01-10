using System.Collections.Generic;

namespace Robson.Testes.DataBuilder
{
    public interface IBuilder<T>
    {
        T BuildSingleState();
        List<T> BuildListState();
        void Reset();
    }
}
