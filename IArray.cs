using System;

interface IArray<T> : IPrinter
    {
        void Add(T el);

        void DelEl(int i);

        void Sort();

        bool EvenIfOne(Func<T, bool> action);

        bool ForEach(Func<T, bool> action);

        void CountByCondition(Func<T, bool> action);
        
       }