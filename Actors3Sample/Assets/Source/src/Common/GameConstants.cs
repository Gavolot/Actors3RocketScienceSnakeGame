using UnityEngine;
namespace Pixeye.Source {
    public static class GameConstants {
        public const int PrecissionSortingValue = -100;
    }
    public enum Direction8th{
        RightUp,
        Up,
        LeftUp,
        Left,
        LeftDown,
        Down,
        RightDown,
        Right,
    }

    public struct Quat_8_Dirs {
        public static Quaternion Up = new Quaternion(0f, 0f, 0.7071068f, 0.7051068f);
        public static Quaternion Down = new Quaternion(0f, 0f, -0.7071068f, 0.7071068f);
        public static Quaternion Left = new Quaternion(0f, 0f, 1f, -4.371139e-08f);
        public static Quaternion Right = new Quaternion(0f, 0f, 0f, 1f);
        public static Quaternion RightDown = new Quaternion(0f, 0f, -0.3826834f, 0.9238796f);
        public static Quaternion LeftDown = new Quaternion(0f, 0f, -0.9238796f, 0.3826833f);
        public static Quaternion LeftUp = new Quaternion(0f, 0f, 0.9238796f, 0.3826833f);
        public static Quaternion RightUp = new Quaternion(0f, 0f, 0.3826834f, 0.9238796f);
    }

}