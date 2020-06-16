using System;
using Pixeye.Actors;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
namespace Pixeye.Snake {
    [Serializable]
    public class ComponentChild {
        public Actor child = null;
    }
    #region HELPERS
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption (Option.DivideByZeroChecks, false)]
    public static partial class Component {
        public const string Child = "Pixeye.Source.ComponentChild";
        internal static ref ComponentChild ComponentChild (in this ent entity) => ref Storage<ComponentChild>.components[entity.id];
    }

    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption (Option.DivideByZeroChecks, false)]
    sealed class StorageComponentChild : Storage<ComponentChild> {
        public override ComponentChild Create () => new ComponentChild ();
        public override void Dispose (indexes disposed) {
            foreach (var id in disposed) {
                ref var component = ref components[id];
                component.child = null;
            }
        }
    }
    #endregion
}