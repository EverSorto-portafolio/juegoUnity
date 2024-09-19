using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    private Rigidbody2D rb; 
    public float velocidadDeMovimiento = 10;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void MoviMiento() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direccion = new Vector2 (x, y);
        caminar(direccion);
    }
    private void caminar(Vector2 direccion) {
        rb.velocity = new Vector2(direccion.x * velocidadDeMovimiento, rb.velocity.y);
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoviMiento();
    }
}
