using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    private float horizontal;
    private float vertical;
    private Rigidbody2D rb2d;
    private Vector2 position;
    [Header("Vida")]
    [SerializeField] private int maximaVida;
    [SerializeField] private int vidaActual;
    [SerializeField] private float tiempoDeRecuperacionDeDaņo;
    [Header("Animaciones")]
    [SerializeField] private Animator animator;
    [SerializeField] private Vector2 lookDirection;
    [Header("Pryectil")]
    [SerializeField] private GameObject prefabProyectil;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        vidaActual = maximaVida;
        tiempoDeRecuperacionDeDaņo = 1.5f;
        animator = GetComponent<Animator>();
        lookDirection = new Vector2(1, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = Input.GetAxis("Horizontal");
        //vertical = Input.GetAxis("Vertical");
        ////Vector2 position = transform.position;
        //Vector2 position = rb.position;
        //position.x = position.x+velocidad*horizontal*Time.deltaTime;
        //position.y = position.y+velocidad*vertical*Time.deltaTime;
        ////transform.position = position;
        //rb.MovePosition(position);
        CogerInput();
        DecrementacionDelTemporizador();
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }
    private void FixedUpdate()
    {

        MoverJugador();
    }
    private void CogerInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", horizontal != 0 ? 1 : vertical != 0 ? 1 : 0);


    }
    private void MoverJugador()
    {
        Vector2 movimiento = new Vector2(horizontal, vertical);

        if (movimiento.x != 0.0f || movimiento.y != 0.0f)
        {
            lookDirection.Set(movimiento.x, movimiento.y);
            lookDirection.Normalize();
        }
        // Animaciones
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", movimiento.magnitude);

        position = rb2d.position;
        //position.x = position.x + velocidad * horizontal;
        //position.y = position.y + velocidad * vertical;
        position = position + movimiento * velocidad;
        //transform.position = position;
        rb2d.MovePosition(position);
    }
    private void DecrementacionDelTemporizador()
    {
        tiempoDeRecuperacionDeDaņo -= Time.deltaTime;
    }
    public float getTiempoDeRecuperacionDeDaņo()
    {
        return tiempoDeRecuperacionDeDaņo;
    }
    public void DaņarJugador()
    {
        vidaActual--;
        tiempoDeRecuperacionDeDaņo = 1.5f;
        animator.SetTrigger("Hit");

    }

    public void CurarJugador(GameObject objetoCurativo)
    {
        if (vidaActual < maximaVida)
        {
            vidaActual++;
            Destroy(objetoCurativo);
        }
    }
    private void Disparar()
    {
        GameObject proyectilGameObject = Instantiate(prefabProyectil, rb2d.position + Vector2.up * 0.5f, Quaternion.identity);
        //Proyectil proyectil = projectileObject.GetComponent<Proyectil>();
        if (proyectilGameObject.GetComponent<Proyectil>() == null)
        {
            Debug.LogError("Error en el prefab");
        }
        else
        {
            proyectilGameObject.GetComponent<Proyectil>().Disparo(lookDirection, 300f);
        }
        //proyectil.Disparo(lookDirection, 300);
        animator.SetTrigger("Launch");
    }

}
