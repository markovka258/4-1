using System;
using System.Collections.Concurrent;

sealed class Array<T> : ArrayBase<T> 
{
    private Random random;
    private IValueProvider<T> _provider;
    private T[] array;

    public Array(IValueProvider<T> provider) 
    {    
        _provider = provider;

        InitializeArray();
    }

    protected override void ArrUsInp()
     {
        Console.Write("Enter the length of the array1: ");
        string lengthInput = Console.ReadLine();

        int.TryParse(lengthInput, out int length);

        array = new T[length];

        Console.WriteLine($"Введите {array.Length} значений:");

        for (int i = 0; i < array.Length; i++)
        {
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int value))
            {
                array[i] = (T)(object)value;
            }
            else
            {
                throw new ArgumentException("Invalid user input");
            }
        }
    }




    protected override void ArrRand()
    {        
        Console.Write("Enter the length of the array1: ");
        string lengthInput = Console.ReadLine();

        int.TryParse(lengthInput, out int length);
        
        array = new T[length];
        
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = _provider.GetRandomValue();
        }
    }

    public override void Print()
    {
        foreach (T value in array)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();
    }

}