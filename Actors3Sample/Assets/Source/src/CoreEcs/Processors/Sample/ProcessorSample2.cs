using Pixeye.Actors;
using Pixeye.Source;
using UnityEngine;
namespace Pixeye.Source
{
    public class ProcessorSample2 : Processor, ITick {
        private int I = 0;
        public override void HandleEcsEvents () {
        }
        public void Tick (float delta) {
            I++;
            if (I % 240 == 0) {
                Debug.Log ("4xSecond");
            }
        }
    }
}