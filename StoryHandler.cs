namespace WOZ_TEST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using WOZ_TEST.UI;

    public class StoryHandler
    {
        public Dictionary<int, Area> Areas { get; set; }
        public Scene? CurrentScene { get; set; }
        StoryBuilder StoryBuilder { get; set; }

        public IUIHandler UIHandler { get; set; }

        public StoryHandler(IUIHandler uiHandler)
        {
            UIHandler = uiHandler;
            StoryBuilder = new StoryBuilder();
        }

        public void Start()
        {
            CurrentScene = StoryBuilder.GetEntryScene();
            UIHandler.DrawScene(CurrentScene, this);
        }

        public void ExecuteChoice(string userInput)
        {
            int usrInpInt = Int32.Parse(userInput);

            // Checks if the input corresponds to a scene that the current scene links to.
            Scene foundScene = StoryBuilder.FindScene(usrInpInt);
            if (CurrentScene!.Choices.Exists(x => x.SceneObj == foundScene))
            {
                CurrentScene = foundScene;
                UIHandler.DrawScene(CurrentScene, this);
            } else
            {
                UIHandler.DrawError("I dont know where that is!");
            }

        }

        public void LoadScenes()
        {
            // Insert load from file logic here

            // Dummy Story:



            // Start by building world
            Areas = new Dictionary<int, Area>
            {
                { 1, new Area(1, "Entrance") },
                { 2, new Area(2, "Kitchen") },
                { 3, new Area(3, "Living room") },
                { 4, new Area(4, "Bedroom 1") },
                { 5, new Area(5, "Bedroom 2") },
                { 6, new Area(6, "Bathroom") }
            };

            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur consectetur est rutrum dapibus hendrerit. Cras dictum, urna vitae consequat tempus, ligula odio posuere ex, at tincidunt nunc nulla nec purus. Aliquam at sem consequat, venenatis sem vel, consequat tortor. Cras bibendum massa id urna efficitur volutpat. Integer tempor sem a quam porttitor, non ullamcorper sem dapibus. Etiam lectus metus, aliquam vitae dui ac, posuere maximus metus. In eget sapien ligula. ";

            StoryBuilder.AddScene(1, Areas[1], "The beginning 1", loremIpsum, new List<SceneChoice> { new SceneChoice(2, "Get upset and run to the kitchen"), new SceneChoice(3, "Move slowly backwards into the living room") });
            StoryBuilder.AddScene(2, Areas[2], "The beginning 1.1", loremIpsum, new List<SceneChoice> { new SceneChoice(4, "Say i am tired, and go to your bedroom"), new SceneChoice(5, "Run into your kids bedroom") });
            StoryBuilder.AddScene(3, Areas[3], "The beginning 1.2", loremIpsum, new List<SceneChoice> { new SceneChoice(4, "You deciede to leave and go to your bedroom"), new SceneChoice(6, "Go to the bathroom to clear your mind (and ass tee hee)") });
            StoryBuilder.AddScene(4, Areas[4], "The beginning 2.1", loremIpsum, new List<SceneChoice> { new SceneChoice(1, "Go back to the Entrance")});
            StoryBuilder.AddScene(6, Areas[4], "Mind clearing", loremIpsum, new List<SceneChoice> { new SceneChoice(1, "Go back to the Entrance")});
            StoryBuilder.AddScene(5, Areas[5], "The beginning 2.2", loremIpsum, new List<SceneChoice> { new SceneChoice(1, "Go back to the Entrance") });

            StoryBuilder.LinkScenes();



            //// Build the story
            //Scenes = new Dictionary<int, Scene>
            //{
            //    { 1, new Scene(1, "The beginning 1", Areas[1], new List<int>{2, 3}) },
            //    { 2, new Scene(2, "The beginning 2", Areas[2], new List<int>{4, 5 }) },
            //    { 3, new Scene(3, "The beginning 3", Areas[3], new List<int>{4, 5}) },
            //    { 4, new Scene(4, "The beginning 4", Areas[4], new List<int>{1}) },
            //    { 5, new Scene(5, "The beginning 5", Areas[5], new List<int>{1}) },
            //};

        }

    }
}
