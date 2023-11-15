using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    private Rigidbody2D rb2d;
    private Vector2 nuevaPosicion;
    [SerializeField] private float tiempoDeCambioDireccion;
    [SerializeField]private float temporizador;
    private float direccion;
    private int giros;
    private bool horizontal;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        temporizador = tiempoDeCambioDireccion;
        direccion = 1;
        horizontal = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(temporizador>0)
        {
            temporizador-=Time.deltaTime;
            
        }
        else
        {
            horizontal = !horizontal;
            temporizador = tiempoDeCambioDireccion;
            giros++;
        }
        if(giros==2)
        {
            direccion = -(direccion);
            giros = 0;
        }
    }
    private void FixedUpdate()
    {
        Caminar();
    }
    private void Caminar()
    {

        nuevaPosicion = rb2d.position;

        //nuevaPosicion.x = nuevaPosicion.x + velocidad;
        if (horizontal)
        {
            nuevaPosicion.x = nuevaPosicion.x + velocidad * direccion;
        }
        else
        {
            nuevaPosicion.y=nuevaPosicion.y+ velocidad * direccion;
        }
        rb2d.MovePosition(nuevaPosicion);
    }
}
