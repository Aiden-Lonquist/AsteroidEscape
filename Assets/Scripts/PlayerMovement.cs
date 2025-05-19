using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Sprite spr0, spr1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayerAnimation());
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        movement = movement.normalized;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.linearVelocity = movement * speed * 2;
        } else
        {
            rb.linearVelocity = movement * speed;
        }
        //movement = movement.normalized;
        if (movement != Vector3.zero)
        {
            transform.up = movement;
        }
    }

    private IEnumerator PlayerAnimation()
    {
        while (true)
        {
            if (sr.sprite == spr0)
            {
                sr.sprite = spr1;
            }
            else
            {
                sr.sprite = spr0;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("asteroid"))
        {
            Debug.Log("GAME OVER");
            string s = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(s);
        }
    }
}
