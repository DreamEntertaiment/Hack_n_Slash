using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        AttackHandler();
    }
    /// <summary>
    /// Player Movement and Rotation(Player is looking at the cursor position)
    /// </summary>
    private void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        //Player Rotation
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    private void AttackHandler()
    {
        LMBclick();
        RMBclick();
        Qclick();
        Eclick();
        Rclick();
        SHIFTclick();
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void LMBclick()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //NormalAttack
            Debug.Log("LMB");
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void RMBclick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //EyeFrame
            Debug.Log("RMB");
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void Qclick()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //GarenE
            Debug.Log("Q");
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void Eclick()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //GravesUlt
            Debug.Log("E");
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void Rclick()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //CanonBall
            Debug.Log("R");
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void SHIFTclick()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Dash
            Debug.Log("SWUSCH!!");
        }
    }

}
