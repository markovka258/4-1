﻿using System;
internal class Program
{
    static void Main()
    {
        Array<int> intArray = new Array<int>(10);
        Array<string> stringArray = new Array<string>();

        intArray.Add(4);
        intArray.Add(14);
        intArray.Add(111);
        intArray.Add(-80);

        stringArray.Add("hello");
        stringArray.Add("world");

        intArray.Sort();
        stringArray.Sort();

        // intArray.ForEach( (x) => Console.WriteLine(x) );
        // intArray.ForEach( (x) => 
        // {
        //     double pow = Math.Pow(x, 2);
        //     Console.WriteLine($"Value = {x}, square = {pow}");
        // });


        Console.WriteLine("Min of intArray: " + intArray.Min());
        Console.WriteLine("Max of intArray: " + intArray.Max());
        Console.WriteLine("Min of stringArray: " + stringArray.Min());
        Console.WriteLine("Max of stringArray: " + stringArray.Max());
    }
}
    
