using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source
{
    public class ActorSprite : Actor {
        [FoldoutGroup ("Setup")]
        public ComponentSpriteRenderer componentSpriteRenderer;
        //[Header ("AnyTags")]
        //[TagFilter (typeof(Tag))] public int[] tags;

        protected override void Setup () {
            this.entity.Set (componentSpriteRenderer);
            this.entity.Set (Tag.DepthSorting);
            //this.entity.Set(tags);
        }
    }
}