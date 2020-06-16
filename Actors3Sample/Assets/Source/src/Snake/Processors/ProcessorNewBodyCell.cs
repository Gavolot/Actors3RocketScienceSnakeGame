using Pixeye.Actors;
using Pixeye.Source;
using UnityEngine;
namespace Pixeye.Snake {
    public class ProcessorNewBodyCell : Processor, ITick {
        [GroupBy (Tag.NewBodyCell)]
        public Group<ComponentPosition> groupSnake;

        public Group<ComponentSnakeCellParent, ComponentPosition> cells;
        public override void HandleEcsEvents () {

        }
        public void Tick (float delta) {
            foreach (var entity in groupSnake) {
                entity.Remove (Tag.NewBodyCell);
                if (cells.length > 0) {
                    foreach (var cell in cells) {
                        var pos = cell.ComponentPosition ();
                        var p = cell.ComponentSnakeCellParent ();
                        if (p.child == null) {
                            var act = Layer.Actor.Create ("Prefabs/Snake/SnakeCell", pos.prevPosition);
                            var eAct = act.entity;
                            var pNew = eAct.ComponentSnakeCellParent ();
                            pNew.parent = cell.GetMono<Actor> ();
                            pNew.child = null;
                            p.child = act;
                            break;
                        }
                    }
                } else {
                    // TO DO (maybe hahahahah no TO DO AHAHAHHAHAHA)
                }
            }
        }
    }
}