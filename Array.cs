using System;
using System.Collections.Concurrent;

public sealed class Array<T> : IArray<T> 
{
    private Random random;
    private T[] array;
    private int size;
    

    public Array(Func<T[], bool, T[]> action) 
    {    
        InitializeArray(action);
    }


    private void InitializeArray(Func<T[], bool, T[]> action)
    {
        Console.Write("Enter 'true' for user input or 'false' for random input: ");
        string userInput = Console.ReadLine();

        bool.TryParse(userInput, out bool isUserInput);
        
        if (isUserInput)
        {
            array = new T[int.Parse(Console.ReadLine())];
        }
        else
        {
            array = new T[size];
        }
        array = action(array, isUserInput);
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
    

    public void Add(T _array)
    {
        if (size == array.Length)
        {
            Array.Resize(ref array, array.Length * 2 + 1);
        }
        array[size] = _array;
        size++;
    }


    public void Sort()
    {
        Array.Sort(array);
    }

}