using System;
using Pixeye.Actors;
using UnityEngine;
using Pixeye.Source;
namespace Pixeye.Snake
{
    [Serializable]
    public class ComponentSnakeCellParent
    {
        public Actor parent = null;
        public Actor child = null;
    }
#region HELPERS
    public static partial class Component
    {
        public const string SnakeCellParent = "Pixeye.Source.ComponentSnakeCellParent";
        internal static ref ComponentSnakeCellParent ComponentSnakeCellParent(in this ent entity) 
                => ref Storage<ComponentSnakeCellParent>.components[entity.id];
    }
    sealed class StorageComponentSnakeCellParent : Storage<ComponentSnakeCellParent>
    {
        public override ComponentSnakeCellParent Create() => new ComponentSnakeCellParent();
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