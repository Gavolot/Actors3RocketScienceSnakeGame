using Pixeye.Actors;
using Pixeye.Source;
using UnityEngine;
namespace Pixeye.Snake {
    public class ActorSnakeCell : Actor {
        [FoldoutGroup ("Init")]
        public ComponentSpriteRenderer componentSpriteRenderer;
        [FoldoutGroup ("Setup")]
        public ComponentBoxCollider componentBoxCollider;
        [FoldoutGroup ("Setup")]
        public ComponentSnakeCellParent componentSnakeCellParent;
        [FoldoutGroup ("Scope")]
        public ComponentPosition componentPosition;
        [Header ("AnyTags")]
        [TagFilter (typeof (Tag))] public int[] tags;
        protected override void Setup () {
            this.entity.Set (componentSpriteRenderer);
            this.entity.Set (componentBoxCollider);
            this.entity.Set (componentSnakeCellParent);
            this.entity.Set (componentPosition);
            this.entity.Set (tags);
        }
    }
}