using System.Collections.Generic;
using UnityEngine;

public class GrenadeDestroy : MonoBehaviour
{
    private readonly HashSet<Collider> collidersInTrigger = new(); // 存储触发器内的碰撞体

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Actor") ||
            other.gameObject.layer == LayerMask.NameToLayer("Weapons"))
            collidersInTrigger.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Actor") ||
            other.gameObject.layer == LayerMask.NameToLayer("Weapons"))
            collidersInTrigger.Remove(other);
    }

    public HashSet<Collider> GetCollidersInTrigger()
    {
        return collidersInTrigger;
    }
}