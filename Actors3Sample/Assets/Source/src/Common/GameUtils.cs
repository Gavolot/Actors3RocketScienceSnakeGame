using Pixeye.Actors;
using UnityEngine;
namespace Pixeye.Source {
    public static class GM_Utils {
        #region Vector2Utils
        public static bool EqualXY(this Vector2 me, Vector3 vect){
            if(me.x == vect.x && me.y == vect.y) return true;
            return false;
        }
        #endregion

        public static bool EqualXYZ(this Vector3 me, Vector3 vect){
            if(me.x == vect.x && me.y == vect.y && me.z == vect.z){
                return true;
            }
            return false;
        }

        #region QuatEquals
        public static bool EqualZ(this Quaternion qa, Quaternion qb){
            if(qa.z == qb.z && qa.w == qb.w){
                return true;
            }
            return false;
        }
        public static bool EqualX(this Quaternion qa, Quaternion qb){
            if(qa.x == qb.x && qa.w == qb.w){
                return true;
            }
            return false;
        }
        public static bool EqualY(this Quaternion qa, Quaternion qb){
            if(qa.y == qb.y && qa.w == qb.w){
                return true;
            }
            return false;
        }
        public static bool EqualXYZ(this Quaternion qa, Quaternion qb){
            if(qa.x == qb.x && qa.y == qb.y && qa.z == qb.z 
            && qa.w == qb.w){
                return true;
            }
            return false;
        }
        public static bool EqualXY(this Quaternion qa, Quaternion qb){
            if(qa.x == qb.x && qa.y == qb.y
            && qa.w == qb.w){
                return true;
            }
            return false;
        }
        public static bool EqualXZ(this Quaternion qa, Quaternion qb){
            if(qa.x == qb.x && qa.z == qb.z
            && qa.w == qb.w){
                return true;
            }
            return false;
        }
        public static bool EqualYZ(this Quaternion qa, Quaternion qb){
            if(qa.y == qb.y && qa.z == qb.z
            && qa.w == qb.w){
                return true;
            }
            return false;
        }
        #endregion
        public static bool place_meeting (ent me, float offsetX, float offsetY, Vector2 sizeBoxOverlap, LayerMask layerMask) {
            var vect = me.transform.position;
            vect.x += offsetX;
            vect.y += offsetY;
            if (Physics2D.OverlapBox (vect, sizeBoxOverlap, 0, layerMask)) {
                return true;
            }
            return false;
        }
        public static bool place_meeting (Vector2 position, Vector2 sizeBoxOverlap, LayerMask layerMask) {
            if (Physics2D.OverlapBox (position, sizeBoxOverlap, 0, layerMask)) {
                return true;
            }
            return false;
        }
        public static bool ContainBounds (this Bounds bounds, Bounds target) {
            return bounds.Contains (target.min) && bounds.Contains (target.max);
        }
        public static bool ExcludeTagsOr (ent entity, int[] tagsArr) {
            foreach (int tag in tagsArr) {
                if (entity.Has (tag)) {
                    return false;
                }
            }
            return true;
        }
        public static float Clamp360 (float eulerUnityAngle) {
            float resAngle = eulerUnityAngle - Mathf.CeilToInt (eulerUnityAngle / 360f) * 360f;
            if (resAngle < 0) {
                resAngle += 360f;
            }
            return resAngle;
        }

        public static float SmoothRotate360 (float angleClamped360From, float angleClamped360To, float speed) {
            var a = angleClamped360From - angleClamped360To;

            if (a > 180) {
                a = a - 360;
            } else if (a < -180) {
                a = a + 360;
            }

            if (a >= -speed && a <= speed) {
                angleClamped360From = angleClamped360To;
            } else if (a > speed) {
                angleClamped360From -= speed;
            } else if (a < -speed) {
                angleClamped360From += speed;
            }

            //if(angleClamped360From<0)angleClamped360From = 360;
            return angleClamped360From;
        }

