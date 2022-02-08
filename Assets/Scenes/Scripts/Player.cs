using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject playerCamera;
    bool HoldBall = false;
    float ShootingForce = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.isPressed && HoldBall){
            GameObject throwable = this.gameObject.transform.GetChild(0).gameObject;
            throwable.transform.parent = null;
            HoldBall = false;
            Ball script = (Ball)throwable.GetComponent(typeof(Ball));
            script.HoldIt(false, ShootingForce, playerCamera);
            throwable.GetComponent<Rigidbody>().useGravity = true;                      
            throwable.GetComponent<Rigidbody>().AddForce((playerCamera.transform.position + playerCamera.transform.forward) * ShootingForce);
            
        }
        if(HoldBall){
            GameObject throwable = this.gameObject.transform.GetChild(0).gameObject;
            throwable.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.transform.GetChild(0).gameObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            /*
            if(this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.position.y < 0)
                this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.position = new Vector3(this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.position.x,0.1f,this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.position.z);
            if(this.gameObject.transform.GetChild(0).gameObject.transform.position.y < 0)
                this.gameObject.transform.GetChild(0).gameObject.transform.position = new Vector3(this.gameObject.transform.GetChild(0).gameObject.transform.position.x,0.1f,this.gameObject.transform.GetChild(0).gameObject.transform.position.z);
            */
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        //Debug.Log("collide");
        GameObject collider = collision.gameObject;
        if(collider.tag != null)
        {
            if(collider.tag == "Ball")
            {

                Ball script = (Ball)collider.GetComponent(typeof(Ball));
                script.HoldIt(true,ShootingForce,playerCamera);
                collider.transform.parent = this.gameObject.transform;
                HoldBall = true;
              
    
            }               
            
                

                
        }
            
        //if(collider.GetComponent<MeshFilter>().mesh)
    }
}
