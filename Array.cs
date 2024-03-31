using System;
using System.Collections.Generic;

public sealed class Array<T> : IArray<T>
{
    private T[] array;
    private int size;
    private int capacity;

    

    public Array(int _capacity) 
    {
        array = new T[_capacity];
        capacity = _capacity;
        size = 0;
    }


    public Array():this(7)
    {
    }



    public void Print()
    {
        Console.WriteLine("Array");
        foreach (T value in array)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }



    public void Add(T el)
    {
        if(size>=capacity)
        {
            capacity = 2 * capacity + 1;
            T[] arr = new T[capacity];
            Array.Copy(array, arr,size);
            array = arr;
        }
        array[size] = el;
        size++;
    }


    

    public void Remove(int i)
    {
        if(i<=size)
        {
            T[] arr = new T[capacity];
            for (int t = 0; t < size; t++)
            {
                if (t != i)
                {
                    arr[t] = array[t];
                }
            }
            size--;
            array = arr;
        }
    }



    public void Sort()
    {
        Array.Sort(array, 0, size);
    }


    public int Count()
    {
        return size;
    }


    public void CountByCondition(Func<T, bool> condition)
    {
        int n = 0;
        for(int i = 0; i<size; i++)
        {
            if(condition(array[i]))
            {
                n++;
            }
        }
        Console.WriteLine(n);
    }



    public bool EvenIfOne(Func<T, bool> condition)
    {
        for (int i = 0; i < size; i++)
        {
            if (condition(array[i]))
            {
                return true;
            }
        }
        return false;
    }



    public bool ForEach(Func<T, bool> condition)
    {
        for (int i = 0; i < size; i++)
        {
            if (!condition(array[i]))
            {
                return false;
            }
        }
        return true;
    }


    public bool Contains(T el)
    {
        return Array.IndexOf(array, el) >= 0;
    }


    public T Find(Func<T, bool> condition)
    {
        ArgumentNullException.ThrowIfNull(condition);

        for (int i = 0; i < size;i++)
        {
            if (condition(array[i]))
            {
                return array[i];
            }
        }
        throw new Exception("No elements matched this condition");
    }

    public T[] FindAll(Func<T, bool> condition)
    {
        T[] elements = new T[Length(condition)];
        int index = 0;

        for (int i = 0; i < size; i++)
        {
            if (condition(array[i]))
            {
                elements[index] = array[i];
                index++;
            }
        }

        return elements;
    }



    public T Min()
    {
        Comparer<T> comparer = Comparer<T>.Default;

        T min = array[0];

        for (int i = 1; i < size; i++)
        {
            if (comparer.Compare(array[i], min) == -1)
            {
                min = array[i];
            }
        }
        return min;
    }

    public TResult Min<TResult>(Func<T, TResult> projector)
    {
        ArgumentNullException.ThrowIfNull(projector);

        Comparer<TResult> comparer = Comparer<TResult>.Default;

        TResult min = projector(array[0]);

        for (int i = 1; i < size; i++)
        {
            if (comparer.Compare(projector(array[i]), min) < 0)
            {
                min = projector(array[i]);
            }
        }
        return min;
    }

    public T Max()
    {
        Comparer<T> comparer = Comparer<T>.Default;

        T max = array[0];

        for (int i = 1; i < size; i++)
        {
            if (comparer.Compare(array[i], max) > 0)
            {
                max = array[i];
            }
        }
        return max;
    }

    public TResult Max<TResult>(Func<T, TResult> projector)
    {
        ArgumentNullException.ThrowIfNull(projector);

        Comparer<TResult> comparer = Comparer<TResult>.Default;

        TResult max = projector(array[0]);

        for (int i = 1; i < size; i++)
        {
            if (comparer.Compare(projector(array[i]), max) > 0)
            {
                max = projector(array[i]);
            }
        }
        return max;
    }


}