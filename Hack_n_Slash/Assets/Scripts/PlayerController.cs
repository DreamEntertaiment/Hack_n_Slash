using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Stats _stats = new Stats();
    private SpellController _spellController;
    RaycastHit hit;

    [SerializeField] private float rmbCooldown, qCooldown, eCooldown, rCooldown, shiftCooldown;
    private float _rmbCooldown = 0, _qCooldown = 0, _eCooldown = 0, _rCooldown = 0, _shiftCooldown = 0;


    // Start is called before the first frame update
    void Start()
    {
        _spellController = this.gameObject.GetComponent<SpellController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        AttackHandler();
        CooldownManager();
    }
    /// <summary>
    /// Player Movement and Rotation(Player is looking at the cursor position)
    /// </summary>
    private void PlayerMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * _stats.BaseMovementSpeed * Time.deltaTime, Space.World);
        //Player Rotation

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (_spellController.qLength <= 0)
            {
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
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
        if (Input.GetKey(KeyCode.Mouse0) && _spellController.qLength <= 0)
        {
            _spellController.LmbSpell();
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void RmbClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && _rmbCooldown <= 0 && _spellController.qLength <= 0)
        {
            _spellController.RmbSpell();
            _rmbCooldown = rmbCooldown;
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void QClick()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _qCooldown <= 0)
        {
            _spellController.QSpell();
            _qCooldown = qCooldown;
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void EClick()
    {
        if (Input.GetKeyDown(KeyCode.E) && _eCooldown <= 0 && _spellController.qLength <= 0)
        {
            _spellController.ESpell();
            _eCooldown = eCooldown;
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void RClick()
    {
        if (Input.GetKeyDown(KeyCode.R) && _rCooldown <= 0 && _spellController.qLength <= 0)
        {
            _spellController.RSpell(hit.point);
            _rCooldown = rCooldown;
        }
    }
    /// <summary>
    /// Erklärung zum code bidde hier ^^
    /// </summary>
    private void ShiftClick()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _shiftCooldown <= 0)
        {
            _spellController.ShiftSpell(hit.point);
            _shiftCooldown = shiftCooldown;
        }
    }

    private void CooldownManager()
    {
        if (_qCooldown > 0)
        {
            _qCooldown -= Time.deltaTime;
        }
        if (_eCooldown > 0)
        {
            _eCooldown -= Time.deltaTime;
        }
        if (_rCooldown > 0)
        {
            _rCooldown -= Time.deltaTime;
        }
        if (_rmbCooldown > 0)
        {
            _rmbCooldown -= Time.deltaTime;
        }
        if (_shiftCooldown > 0)
        {
            _shiftCooldown -= Time.deltaTime;
        }
    }

}
