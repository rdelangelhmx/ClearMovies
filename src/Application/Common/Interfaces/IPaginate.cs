using System.Collections.Generic;

namespace Application.Common.Interfaces
{
    public interface IPaginate<TEntity>
    {
        int From { get; }
        int Index { get; }
        int Size { get; }
        int Count { get; }
        int Pages { get; }
        IEnumerable<TEntity> Items { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }
    }
}
