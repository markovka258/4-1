using System;

interface IArray<T> : IPrinter
    {
        void Add(T _array);

        void Remove(T element);

        void ForEach(Action<T> action);

        TResult[] Project<TResult>(Func<T, TResult> project);

        void Sort();

        void Reverse();

        T[] Get(int index, int count);

        int Count();

        int CountByCondition(Func<T, bool> condition);

        T Max();
        
        T Min();

        TResult Max<TResult>(Func<T, TResult> projector);

        TResult Min<TResult>(Func<T, TResult> projector);

        T Find(Func<T, bool> condition);

        T[] GetByCondition(Func<T, bool> condition);

        bool IfAny(Func<T, bool> condition);
    }