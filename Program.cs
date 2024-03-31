﻿using System;
internal class Program
{
    static void Main()
    {
        Array<int> intArray = new Array<int>(10);
        Array<double> doubleArray = new Array<double>(5);

        intArray.Add(4);
        intArray.Add(14);
        intArray.Add(111);
        intArray.Add(-80);

        intArray.Print();


        doubleArray.Add(23.11);
        doubleArray.Add(-7.5);
        doubleArray.Add(912.65);

        doubleArray.Print();

        intArray.DelEl(3);
        intArray.Print();
        doubleArray.DelEl(2);
        doubleArray.Print();

        intArray.Sort();
        intArray.Print();
        doubleArray.Sort();
        doubleArray.Print();

        // intArray.ForEach( (x) => Console.WriteLine(x) );
        // intArray.ForEach( (x) => 
        // {
        //     double pow = Math.Pow(x, 2);
        //     Console.WriteLine($"Value = {x}, square = {pow}");
        // });

        Console.WriteLine("Min of intArray: " + intArray.Min());
        Console.WriteLine("Max of intArray: " + intArray.Max());
        Console.WriteLine("Min of doubleArray: " + doubleArray.Min());
        Console.WriteLine("Max of doubleArray: " + doubleArray.Max());
    }
}
    
