using System;
using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source
{
    [Serializable]
    public class ComponentPosition
    {
        public Vector2 initPosition = Vector2.zero;
        public Vector2 initLocalPosition = Vector2.zero;
        public Vector2 endFramePosition = Vector2.zero;
        public Vector2 startFramePosition = Vector2.zero;

        public Vector2 targetPosition = Vector2.zero;

        public Vector2 prevPosition = Vector2.zero;
    }
#region HELPERS
    public static partial class Component
    {
        public const string Position = "Pixeye.Source.ComponentPosition";
        internal static ref ComponentPosition ComponentPosition(in this ent entity) 
                => ref Storage<ComponentPosition>.components[entity.id];
    }
    sealed class StorageComponentPosition : Storage<ComponentPosition>
    {
        public override ComponentPosition Create() => new ComponentPosition();
        public override void Dispose(indexes disposed)
        {
            foreach (var id in disposed)
            {
                ref var component = ref components[id];
                component.initPosition = Vector3.zero;
            }
        }
    }
#endregion
}