using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    bool basla = false;
    void Start()
    {
        Invoke("calistir", 10);
    }
   
    // Update is called once per frame
    void Update()
    {
        if (basla&&transform.position.z>-10)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 20);
          
          
        }
    }
    void calistir()
    {
        basla = !basla;
    }
  
}
