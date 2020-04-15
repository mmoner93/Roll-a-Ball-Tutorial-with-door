using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public GameObject door;

    private Rigidbody rb;
    private int count;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
        if (count >= 8)
        {
            Vector3 movedoor = new Vector3 (0,1,0);
            if (door.transform.position.y < 3){
                door.transform.position = door.transform.position + movedoor;
            }
        }

    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
    }
      void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 16)
        {
            winText.text = "You Win!";
        }
    }
}
