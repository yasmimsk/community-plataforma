using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPe : MonoBehaviour
{
    public GameObject pc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pc.transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        pc.transform.parent = null;
    }
}
