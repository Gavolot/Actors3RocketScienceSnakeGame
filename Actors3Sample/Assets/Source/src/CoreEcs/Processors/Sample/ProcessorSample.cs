using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source {
    public class ProcessorSample : Processor, ITick {
        private int I = 0;
        public override void HandleEcsEvents () { }

        public void Tick (float delta) {
            I++;
            if (I % 60 == 0) {
                Debug.Log ("Second");
            }
        }
    }
}