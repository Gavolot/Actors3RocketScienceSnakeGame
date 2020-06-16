using System;
using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source
{
    [Serializable]
    public class ComponentStats
    {
        public int score = 0;
        public int level = 0;
    }
#region HELPERS
    public static partial class Component
    {
        public const string Stats = "Pixeye.Source.ComponentStats";
        internal static ref ComponentStats ComponentStats(in this ent entity) 
                => ref Storage<ComponentStats>.components[entity.id];
    }
    sealed class StorageComponentStats : Storage<ComponentStats>
    {
        public override ComponentStats Create() => new ComponentStats();
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