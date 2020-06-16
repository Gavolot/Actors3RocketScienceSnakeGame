using Pixeye.Actors;
using Pixeye.Source;
using UnityEngine;
using gmc = Pixeye.Snake.GameConstants;
namespace Pixeye.Snake {
    public class ProcessorTickMoveToDir : Processor<SignalDeadSnake>, ITickLate {
        [ExcludeBy (Tag.CantMove, Tag.SnakeDead)]
        Group<ComponentPosition, ComponentTickMover, ComponentDir> groupTickMover;
        [ExcludeBy (Tag.SnakeDead)]
        public Group<ComponentSnakeCellParent, ComponentPosition> groupSnakeCells;

        public override void ReceiveEcs (ref SignalDeadSnake signal, ref bool stopSignal) {
            foreach (var entity in groupSnakeCells) {
                entity.Set (Tag.SnakeDead);
            }
            stopSignal = true;
        }
        public override void HandleEcsEvents () { }

        private Vector2 NewDirTarget (ent me, ComponentDir d, float vOffset, float hOffset) {
            Vector2 vect = me.transform.position;
            if (d.dir.EqualZ (Quat_8_Dirs.Up)) {
                vect.y += vOffset;
            } else
            if (d.dir.EqualZ (Quat_8_Dirs.Right)) {
                vect.x += hOffset;
            } else
            if (d.dir.EqualZ (Quat_8_Dirs.Left)) {
                vect.x -= hOffset;
            } else
            if (d.dir.EqualZ (Quat_8_Dirs.Down)) {
                vect.y -= vOffset;
            }
            return vect;
        }
        public void TickLate (float delta) {
            foreach (var entity in groupTickMover) {
                var pos = entity.ComponentPosition ();
                var tm = entity.ComponentTickMover ();
                var d = entity.ComponentDir ();
                pos.prevPosition = entity.transform.position;
                if ((tm.tickTime -= delta) <= 0) {
                    tm.tickTime = tm.tickTimeMax;
                    entity.transform.position = d.target;
                    d.target = NewDirTarget (entity, d, tm.tickSpeedVertical, tm.tickSpeedHorizontal);
                }

                #region checkCameraBoundsForRepos
                if (entity.transform.position.x < gmc.X_Camera_Bounds_For_Cell_Left) {
                    var newVect = entity.transform.position;
                    newVect.x = gmc.X_Camera_Bounds_For_Cell_Right;
                    entity.transform.position = newVect;
                    d.target = NewDirTarget (entity, d, tm.tickSpeedVertical, tm.tickSpeedHorizontal);
                } else
                if (entity.transform.position.x > gmc.X_Camera_Bounds_For_Cell_Right) {
                    var newVect = entity.transform.position;
                    newVect.x = gmc.X_Camera_Bounds_For_Cell_Left;
                    entity.transform.position = newVect;
                    d.target = NewDirTarget (entity, d, tm.tickSpeedVertical, tm.tickSpeedHorizontal);
                } else
                if (entity.transform.position.y < gmc.Y_Camera_Bounds_For_Cell_Down) {
                    var newVect = entity.transform.position;
                    newVect.y = gmc.Y_Camera_Bounds_For_Cell_Up;
                    entity.transform.position = newVect;
                    d.target = NewDirTarget (entity, d, tm.tickSpeedVertical, tm.tickSpeedHorizontal);
                } else
                if (entity.transform.position.y > gmc.Y_Camera_Bounds_For_Cell_Up) {
                    var newVect = entity.transform.position;
                    newVect.y = gmc.Y_Camera_Bounds_For_Cell_Down;
                    entity.transform.position = newVect;
                    d.target = NewDirTarget (entity, d, tm.tickSpeedVertical, tm.tickSpeedHorizontal);
                }
                #endregion
            }
            //move to parent prevPosition
            foreach (var entity in groupSnakeCells) {
                var p = entity.ComponentSnakeCellParent ();
                var pos = entity.ComponentPosition ();
                var pPos = p.parent.entity.ComponentPosition ();
                var pEntity = p.parent.entity;
                pos.prevPosition = entity.transform.position;
                if (!pPos.prevPosition.EqualXY (pEntity.transform.position)) {
                    entity.transform.position = pPos.prevPosition;
                }
            }
        }
    }
}