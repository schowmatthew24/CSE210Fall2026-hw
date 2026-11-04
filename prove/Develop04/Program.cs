using System;
using System.ComponentModel.Design;
class Program
{
    static void Main(string[] args)
    {
        BaseActivity activity = new BaseActivity();
        activity.RunCountdownMessage("Get ready" 5);
        activity.DisplaySpinnerMessage("Well done", 20");
    }

}

