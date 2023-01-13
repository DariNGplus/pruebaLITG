using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationShowcase : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetInteger("dance", GameObject.Find("GameMaster").GetComponent<GameMaster>().selectedIndex);
    }
}
