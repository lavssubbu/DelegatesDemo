internal class Program
{
    //1. Signature of the delegate should match with the signature of target method
    public delegate void delsamp(string nm);//delegate declaration
    private static void Main(string[] args)
    {
        //2.create instance for the delegate - set the target method
        delsamp del = new delsamp(Display);
        //3.Invoke the delegate
        del("Delegates");//call display method
    }

    static void Display(string name)
    {

      Console.WriteLine($"Welcome to {name}");
    }
}