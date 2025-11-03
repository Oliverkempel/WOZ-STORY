namespace WOZ_TEST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Scene
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Area Area { get; set; }

        public string DialougeText { get; set; }
        public List<SceneChoice> Choices { get; set; }    

        public Scene(int id, string name, string dialougeText, Area area, List<SceneChoice> choices) 
        {
            ID = id;
            Name = name;
            DialougeText = dialougeText;
            Area = area;
            Choices = choices;
        }

        public override bool Equals(Object? obj)
        {
            if(obj is Scene)
            {
                Scene scene = (Scene)obj;

                if(scene.ID == this.ID)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
