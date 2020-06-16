using Pixeye.Actors;
using UnityEngine;
using UnityEngine.Rendering;
namespace Pixeye.Source {
    public class ProcessorInitGroup8thModel : Processor {

        public Group<ComponentSpriteGroup8thModel> groupModel;
        public override void HandleEcsEvents () {
            foreach (var entity in groupModel.added) {
                var groupModel = entity.ComponentSpriteGroup8thModel ();
                groupModel._gmObjectsArray = new GameObject[] {
                    groupModel.Up, groupModel.Down, groupModel.Left, groupModel.Right,
                    groupModel.RightDown, groupModel.LeftDown, groupModel.RightUp, groupModel.LeftUp
                };
                groupModel._sortingGroupsArray = new SortingGroup[] {
                    groupModel.sortingGroupUp, groupModel.sortingGroupDown, groupModel.sortingGroupLeft, groupModel.sortingGroupRight,
                    groupModel.sortingGroupRightDown, groupModel.sortingGroupRightUp, groupModel.sortingGroupLeftDown, groupModel.sortingGroupLeftUp
                };

                for (int i = 0; i < groupModel._gmObjectsArray.Length; i++) {
                    foreach (Transform child in groupModel._gmObjectsArray[i].transform) {
                        var actor = child.gameObject.GetComponent<Actor>();
                        if (actor) {
                            actor.Bootstrap(Layer);
                        }
                    }
                }
            }

        }
    }
}