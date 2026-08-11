using System;

class Question4
{
    private int a = 10;
    protected int b = 20;
    internal int c = 30;
    public int d = 40;

    public void Show()
    {

        Console.WriteLine("Private: " + a);
        Console.WriteLine("Protected: " + b);
        Console.WriteLine("Internal: " + c);
        Console.WriteLine("Public: " + d);
    }

    static void Main(string[] args)
    {
        Question4 obj = new Question4();
        obj.Show();
    }
}