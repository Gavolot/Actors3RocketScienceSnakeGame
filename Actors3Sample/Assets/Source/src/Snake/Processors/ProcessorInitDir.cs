using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Snake
{
    public class ProcessorInitDir : Processor{
        public Group<ComponentDir> groupDir;

        public override void HandleEcsEvents () {
            foreach(var entity in groupDir.added){
                var d = entity.ComponentDir();
                d.target = entity.transform.position;
                d.dir = Pixeye.Source.Quat_8_Dirs.Right;
            }
        }
    }
}