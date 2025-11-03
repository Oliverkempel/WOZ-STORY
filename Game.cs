namespace WOZ_TEST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using WOZ_TEST.UI;

    public class Game
    {
        static public StoryHandler StoryHandler { get; set; }

        static public IUIHandler UIHandler { get; set; }

        public static void Main(string[] args)
        {
            UIHandler = new UITerminal();
            StoryHandler = new StoryHandler(UIHandler);

            Console.WriteLine("Welcome to world of zuul test");

            StoryHandler.LoadScenes();

            StoryHandler.Start();

            while(true)
            {
                string? userinput = UIHandler.GetUserInput();
                UIHandler.ClearScreen();
                StoryHandler.ExecuteChoice(userinput);
            }


        }

    }
}
