using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letters : MonoBehaviour
{
    public Data data;
    public char letter;
    // Start is called before the first frame update
    void Start()
    {
        data.word = letter;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
