using System;
using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Snake
{
    [Serializable]
    public class ComponentTickMover
    {
        public float tickSpeedHorizontal = 0.05f;
        public float tickSpeedVertical = 0.03f;
        public float tickTimeMax = 0.01f;
        [HideInInspector]
        public float tickTime = 0.01f;
    }
#region HELPERS
    public static partial class Component
    {
        public const string TickMover = "Pixeye.Source.ComponentTickMover";
        internal static ref ComponentTickMover ComponentTickMover(in this ent entity) 
                => ref Storage<ComponentTickMover>.components[entity.id];
    }
    sealed class StorageComponentTickMover : Storage<ComponentTickMover>
    {
        public override ComponentTickMover Create() => new ComponentTickMover();
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