        public static void Switch8thModel (Direction8th dir, ComponentSprite8thModel model, SpriteRenderer spr) {
            switch (dir) {
                case Direction8th.Up:
                    spr.sprite = model.Up;
                    break;
                case Direction8th.Down:
                    spr.sprite = model.Down;
                    break;
                case Direction8th.Left:
                    spr.sprite = model.Left;
                    break;
                case Direction8th.Right:
                    spr.sprite = model.Right;
                    break;
                case Direction8th.RightUp:
                    spr.sprite = model.RightUp;
                    break;
                case Direction8th.LeftUp:
                    spr.sprite = model.LeftUp;
                    break;
                case Direction8th.LeftDown:
                    spr.sprite = model.LeftDown;
                    break;
                case Direction8th.RightDown:
                    spr.sprite = model.RightDown;
                    break;
            }
        }
        public static void Switch8thModel (Direction8th dir, ComponentSpriteGroup8thModel model) {
            switch (dir) {
                case Direction8th.Up:
                    GM_Utils.ActivePatternArray (ref model._gmObjectsArray, false, model.Up);
                    break;
                case Direction8th.Down:
                    GM_Utils.ActivePatternArray (ref model._gmObjectsArray, false, model.Down);
                    break;
                case Direction8th.Left:
                    GM_Utils.ActivePatternArray (ref model._gmObjectsArray, false, model.Left);
                    break;
                case Direction8th.Right:
                    GM_Utils.ActivePatternArray (ref model._gmObjectsArray, false, model.Right);
                    break;
                case Direction8th.RightUp:
                    GM_Utils.ActivePatternArray (ref model._gmObjectsArray, false, model.RightUp);
                    break;
                case Direction8th.LeftUp:
                    GM_Utils.ActivePatternArray (ref model._gmObjectsArray, false, model.LeftUp);
                    break;
                case Direction8th.LeftDown:
                    GM_Utils.ActivePatternArray (ref model._gmObjectsArray, false, model.LeftDown);
                    break;
                case Direction8th.RightDown:
                    GM_Utils.ActivePatternArray (ref model._gmObjectsArray, false, model.RightDown);
                    break;
            }
        }
        public static void ActivePatternArray (ref GameObject[] array, bool active, GameObject excluding) {
            for (int i = 0; i < array.Length; i++) {
                if (array[i].GetInstanceID () != excluding.GetInstanceID ()) {
                    array[i].SetActive (active);
                }
            }
            excluding.SetActive (!active);
        }
    }

    public static class GM_SpecialUtils {
        /// <summary>
        /// initialize the random number generator with an integer seed,
        /// regardless of unity version
        /// </summary>
        public static void SetSeed (int seed) {

            seed = Mathf.Abs (seed);
#if UNITY_5_4_OR_NEWER
            UnityEngine.Random.InitState (seed);
#else
            UnityEngine.Random.seed = seed;
#endif

        }
        /// <summary>
        /// returns the state of a bob wave motion with the specified
        /// parameters at the current 'Time.time'.
        /// </summary>
        public static float Sinus (float rate, float amp, float offset = 0.0f) {
            return (Mathf.Cos ((UnityEngine.Time.time + offset) * rate) * amp);
        }
        /// <summary>
        /// Swap the first and second elements.
        /// </summary>
        /// <param name="array">The array that should be sorted.</param>
        /// <param name="firstIndex">The first index that should be swapped.</param>
        /// <param name="secondIndex">The second index that should be swapped.</param>
        private static void Swap<T> (T[] array, int firstIndex, int secondIndex) {
            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
        }
        public static void SetParentOrigin (this Transform transform, Transform parent) {
            transform.parent = parent;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
        /// <summary>
        /// Recursively sets the layer on all of the children.
        /// </summary>
        /// <param name="transform">The transform to set the layer on.</param>
        /// <param name="layer">The layer to set.</param>
        public static void SetLayerRecursively (this Transform transform, int layer) {
            transform.gameObject.layer = layer;
            for (int i = 0; i < transform.childCount; ++i) {
                transform.GetChild (i).SetLayerRecursively (layer);
            }
        }
        /// <summary>
        /// Returns the component of the specified type in the GameObject or any of its parents.
        /// </summary>
        /// <param name="transform">The transform to get the component on.</param>
        /// <typeparam name="T">The type of component to return.</typeparam>
        /// <returns>THe component of the specified type in the GameObject or any of its parents. Can be null.</returns>
        public static T GetComponentInParentIncludeInactive<T> (this Transform transform) where T : UnityEngine.Component {
            var parent = transform;
            T component;
            while (parent != null) {
                if ((component = parent.GetComponent<T> ()) != null) {
                    return component;
                }
                parent = parent.parent;
            }
            return null;
        }
    }

