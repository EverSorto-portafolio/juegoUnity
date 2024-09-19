using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    private Rigidbody2D rb; 
    public float velocidadDeMovimiento = 10;
    public float fuerzaDeSalto = 5;
    private Vector2 direccion; 
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void MoviMiento() {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        direccion = new Vector2 (x, y);
        caminar(direccion);
        
        //detectamos si camina 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }

    }
    private void caminar(Vector2 direccion) {
        rb.velocity = new Vector2(direccion.x * velocidadDeMovimiento, rb.velocity.y);
    }
    private void Saltar() {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * fuerzaDeSalto;
    }
    private void mejorarSalto() {
        if (rb.velocity.y < 0)
        {

            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1) * Time.deltaTime;
        }
        else  if(
            rb.velocity.y > 0
            && 
            !Input.GetKeyDown(KeyCode.Space)
            
            ){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.0f - 1) * Time.deltaTime;
        }
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
