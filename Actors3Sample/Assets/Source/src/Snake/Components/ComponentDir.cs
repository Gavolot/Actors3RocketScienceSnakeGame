using System;
using Pixeye.Actors;
using Pixeye.Source;
using UnityEngine;
namespace Pixeye.Snake
{
    [Serializable]
    public class ComponentDir
    {
        public Quaternion dir = Quat_8_Dirs.Right;
        public Vector2 target = Vector2.zero;
    }
#region HELPERS
    public static partial class Component
    {
        public const string Dir = "Pixeye.Source.ComponentDir";
        internal static ref ComponentDir ComponentDir(in this ent entity) 
                => ref Storage<ComponentDir>.components[entity.id];
    }
    sealed class StorageComponentDir : Storage<ComponentDir>
    {
        public override ComponentDir Create() => new ComponentDir();
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