using System;
using System.Collections.Generic;

public sealed class Array<T> : IArray<T>
{
    private T[] array;
    private int size;
    private int capacity;
    // public int Length {get{return size;} set{} }

    

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


    

    public void DelEl(int i)
    {
        if(i<=size)
        {
            T[] mass = new T[capacity];
            for (int t = 0; t < size; t++)
            {
                if (t < i)
                {
                    mass[t] = array[t];
                }
                else if (t > i)
                {
                    mass[t-1] = array[t];
                }
            }
            size--;
            array = mass;
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


    public int CountByCondition(Func<T, bool> condition)
    {
        int n = 0;
        for(int i = 0; i<size; i++)
        {
            if(condition(array[i]))
            {
                n++;
            }
        }
        return n;
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
        if (condition == null)
        {
            throw new ArgumentNullException(nameof(condition));
        }


        for (int i = 0; i < size;i++)
        {
            if (condition(array[i]))
            {
                return array[i];
            }
        }
        throw new Exception("No elements matched this condition");
    }



    public void ApplyToAll(Func<T, T> action)
    {
        for(int i =0; i<size; i++)
        {
            array[i] = action(array[i]);
        }
    }


    public T[] FindAll(Func<T, bool> condition)
    {
        T[] elements = new T[CountByCondition(condition)];
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



    public void Reverse()
    {
        T[] values = new T[size];
        int c =0;
        for (int i = size; i >0; i--)
        {
            values[c] = array[i];
            c++;
        }
        for (int i = 0; i < size; i++)
        {
            array[i] = values[i];
        }
    }



    public T Min()
    {
        T[] values = new T[size];
        for (int i = 0; i < size; i++)
        {
            values[i] = array[i];
        }
        Array.Sort(values);
        return values[0];
    }


    public T Max()
    {
        T[] values = new T[size];
        for (int i = 0; i < size; i++)
        {
            values[i] = array[i];
        }
        Array.Sort(values);
        return values[size-1];
    }







    // public TResult Min<TResult>(Func<T, TResult> projector)
    // {
    //     ArgumentNullException.ThrowIfNull(projector);

    //     Comparer<TResult> comparer = Comparer<TResult>.Default;

    //     TResult min = projector(array[0]);

    //     for (int i = 1; i < size; i++)
    //     {
    //         if (comparer.Compare(projector(array[i]), min) < 0)
    //         {
    //             min = projector(array[i]);
    //         }
    //     }
    //     return min;
    // }






    // public TResult Max<TResult>(Func<T, TResult> projector)
    // {
    //     ArgumentNullException.ThrowIfNull(projector);

    //     Comparer<TResult> comparer = Comparer<TResult>.Default;

    //     TResult max = projector(array[0]);

    //     for (int i = 1; i < size; i++)
    //     {
    //         if (comparer.Compare(projector(array[i]), max) > 0)
    //         {
    //             max = projector(array[i]);
    //         }
    //     }
    //     return max;
    // }


}