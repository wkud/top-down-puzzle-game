using System.Collections;
using UnityEngine;

namespace Project.Movement
{
    public interface ICollider 
    {
        Vector3Int ColliderPosition { get; }
        bool IsColliderEnabled { get; }
        GameObject GameObject { get; }
    }
}