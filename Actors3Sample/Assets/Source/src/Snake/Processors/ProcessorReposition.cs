using Pixeye.Actors;
using UnityEngine;
using UnityEditor;

using gmc = Pixeye.Snake.GameConstants;
namespace Pixeye.Source
{
    public class ProcessorReposition : Processor, ITick {
        [GroupBy(Tag.Reposition)]
        public Group<ComponentPosition> groupPos;

        public override void HandleEcsEvents () {
            
        }
        public void Tick (float delta) {
            foreach(var entity in groupPos){
                var pos = entity.ComponentPosition();
                pos.prevPosition = entity.transform.position;
                var vect = new Vector2();
                vect.x = Pixeye.Actors.Random.Range(gmc.X_Camera_Bounds_For_Cell_Left, gmc.X_Camera_Bounds_For_Cell_Right);
                vect.y = Pixeye.Actors.Random.Range(gmc.Y_Camera_Bounds_For_Cell_Down, gmc.Y_Camera_Bounds_For_Cell_Up);
                vect.x = Handles.SnapValue(vect.x, gmc.Horizontal_Cell_Size_Step);
                vect.y = Handles.SnapValue(vect.y, gmc.Vertical_Cell_Size_Step);
                entity.transform.position = vect;
                entity.RemoveAll(Tag.Reposition);
            }
        }
    }
}