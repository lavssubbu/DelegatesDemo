using Multicastdel;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//create instance for delegate
Multicastdelsamp md = MathOpe.Add;


md += MathOpe.Sub;
md += MathOpe.Prod;
md -= MathOpe.Div;

md.Invoke(100, 25);


//System Delegates
//Func Delegate - 0-16 input parameters and 1 out parameter
//It is always used when you want to return a value

Func<int, int, int, int> fundel = (num1, num2, num3) => num1 + num2 + num3;
Console.WriteLine(fundel(20, 30, 40));

Action<int, int> actiondel = (num1, num2) => Console.WriteLine(num1 + num2);
actiondel(20, 80);

Predicate<int> isEven = (num) => num%2 == 0;
if(isEven(13))
{
    Console.WriteLine("The number is even");
}
else
{
    Console.WriteLine("The number is odd");
}





