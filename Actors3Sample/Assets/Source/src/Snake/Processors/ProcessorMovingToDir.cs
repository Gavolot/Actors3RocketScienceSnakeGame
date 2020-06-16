using Pixeye.Actors;
using UnityEngine;
using Pixeye.Source;
namespace Pixeye.Snake
{
    public class ProcessorMovingToDir : Processor, ITickLate {
        [ExcludeBy(Tag.CantMove)]
        public Group<ComponentDir, ComponentMoving> groupMoving;
        public override void HandleEcsEvents () {
            
        }
        public void TickLate (float delta) {
            foreach(var entity in groupMoving){
                var mov = entity.ComponentMoving();
                var d = entity.ComponentDir();
                
                mov.target = GM_Math.DegreeToVector2(d.dir.eulerAngles.z);
                entity.transform.position = Vector2.MoveTowards(entity.transform.position, mov.target, delta * mov.speed);
            }
        }
    }
}