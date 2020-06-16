using System;
using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source
{
    [Serializable]
    public class ComponentSpriteRenderer
    {
        public SpriteRenderer spriteRenderer;
        //public bool visible = true; TO DO
    }
#region HELPERS
    public static partial class Component
    {
        public const string SpriteRenderer = "Pixeye.Source.ComponentSpriteRenderer";
        internal static ref ComponentSpriteRenderer ComponentSpriteRenderer(in this ent entity) 
                => ref Storage<ComponentSpriteRenderer>.components[entity.id];
    }
    sealed class StorageComponentSprite : Storage<ComponentSpriteRenderer>
    {
        public override ComponentSpriteRenderer Create() => new ComponentSpriteRenderer();
        public override void Dispose(indexes disposed)
        {
            foreach (var id in disposed)
            {
                ref var component = ref components[id];
                //component.visible = true;
                component.spriteRenderer = null;
            }
        }
    }
#endregion
}