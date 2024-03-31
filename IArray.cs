using System;

interface IArray<T> : IPrinter
    {
        void Add(T el);

        void Remove(int i);

        void Sort();

        int Count();

        void CountByCondition(Func<T, bool> condition);

        bool EvenIfOne(Func<T, bool> condition);

        bool ForEach(Func<T, bool> condition);

        bool Contains(T el);

        T Find(Func<T, bool> condition);
        
        T[] FindAll(Func<T, bool> condition);

        T Min();

        TResult Min<TResult>(Func<T, TResult> projector);

        T Max();

        TResult Max<TResult>(Func<T, TResult> projector);

       }