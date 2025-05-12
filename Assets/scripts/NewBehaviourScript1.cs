using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    bool facingRight;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
       if (Input.GetKeyDown (KeyCode.A)) {
         transform.right = new Vector3(-1, 0, 0);
         facingRight = false;
       }
       else if (Input.GetKeyDown (KeyCode.D)) {
         transform.right = new Vector3(1, 0, 0);
         facingRight = true;
       }
       float translate = Input.GetAxis("Horizontal");

       if(!facingRight)
         transform.Translate (Vector3.right * -translate * 5 * Time.deltaTime);
       else
         transform.Translate (Vector3.right * translate * 5 * Time.deltaTime);
    }
}