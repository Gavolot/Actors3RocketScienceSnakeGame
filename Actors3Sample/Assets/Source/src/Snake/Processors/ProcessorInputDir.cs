using Pixeye.Actors;
using Pixeye.Snake;
using Pixeye.Source;
using UnityEngine;
namespace Pixeye.Snake {
    public class ProcessorInputDir : Processor, ITick {
        //[ExcludeBy(Tag.CantMove)]
        [GroupBy (Tag.InputKeyboardAxes)]
        public Group<ComponentDir, ComponentTickMover, ComponentChild> groupSnakeMoving;
        public override void HandleEcsEvents () { }
        public void Tick (float delta) {
            foreach (var entity in groupSnakeMoving) {
                var d = entity.ComponentDir ();
                var tm = entity.ComponentTickMover ();
                var child = entity.ComponentChild ();

                float hor = Input.GetAxis ("Horizontal");
                float vert = Input.GetAxis ("Vertical");
                if (Input.GetButtonDown ("Horizontal")) {
                    if (hor > 0) {
                        var vect = entity.transform.position;
                        vect.x += tm.tickSpeedHorizontal;
                        if (!vect.EqualXYZ (child.child.entity.transform.position)) {
                            d.dir = Quat_8_Dirs.Right;
                            d.target = vect;
                        }
                    } else
                    if (hor < 0) {
                        var vect = entity.transform.position;
                        vect.x -= tm.tickSpeedHorizontal;
                        if (!vect.EqualXYZ (child.child.entity.transform.position)) {
                            d.dir = Quat_8_Dirs.Left;
                            d.target = vect;
                        }
                    }
                }
                if (Input.GetButtonDown ("Vertical")) {
                    if (vert > 0) {
                        var vect = entity.transform.position;
                        vect.y += tm.tickSpeedVertical;
                        if (!vect.EqualXYZ (child.child.entity.transform.position)) {
                            d.dir = Quat_8_Dirs.Up;
                            d.target = vect;
                        }
                    } else
                    if (vert < 0) {
                        var vect = entity.transform.position;
                        vect.y -= tm.tickSpeedVertical;
                        if (!vect.EqualXYZ (child.child.entity.transform.position)) {
                            d.dir = Quat_8_Dirs.Down;
                            d.target = vect;
                        }
                    }
                }
            }
        }
    }
}