using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
 
    [SerializeField] Rigidbody2D[] rbs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Space))
        {
           
            foreach (Rigidbody2D rb in rbs)
            {
                rb.AddForce(Vector2.up);
            }
        }
  

    }
}
