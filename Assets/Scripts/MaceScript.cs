using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceScript : MonoBehaviour
{
    public static AudioSource maceCollide;
    // Start is called before the first frame update
    void Start()
    {
        maceCollide = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
