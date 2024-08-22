// See https://aka.ms/new-console-template for more information
using EventConcept;

Console.WriteLine("Hello, World!");


Publisher pubs = new Publisher();
pubs.SampEvent += LogSubscriber.LogEventHandler;
pubs.SampEvent += EmailSubscriber.EmailEventHandler;

pubs.Initiate();

Child ch = new Child();
try
{
    int[] numbers = { 1, 2, 3 };
    int index = 5;
    int value = numbers[index];
    Console.WriteLine("Value at index " + index + ": " + value);
}
catch (DivideByZeroException e)
{
    Console.WriteLine("DivideByZeroException caught: " + e.Message);
}
catch (NullReferenceException e)
{
    Console.WriteLine("NullReferenceException caught: " + e.Message);
}
catch (IndexOutOfRangeException e)
{
    Console.WriteLine("IndexOutOfRangeException caught: " + e.Message);
}
finally
{
    Console.WriteLine("Inside finally block");
}
int i = 30;
int j = 5 % 5;
Console.WriteLine(int.Parse(Convert.ToString(i != j)) != 0);
if (int.Parse(Convert.ToString(i != j)) != 0)
{
    Console.WriteLine("if clause executed");
}
else
{
    Console.WriteLine("else clause executed");
}
Console.WriteLine("Entered Main Function");

class Parent
{
    public Parent()
    {
        Console.WriteLine("Parent constructor");
    }
}

class Child : Parent
{
    public Child()
    {
        Console.WriteLine("Child constructor");
    }
}




