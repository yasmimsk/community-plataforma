using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptPC : MonoBehaviour
{
    public float velocidade = 8;
    public float pulo = 500;
    public float distancia = 1;
    public LayerMask mascara;
    public LayerMask mascaraFinal;
    public LayerMask mascaraMorte;

    private Rigidbody2D rbd;
    private Animator animator;
    //private bool chao = true;
    private bool direita = true;

    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool chao = transform.parent != null;

        float x = Input.GetAxis("Horizontal");
        animator.SetBool("parado", x == 0);
        if (x < 0 && direita || x > 0 && !direita)
        {
            direita = !direita;
            transform.Rotate(new Vector2(0, 180));
        }

        float velY;
        if (chao)
            velY = 0;
        else
            velY = rbd.velocity.y;

        rbd.velocity = new Vector2(x * velocidade, velY);

        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            //chao = false;
            transform.parent = null;
            rbd.AddForce(new Vector2(0, pulo));
        }

        VerificaColisoes();
    }

    private void VerificaColisoes()
    {
        //pulo em cima do inimigo
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, -transform.up, distancia + 0.2f, mascara);
        if (hitDown.collider != null)
            Destroy(hitDown.collider.gameObject);

        //colisão com o fim do jogo
        RaycastHit2D hitFinal = Physics2D.Raycast(transform.position, transform.right, distancia, mascaraFinal);
        if (hitFinal.collider != null)
            FimJogo();

        //colisão com inimigo
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.right, distancia, mascara);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, -transform.right, distancia, mascara);
        if (hitRight.collider != null || hitLeft.collider != null)
            Morte();

        //colisão quando cai e não tem mais chão
        hitDown = Physics2D.Raycast(transform.position, -transform.up, distancia, mascaraMorte);
        if (hitDown.collider != null)
            Morte();
    }

    private void FimJogo()
    {
        SceneManager.LoadScene(0);
    }

    private void Morte()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(2);
    }
}
