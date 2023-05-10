using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.ExtensionMethods
{
    public static class VectorExtension 
    {
        public static Vector3 ToVector3(this Vector2 value) => new Vector3(value.x, value.y, 0);

        public static Vector3Int ToVector3Int(this Vector3 value) => new Vector3Int((int)value.x, (int)value.y, (int)value.z);

        public static Vector3 ToVector3(this Vector3Int value) => new Vector3(value.x, value.y, value.z);
        

    }
}