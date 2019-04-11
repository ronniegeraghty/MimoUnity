using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  private bool facingRight;
  

  void Start () {
    facingRight = true;
  }

  void Update () {
    var rigidBody = GetComponent<Rigidbody2D> ();
    var transform = GetComponent<Transform> ();
    if (Input.GetKey ("right")) {
      rigidBody.velocity = new Vector2 (5, rigidBody.velocity.y);
    }
    if (Input.GetKey ("left")) {
      rigidBody.velocity = new Vector2 (-5, rigidBody.velocity.y);
    }
    if (Input.GetKeyDown ("space")) {
      rigidBody.velocity = new Vector2 (rigidBody.velocity.x, 10);
    }
    if (transform.position.y < -6) {
      if (transform.position.x < 2) {
        transform.position = new Vector2 (-5, 2);
      } else {
        transform.position = new Vector2 (2, 2);
      }
    }
  }

  //Update is called once per frame 
  void FixedUpdate(){
    float horizontal = Input.GetAxis("Horizontal");
    Flip(horizontal);
  }
  
  private void Flip(float horizontal){
    if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight){
      facingRight = !facingRight;
      Vector3 theScale = transform.localScale;
      theScale.x *= -1;
      transform.localScale = theScale;
    }
  }
}
