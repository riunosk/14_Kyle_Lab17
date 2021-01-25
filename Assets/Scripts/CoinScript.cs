using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public static AudioSource coinCollide;
    // Start is called before the first frame update
    void Start()
    {
        coinCollide = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
