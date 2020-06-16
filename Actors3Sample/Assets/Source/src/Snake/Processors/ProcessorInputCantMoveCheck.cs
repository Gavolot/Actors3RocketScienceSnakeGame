using Pixeye.Actors;
using Pixeye.Source;
using UnityEngine;
namespace Pixeye.Snake {
    public class ProcessorInputCantMoveCheck : Processor, ITick {
        [GroupBy (Tag.CantMove, Tag.InputKeyboardAxes)]
        public Group<ComponentDir> groupSnakeCantMoving;

        public override void HandleEcsEvents () {

        }
        public void Tick (float delta) {
            foreach (var entity in groupSnakeCantMoving) {
                //Debug.Log ("Tick");
                if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
                    entity.RemoveAll (Tag.CantMove);
                    //Debug.Log ("Remove");
                }
            }
        }
    }
}