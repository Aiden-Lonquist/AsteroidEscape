using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private float turningSpeed, moveSpeed;
    private Rigidbody2D rb;
    private GameObject player;
    public GameObject astroidImage;
    private Vector3 moveDir;

    // Start is called before the first frame update
    void Start()
    {
        turningSpeed = Random.Range(10f, 40f);
        int isOdd = Random.Range(0, 2);
        if (isOdd == 0)
        {
            turningSpeed *= -1;
        }
        moveSpeed = Random.Range(0.1f, 1.5f);
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
        moveDir = (player.transform.position - gameObject.transform.position).normalized;
        //Debug.Log("Player is at: " + player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        astroidImage.transform.Rotate(transform.forward * turningSpeed * Time.deltaTime);
    }

    public void MoveTowardsPlayer()
    {
        //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

        gameObject.transform.position += moveDir * Time.deltaTime * moveSpeed;
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision Detected with :" + collision.name);
        if (collision.CompareTag("boundary"))
        {
            Destroy(gameObject);
        }
    }*/
}
