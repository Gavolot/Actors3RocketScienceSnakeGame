using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source
{
    public class ProcessorInitPosition : Processor {
        public Group<ComponentPosition> groupPositions;
        public override void HandleEcsEvents () {
            foreach (var entity in groupPositions.added) {
                var pos = entity.ComponentPosition();
                pos.initPosition = entity.transform.position;
                pos.initLocalPosition = entity.transform.localPosition;
                pos.prevPosition = entity.transform.position;
            }
        }
    }
}