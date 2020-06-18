using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private SpellController spellController;

    [SerializeField]
    private float movementSpeed;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        spellController = this.gameObject.GetComponent<SpellController>();
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

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    private void AttackHandler()
    {
        LmbClick();
        RmbClick();
        QClick();
        EClick();
        RClick();
        ShiftClick();
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void LmbClick()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //NormalAttack
            spellController.LmbSpell(hit.point);
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void RmbClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //EyeFrame
            spellController.RmbSpell(hit.point);
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void QClick()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //GarenE
            spellController.QSpell(transform);
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void EClick()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //GravesUlt
            spellController.ESpell(hit.point);
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void RClick()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //CanonBall
            spellController.RSpell(hit.point);
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void ShiftClick()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Dash
            spellController.ShiftSpell(hit.point);
        }
    }

}
