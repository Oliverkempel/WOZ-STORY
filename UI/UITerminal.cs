namespace WOZ_TEST.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UITerminal : IUIHandler
    {
        public UITerminal()
        {
        }

        public void DrawScene(Scene scene, StoryHandler storyHandler)
        {
            Console.WriteLine($"Scene: [{scene.Name}] You are in Area: [{scene.Area.Name}]");
            Console.WriteLine();
            Console.WriteLine("===================================================================================");
            Console.WriteLine(scene.DialougeText);
            Console.WriteLine("===================================================================================");

            Console.WriteLine("Current options:");
            foreach (SceneChoice sceneChoice in scene.Choices)
            {
                Console.WriteLine($"- {sceneChoice.Description} [{sceneChoice.SceneId}]");
            }
        }

        public string GetUserInput(string queryText = "> ")
        {
            Console.Write(queryText);
            string? userinputtxt = Console.ReadLine();

            // Return empty string if user input is null
            return userinputtxt != null ? userinputtxt : "";
        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void DrawError(string errorText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {errorText}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
