using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private Renderer m_Renderer;
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        m_Renderer = GetComponent<Renderer>();

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Disparo(Vector2 direccion, float fuerza)
    {
        rigidbody2d.AddForce(direccion * fuerza);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyController>().Muerto();
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GameArea")
        {
            Destroy(gameObject);
        }
    }
}
