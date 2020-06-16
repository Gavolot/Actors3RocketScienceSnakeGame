using System;
using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source
{
    [Serializable]
    public class ComponentSprite8thModel
    {
        public Sprite Up;
        public Sprite Down;
        public Sprite Left;
        public Sprite Right;
        public Sprite RightDown;
        public Sprite LeftDown;
        public Sprite LeftUp;
        public Sprite RightUp;
    }
#region HELPERS
    public static partial class Component
    {
        public const string Sprite8thModel = "Pixeye.Source.ComponentSprite8thModel";
        internal static ref ComponentSprite8thModel ComponentSprite8thModel(in this ent entity) 
                => ref Storage<ComponentSprite8thModel>.components[entity.id];
    }
    sealed class StorageComponentSprite8thModel : Storage<ComponentSprite8thModel>
    {
        public override ComponentSprite8thModel Create() => new ComponentSprite8thModel();
        public override void Dispose(indexes disposed)
        {
            foreach (var id in disposed)
            {
                ref var component = ref components[id];
            }
        }
    }
#endregion
}