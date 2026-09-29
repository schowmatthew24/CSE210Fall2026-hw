class Program
{
    

    static void main()
    {
        Console.WriteLine("Hello circle!");

        Circle myCircle = new Circle();
        myCircle._radius = 10;

        double area = myCircle.GetArea();

        Console.WriteLine(area);
    }
}