using Pixeye.Actors;
using Pixeye.Source;
using UnityEngine;
using UnityEngine.Rendering;
namespace Pixeye.Source {
    public class ProcessorDepthSorting : Processor, ITick {
        [GroupBy (Tag.DepthSorting)]
        public Group<ComponentSpriteRenderer> groupSpriteSorting;

        [GroupBy (Tag.DepthSorting)]
        public Group<ComponentSpriteGroup> groupSpriteGroupSorting;

        [GroupBy (Tag.DepthSorting)]
        public Group<ComponentSpriteGroup8thModel> groupModel8thGroupsSorting;

        public override void HandleEcsEvents () {
            foreach (ent entity in groupSpriteSorting.added) {
                var spr = entity.ComponentSpriteRenderer();
                //if(!spr.spriteRenderer)
                    //spr.spriteRenderer = entity.GetMono<SpriteRenderer> ();

                spr.spriteRenderer.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
            }
            foreach (ent entity in groupSpriteGroupSorting.added) {
                var spr = entity.ComponentSpriteGroup();
                if(!spr.spriteGroup)
                    spr.spriteGroup = entity.GetMono<SortingGroup> ();

                spr.spriteGroup.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
            }
        }
        public void Tick (float delta) {
            foreach (var entity in groupSpriteSorting) {
                if (entity.transform.hasChanged) {
                    var spr = entity.ComponentSpriteRenderer ().spriteRenderer;
                    spr.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
                }
            }
            foreach (var entity in groupSpriteGroupSorting) {
                if(entity.transform.hasChanged){
                    var spr = entity.ComponentSpriteGroup().spriteGroup;
                    spr.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
                }
            }
            foreach (var entity in groupModel8thGroupsSorting) {
                if(entity.transform.hasChanged){
                    var up = entity.ComponentSpriteGroup8thModel().sortingGroupUp;
                    var down = entity.ComponentSpriteGroup8thModel().sortingGroupDown;
                    var left = entity.ComponentSpriteGroup8thModel().sortingGroupLeft;
                    var leftUp = entity.ComponentSpriteGroup8thModel().sortingGroupLeftUp;
                    var leftDown = entity.ComponentSpriteGroup8thModel().sortingGroupLeftDown;
                    var right = entity.ComponentSpriteGroup8thModel().sortingGroupRight;
                    var rightUp = entity.ComponentSpriteGroup8thModel().sortingGroupRightUp;
                    var rightDown = entity.ComponentSpriteGroup8thModel().sortingGroupRightDown;
                    up.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
                    down.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
                    left.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
                    leftUp.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
                    leftDown.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
                    right.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
                    rightUp.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
                    rightDown.sortingOrder = (int) (entity.transform.position.y * GameConstants.PrecissionSortingValue);
                }
            }
        }
    }
}