    public static class GM_Math {
        public static Vector2 RadianToVector2 (float radian) {
            return new Vector2 (Mathf.Cos (radian), Mathf.Sin (radian));
        }
        public static Vector2 RadianToVector2 (float radian, float length) {
            return RadianToVector2 (radian) * length;
        }
        public static Vector2 DegreeToVector2 (float degree) {
            return RadianToVector2 (degree * Mathf.Deg2Rad);
        }
        public static Vector2 DegreeToVector2 (float degree, float length) {
            return RadianToVector2 (degree * Mathf.Deg2Rad) * length;
        }
        /// <summary>
        /// Concatenate three integers into one. The first int will occupy the millions place, the second int will occupy the thousands place, and the third 
        /// int will occupy the hundeds place. For example, a value of 30, 52, 1 will return 30052001.
        /// </summary>
        /// <param name="a">The first integer to concatentate.</param>
        /// <param name="a">The second integer to concatentate.</param>
        /// <param name="a">The third integer to concatentate.</param>
        /// <returns>The concatenated integer.</returns>
        public static int Concatenate (int a, int b, int c) {
            return (a * 1000000) + (b * 1000) + c;
        }

        /// <summary>
        /// Returns true if layer is within the layerMask.
        /// </summary>
        /// <param name="layer">The layer to check.</param>
        /// <param name="layerMask">The mask to compare against.</param>
        /// <returns>True if the layer is within the layer mask.</returns>
        public static bool InLayerMask (int layer, int layerMask) {
            return ((1 << layer) & layerMask) == (1 << layer);
        }

        /// <summary>
        /// Clamp the angle between min and max degrees.
        /// </summary>
        /// <param name="angle">The angle to clamp.</param>
        /// <param name="min">The minimum angle range.</param>
        /// <param name="max">The maximum angle range.</param>
        /// <returns>An angle between min and max degrees.</returns>
        public static float ClampAngle (float angle, float min, float max) {
            var minDiff = ClampInnerAngle (min - angle);
            var maxDiff = ClampInnerAngle (angle - max);
            if (Mathf.Abs (minDiff) < Mathf.Abs (maxDiff)) {
                if (minDiff <= 0) {
                    return angle;
                }
                return min;
            }
            if (maxDiff <= 0) {
                return angle;
            }
            return max;
        }

        /// <summary>
        /// Clamp the angle between min and max degrees.
        /// </summary>
        /// <param name="angle">The original angle to clamp.</param>
        /// <param name="deltaAngle">The angle to add to the original angle.</param>
        /// <param name="min">The minimum angle range.</param>
        /// <param name="max">The maximum angle range.</param>
        /// <returns>An angle between min and max degrees.</returns>
        public static float ClampAngle (float angle, float deltaAngle, float min, float max) {
            var minDiff = ClampInnerAngle (min - angle);
            var maxDiff = ClampInnerAngle (angle - max);
            if (Mathf.Abs (minDiff) < Mathf.Abs (maxDiff)) {
                if (ClampInnerAngle (min - (angle + deltaAngle)) <= 0) {
                    return (angle + deltaAngle);
                }
                return min;
            }
            if (ClampInnerAngle ((angle + deltaAngle) - max) <= 0) {
                return (angle + deltaAngle);
            }
            return max;
        }

        /// <summary>
        /// Clamp the angle between 0 and 360 degrees.
        /// </summary>
        /// <param name="angle">The angle to clamp.</param>
        /// <returns>An angle between 0 and 360 degrees.</returns>
        public static float ClampAngle (float angle) {
            if (angle < 0) {
                angle += 360;
            }
            if (angle > 360) {
                angle -= 360;
            }
            return angle;
        }

        /// <summary>
        /// Clamp the angle between -180 and 180 degrees.
        /// </summary>
        /// <param name="angle">The angle to clamp.</param>
        /// <returns>An angle between -180 and 180 degrees.</returns>
        public static float ClampInnerAngle (float angle) {
            if (angle < -180) {
                angle += 360;
            }
            if (angle > 180) {
                angle -= 360;
            }
            return angle;
        }
    }
}