namespace WOZ_TEST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StoryBuilder
    {
        public Dictionary<int, Scene> _scenes = new Dictionary<int, Scene>();

        public Scene AddScene(int id, Area area, string name, string dialougeText, List<SceneChoice> choices)
        {
            // Perhaps add auto incrementing ID's here?
            Scene tmp = new Scene(id, name, dialougeText, area, choices);
            _scenes[id] = tmp;
            return tmp;
        }

        // method is nessosary, as we cannot link scenes to scnens that are not yet instanciated
        public void LinkScenes()
        {
            // Loops over all scenes
            foreach(Scene scene in _scenes.Values)
            {
                // Loops over all scene choices, and links them to the instance of the scene object in question, basen on the scene id specified
                foreach(SceneChoice choice in scene.Choices)
                {
                    if (_scenes.TryGetValue(choice.SceneId, out Scene OutScene)) {
                        choice.SceneObj = OutScene;
                    }
                }
            }
        }

        public Scene GetEntryScene()
        {
            // ID 1 will always be the entry scene!
            return _scenes[1];
        }

        public Scene FindScene(int id)
        {
            return _scenes[id];
        }

        public Scene FindScene(Scene scene)
        {
            return _scenes.FirstOrDefault(x => x.Value == scene).Value;
        }
    }
}
