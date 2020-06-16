using Pixeye.Actors;
using UnityEngine;
using Pixeye.Source;
namespace Pixeye.Snake
{
    public class ProcessorMoving : Processor, ITick {

        public Group<ComponentDir> groupMoving;
        public override void HandleEcsEvents () {
            
        }
        public void Tick (float delta) {
            foreach (var entity in groupMoving) {
                
            }
        }
    }
}