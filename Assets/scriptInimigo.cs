using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptInimigo : MonoBehaviour
{
    public float velocidade = 3;
    public float distancia = 1;
    public LayerMask mascara;

    private Rigidbody2D rbd;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2(velocidade, 0);

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.right, distancia, mascara);
        if (hit.collider != null)
        {
            velocidade = velocidade * -1;
            rbd.velocity = new Vector2(velocidade, 0);
            transform.Rotate(new Vector2(0, 180));
        }
    }
}
