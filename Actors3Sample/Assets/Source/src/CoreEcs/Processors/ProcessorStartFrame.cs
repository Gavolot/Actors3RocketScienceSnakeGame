using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source
{
    public class ProcessorStartFrame : Processor, ITick {
        public Group<ComponentPosition> groupPositions;
        public void Tick (float delta) {
            foreach (var entity in groupPositions) {
                var pos = entity.ComponentPosition();
                pos.startFramePosition = entity.transform.position;
            }
        }
    }
}