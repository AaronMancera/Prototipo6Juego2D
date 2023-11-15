using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController controller = collision.GetComponent<PlayerController>();
        if (controller != null)
        {
            if (controller.getTiempoDeRecuperacionDeDa�o() <= 0)
            {
                controller.Da�arJugador();
                Debug.Log("Holaaa");
            }
        }
        
    }
}
