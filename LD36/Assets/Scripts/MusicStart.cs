using UnityEngine;
using System.Collections;

public class MusicStart : MonoBehaviour {

    void Start()
    {
        Fabric.EventManager.Instance.PostEvent("play music"); // kaikki träkit ruoeavat soimaan startissa
    }
}
