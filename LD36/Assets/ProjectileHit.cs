using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour {

    public string fabricEvent;

    void OnCollisionEnter(Collision col)
    {
        Fabric.EventManager.Instance.PostEvent(fabricEvent, gameObject);
    }
}
