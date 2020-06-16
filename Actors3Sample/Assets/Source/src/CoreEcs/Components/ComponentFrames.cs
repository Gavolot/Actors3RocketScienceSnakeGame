using System;
using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source
{
    [Serializable]
    public class ComponentFrames
    {
        public int frames = 0;
    }
#region HELPERS
    public static partial class Component
    {
        public const string Frames = "Pixeye.Source.ComponentFrames";
        internal static ref ComponentFrames ComponentFrames(in this ent entity) 
                => ref Storage<ComponentFrames>.components[entity.id];
    }
    sealed class StorageComponentFrames : Storage<ComponentFrames>
    {
        public override ComponentFrames Create() => new ComponentFrames();
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