using UnityEngine;

public class PlayerGunController : GunController
{

    void Update()
    {
        InputHandler();
    }

    void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Shoot();
        }
    }

 
}
