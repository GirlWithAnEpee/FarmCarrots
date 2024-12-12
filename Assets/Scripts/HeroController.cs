using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody rb;
    private Animator anim;
    public float speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(0, 0, 0);
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        anim.SetBool("IsRunning", false);
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction += new Vector3(0, 0, -1);
        } 
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction += new Vector3(-1, 0, 0);
        }

        // передвигаем, нормализовав вектор по времени
        rb.MovePosition(transform.position + Vector3.Normalize(direction) * Time.deltaTime * speed);

        // и поворачиваем, если двигаемся
        if (direction != Vector3.zero)
        {
            rb.MoveRotation(Quaternion.LookRotation(direction));
            anim.SetBool("IsRunning", true);
        } else
        {
            anim.SetBool("IsRunning", false);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
        }
    }
}
