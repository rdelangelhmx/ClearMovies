using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Common.UOW
{
    public class Paginate<TEntity> : IPaginate<TEntity>
    {
        internal Paginate(IEnumerable<TEntity> source, int index, int size, int from)
        {
            var enumerable = source as TEntity[] ?? source.ToArray();

            if (from > index)
                throw new ArgumentException($"indexFrom: {from} > pageIndex: {index}, must indexFrom <= pageIndex");

            if (source is IQueryable<TEntity> querable)
            {
                Index = index;
                Size = size;
                From = from;
                Count = querable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);
                if (Pages > 1)
                    Items = querable.Skip((Index - 1) * Size).Take(Size).ToList();
                else
                    Items = querable.ToList();
            }
            else
            {
                Index = index;
                Size = size;
                From = from;

                Count = enumerable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);

                if (Pages > 1)
                    Items = enumerable.Skip((Index - 1) * Size).Take(Size).ToList();
                else
                    Items = enumerable.ToList();
            }
        }

        internal Paginate()
        {
            Items = new TEntity[0];
        }

        public int From { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public IEnumerable<TEntity> Items { get; set; }
        public bool HasPrevious => Index - 1 > 0;
        public bool HasNext => Index < Pages;
    }


    internal class Paginate<TSource, TResult> : IPaginate<TResult>
    {
        public Paginate(IEnumerable<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
            int index, int size, int from)
        {
            var enumerable = source as TSource[] ?? source.ToArray();

            if (from > index) throw new ArgumentException($"From: {from} > Index: {index}, must From <= Index");

            if (source is IQueryable<TSource> queryable)
            {
                Index = index;
                Size = size;
                From = from;
                Count = queryable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);

                if (Pages > 1)
                    Items = new List<TResult>(converter(queryable.Skip((Index - From) * Size).Take(Size).ToArray()));
                else
                    Items = new List<TResult>(converter(queryable.ToArray()));

            }
            else
            {
                Index = index;
                Size = size;
                From = from;
                Count = enumerable.Count();
                Pages = (int)Math.Ceiling(Count / (double)Size);

                if (Pages > 1)
                    Items = new List<TResult>(converter(enumerable.Skip((Index - From) * Size).Take(Size).ToArray()));
                else
                    Items = new List<TResult>(converter(enumerable.ToArray()));
            }
        }


        public Paginate(IPaginate<TSource> source, Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            Index = source.Index;
            Size = source.Size;
            From = source.From;
            Count = source.Count;
            Pages = source.Pages;

            Items = new List<TResult>(converter(source.Items));
        }

        public int Index { get; }

        public int Size { get; }

        public int Count { get; }

        public int Pages { get; }

        public int From { get; }

        public IEnumerable<TResult> Items { get; }

        public bool HasPrevious => Index - From > 0;

        public bool HasNext => Index - From + 1 < Pages;

    }

    public static class Paginate
    {
        public static IPaginate<TEntity> Empty<TEntity>()
        {
            return new Paginate<TEntity>();
        }

        public static IPaginate<TResult> From<TResult, TSource>(IPaginate<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            return new Paginate<TSource, TResult>(source, converter);
        }
    }
}
