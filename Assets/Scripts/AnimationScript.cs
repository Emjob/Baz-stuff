using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public bool Absorb = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AbsorbElement()
    {
        Absorb = true;
        print("Should be absorbing rn!!!");
    }
}
