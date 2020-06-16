using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source
{
    public class ProcessorEndFrame : Processor, ITickLate {
        public Group<ComponentPosition> groupPositions;
        public Group<ComponentFrames> groupFrames;
        public void TickLate (float delta) {
            foreach (var entity in groupPositions) {
                var pos = entity.ComponentPosition();
                pos.endFramePosition = entity.transform.position;
            }
            foreach(var entity in groupFrames){
                var frm = entity.ComponentFrames();
                frm.frames++;
                if(frm.frames == int.MaxValue-1){
                    frm.frames = 0;
                }
            }
            //Input.ResetInputAxes();
        }
    }
}