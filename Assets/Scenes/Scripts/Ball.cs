using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    bool Aim = false;
    float ShootingForce = 0f;
    GameObject PlayerCamera;

    int counter = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (counter == 30)
        {
            if (Aim)
            {
                GameObject aimBall = Instantiate(this.gameObject.transform.GetChild(1).gameObject, this.gameObject.transform.position, this.gameObject.transform.rotation);
                aimBall.transform.parent = null;
                aimBall.GetComponent<Rigidbody>().useGravity = true;
                aimBall.GetComponent<Rigidbody>().AddForce((PlayerCamera.transform.position + this.gameObject.transform.forward) * ShootingForce);
                Destroy(aimBall, 1.0f);
                
            }
            counter = 0;
        }
        counter++;
    }

    public void HoldIt(bool aim, float shootingForce, GameObject playerCamera)
    {
        Aim = aim;
        ShootingForce = shootingForce;
        PlayerCamera = playerCamera;
    }
}
