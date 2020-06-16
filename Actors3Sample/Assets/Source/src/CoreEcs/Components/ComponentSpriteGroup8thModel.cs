using System;
using Pixeye.Actors;
using UnityEngine;
using UnityEngine.Rendering;
namespace Pixeye.Source
{
    [Serializable]
    public class ComponentSpriteGroup8thModel
    {
        public GameObject Up;
        public GameObject Down;
        public GameObject Left;
        public GameObject Right;
        public GameObject RightDown;
        public GameObject LeftDown;
        public GameObject LeftUp;
        public GameObject RightUp;
        public SortingGroup sortingGroupUp;
        public SortingGroup sortingGroupDown;
        public SortingGroup sortingGroupLeft;
        public SortingGroup sortingGroupRight;
        public SortingGroup sortingGroupRightDown;
        public SortingGroup sortingGroupLeftDown;
        public SortingGroup sortingGroupLeftUp;
        public SortingGroup sortingGroupRightUp;

        [Header ("OnlyRuntime")]
        public Direction8th directionTarget = Direction8th.Right;
        public GameObject[] _gmObjectsArray;
        public SortingGroup[] _sortingGroupsArray;
        

        //public GameObject RuntimeLeftHand; TO DO
        //public GameObject RuntimeRightHand; TO DO
    }
#region HELPERS
    public static partial class Component
    {
        public const string SpriteGroup8thModel = "Pixeye.Source.ComponentSpriteGroup8thModel";
        internal static ref ComponentSpriteGroup8thModel ComponentSpriteGroup8thModel(in this ent entity) 
                => ref Storage<ComponentSpriteGroup8thModel>.components[entity.id];
    }
    sealed class StorageComponentSpriteGroup8thModel : Storage<ComponentSpriteGroup8thModel>
    {
        public override ComponentSpriteGroup8thModel Create() => new ComponentSpriteGroup8thModel();
        public override void Dispose(indexes disposed)
        {
            foreach (var id in disposed)
            {
                ref var component = ref components[id];
                for(int i = 0; i<component._gmObjectsArray.Length; i++){
                    component._gmObjectsArray[i] = null;
                }
                for(int i = 0; i<component._sortingGroupsArray.Length; i++){
                    component._sortingGroupsArray[i] = null;
                }
                component.Up = null;
                component.Down = null;
                component.Right = null;
                component.Left = null;
                component.LeftDown = null;
                component.RightDown = null;
                component.RightUp = null;
                component.LeftUp = null;
                component.sortingGroupDown = null;
                component.sortingGroupUp = null;
                component.sortingGroupRight = null;
                component.sortingGroupLeft = null;
                component.sortingGroupLeftDown = null;
                component.sortingGroupLeftUp = null;
                component.sortingGroupRightDown = null;
                component.sortingGroupRightUp = null;
                component.directionTarget = Direction8th.Right;
            }
        }
    }
#endregion
}