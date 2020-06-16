using System;
using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Snake
{
    [Serializable]
    public class ComponentMoving
    {
        public float speed = 0f;
        public Vector2 target = Vector2.zero;
    }
#region HELPERS
    public static partial class Component
    {
        public const string Moving = "Pixeye.Source.ComponentMoving";
        internal static ref ComponentMoving ComponentMoving(in this ent entity) 
                => ref Storage<ComponentMoving>.components[entity.id];
    }
    sealed class StorageComponentMoving : Storage<ComponentMoving>
    {
        public override ComponentMoving Create() => new ComponentMoving();
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