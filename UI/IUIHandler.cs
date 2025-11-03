namespace WOZ_TEST.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUIHandler
    {

        public void DrawScene(Scene scene, StoryHandler storyHandler);
        
        public string GetUserInput(string queryText = "> ");

        public void ClearScreen();

        public void DrawError(string errorText);

    }
}
