﻿using System;
internal class Program
{
    static void Main()
    {
        IValueProvider<int> intarrayprov = new  ProvValInt();
        IValueProvider<double> doubarrayprov = new  ProvValDoub();
        IValueProvider<bool> boolarrayprov = new  ProvValBool();
        IValueProvider<string> strarrayprov = new  ProvValStr();

        Array<int> intArray1= new Array<int>(intarrayprov);
        Array<double> doubleArray1 = new Array<double>(doubarrayprov);
        Array<bool> boolArray1 = new Array<bool>(boolarrayprov);
        Array<string> stringArray1 = new Array<string>(strarrayprov);

        IPrinter[] printers = new IPrinter[]
        {
            intArray1, doubleArray1, boolArray1, stringArray1, 
        };

        foreach (IPrinter printer in printers)
        {
            Console.WriteLine($"Элементы массива {printer.GetType()}:");
            printer.Print();
        }
    }
}