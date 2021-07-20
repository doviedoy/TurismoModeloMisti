using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour {
        public float horizontalMove;
        public float verticalMove;
        private Vector3 playerInput;      
        public CharacterController player;
        public float playerSpeed;
        private Vector3 movePlayer; 
        public Camera mainCamera;       
        private Vector3 camForward;     
        private Vector3 camRight;    
  // Use this for initialization
  void Start () {
        player = GetComponent<CharacterController>();
  }
  
  // Update is called once per frame
  void Update () {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");            
        playerInput = new Vector3(horizontalMove, 0, verticalMove);     
        playerInput = Vector3.ClampMagnitude(playerInput, 1);           
        CamDirection();                                                 
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;     
        player.transform.LookAt(player.transform.position + movePlayer);        
        
        player.Move(movePlayer * playerSpeed * Time.deltaTime);  
   
        Debug.Log(player.velocity.magnitude);       
    }
    //Funcion para determinar la direccion a la que mira la camara.  
    public void CamDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
