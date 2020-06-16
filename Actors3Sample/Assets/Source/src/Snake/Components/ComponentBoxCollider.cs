using System;
using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Snake
{
    [Serializable]
    public class ComponentBoxCollider
    {
        public BoxCollider2D collider;
    }
#region HELPERS
    public static partial class Component
    {
        public const string BoxCollider = "Pixeye.Source.ComponentBoxCollider";
        internal static ref ComponentBoxCollider ComponentBoxCollider(in this ent entity) 
                => ref Storage<ComponentBoxCollider>.components[entity.id];
    }
    sealed class StorageComponentBoxCollider : Storage<ComponentBoxCollider>
    {
        public override ComponentBoxCollider Create() => new ComponentBoxCollider();
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