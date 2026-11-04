class BaseActivity
{
    puclic BaseActivity()
    {
        //todo fill in
    }
    public void RunCountdownMessage(string RunCountdownMessage, int seconds)
    {
        Console.CursorVisible = false;
        Console.Clear();
        for(int i=seconds; i> 1; i--)
        {
            Console.Clear();
            Console.Write($"{message} - {i}");
            Thread.Sleep(1000);
            
        }
        Console.CursorVisible = true;
    }
    public void DisplaySpinnerMessage(string message, int seconds)
    {
        Console.Write($"{message} ");
        for (int i=0; i<seconds; i++)
        {
            
            Console.Write("+");
            Thread.Sleep(200);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(200);
            Console.Write("\b");
        }
        Console.CursorVisible = true;
    }
}