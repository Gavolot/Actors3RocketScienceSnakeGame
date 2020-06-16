using Pixeye.Actors;
using Pixeye.Source;
using UnityEngine;
namespace Pixeye.Snake {
    public class ActorSnakeHead : Actor {
        [FoldoutGroup ("Init")]
        public ComponentSpriteRenderer componentSpriteRenderer;
        [FoldoutGroup ("Init")]
        public ComponentChild componentChild;
        [FoldoutGroup ("Init")]
        public ComponentTickMover componentTickMover;
        [FoldoutGroup ("Setup")]
        public ComponentBoxCollider componentBoxCollider;
        [FoldoutGroup ("Runtime")]
        public ComponentDir componentDir;
        [FoldoutGroup ("Runtime")]
        public ComponentStats componentStats;
        [FoldoutGroup ("Scope")]
        public ComponentPosition componentPosition;

        [Header ("AnyTags")]
        [TagFilter (typeof (Tag))] public int[] tags;

        protected override void Setup () {
            this.entity.Set (componentSpriteRenderer);
            this.entity.Set (componentChild);
            this.entity.Set (componentDir);
            this.entity.Set (componentStats);
            this.entity.Set (componentTickMover);
            //this.entity.Set(componentMoving);
            this.entity.Set (componentBoxCollider);
            this.entity.Set (componentPosition);
            this.entity.Set (tags);
        }
        private void OnCollisionEnter2D (Collision2D other) {

            var other_actor = other.gameObject.GetComponent<Actor> ();

            if (other.gameObject.activeSelf) {
                if (other_actor) {
                    var e = other_actor.entity;

                    if (e.Has (Tag.Apple)) {
                        Debug.Log (other.gameObject.name);
                        this.entity.Set (Tag.NewBodyCell);
                        if (!e.Has (Tag.Reposition)) {
                            e.Set (Tag.Reposition);
                        }

                        this.entity.ComponentStats ().score++;
                        //other_actor.gameObject.SetActive (false);
                    } else
                    if (e.Has<ComponentSnakeCellParent> ()) {
                        this.entity.Set (Tag.SnakeDead);
                        SignalDeadSnake s;
                        this.Layer.Send (s);
                    }
                }
            }
        }
    }

}