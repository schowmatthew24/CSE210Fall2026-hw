class Circle
{
    

    static void main()
    {
        
        int x = 10;
        Console.WriteLine("Hello circle!");

        Circle myCircle = new Circle();
        myCircle._radius = 10;

        double area = myCircle.GetArea();

        Console.WriteLine(area);
    }
}
//abstraction - correct set of attributes and methods
//select public emthods, all else should be private - encapsulation
//constructor is called when an object is created
// _radius : double
//if you know there is not a case of a used default constructor, don't use it
//getdiameter / get area - don't need an equation, you can get it
