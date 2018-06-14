using UnityEngine.UI;
using System.Collections;
using UnityEngine;

	
public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>(); 
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate()
	{
		float moveHorizontizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
	
		Vector3 movement = new Vector3 (moveHorizontizontal, 0.0f, moveVertical);

			rb.AddForce (movement * 15);
	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 10;
			SetCountText (); 
		}
	}

	void SetCountText ()
	{
		countText.text = "completion %; " + count.ToString ();
		if (count >= 100)
		{
			winText.text = "You Win";
		}
	}
}