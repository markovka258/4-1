using System;
using System.Collections.Concurrent;

public sealed class Array<T> : IArray<T>
{
    private Random random;
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


    

    public void DelEl(int i)
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
        else
        {
            Console.WriteLine("Error (Index is out of range)");
        }
    }



    public void Sort()
    {
        Array.Sort(array, 0, size);
    }



    public bool EvenIfOne(Func<T, bool> action)
    {
        for (int i = 0; i < size; i++)
        {
            if (action(array[i]))
            {
                return true;
            }
        }
        return false;
    }



    public bool ForEach(Func<T, bool> action)
    {
        for (int i = 0; i < size; i++)
        {
            if (!action(array[i]))
            {
                return false;
            }
        }
        return true;
    }



    public void CountByCondition(Func<T, bool> action)
    {
        int n = 0;
        for(int i = 0; i<size; i++)
        {
            if(action(array[i]))
            {
                n++;
            }
        }
        Console.WriteLine(n);
    }



}