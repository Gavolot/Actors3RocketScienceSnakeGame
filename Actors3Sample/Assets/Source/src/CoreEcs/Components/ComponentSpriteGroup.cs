using System;
using Pixeye.Actors;
using UnityEngine;
using UnityEngine.Rendering;
namespace Pixeye.Source
{
    [Serializable]
    public class ComponentSpriteGroup
    {
        public SortingGroup spriteGroup;
        //public bool visible = true; TO DO
    }
#region HELPERS
    public static partial class Component
    {
        public const string SpriteGroup = "Pixeye.Source.ComponentSpriteGroup";
        internal static ref ComponentSpriteGroup ComponentSpriteGroup(in this ent entity) 
                => ref Storage<ComponentSpriteGroup>.components[entity.id];
    }
    sealed class StorageComponentSpriteGroup : Storage<ComponentSpriteGroup>
    {
        public override ComponentSpriteGroup Create() => new ComponentSpriteGroup();
        public override void Dispose(indexes disposed)
        {
            foreach (var id in disposed)
            {
                ref var component = ref components[id];
                //component.visible = true;
                component.spriteGroup = null;
            }
        }
    }
#endregion
}