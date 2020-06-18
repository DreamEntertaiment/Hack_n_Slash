using UnityEngine;

public class SpellController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] shootPoints = new GameObject[4];
    [SerializeField]
    private GameObject[] gunQSpell = new GameObject[2];
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject eProjectilePrefab;
    [SerializeField] private GameObject rPrefab;
    [SerializeField] private GameObject shiftExplosionPrefab;
    private float _rmbInternalCd = 0;
    private float _lmbInternalCd = 0;
    public float qLength = 0;
    public bool isInvisible = false;

    private void Update()
    {
        InternalCooldownManager();
        RmbManager();
        QManager();
    }

    public void LmbSpell()
    {
        if (_lmbInternalCd <= 0)
        {
            Instantiate(projectilePrefab, shootPoints[0].transform.position, shootPoints[0].transform.rotation);
            Instantiate(projectilePrefab, shootPoints[1].transform.position, shootPoints[1].transform.rotation);
            _lmbInternalCd = 0.1f;
        }
    }

    public void RmbSpell()
    {
        isInvisible = true;
        _rmbInternalCd = 0.5f;
    }

    public void QSpell()
    {
        qLength = 5;
        gunQSpell[0].SetActive(false);
        gunQSpell[1].SetActive(true);
    }

    public void ESpell()
    {
        Instantiate(eProjectilePrefab, shootPoints[3].transform.position, shootPoints[3].transform.rotation);
    }

    public void RSpell(Vector3 position)
    {
        Instantiate(rPrefab, new Vector3(position.x, 50, position.z), Quaternion.identity);
    }

    public void ShiftSpell(Vector3 position)
    {
        Instantiate(shiftExplosionPrefab, new Vector3(transform.position.x, 1, transform.position.z), transform.rotation);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(position.x, transform.position.y, position.z), 6);
    }

    private void InternalCooldownManager()
    {
        if (_rmbInternalCd > 0)
        {
            _rmbInternalCd -= Time.deltaTime;
        }
        if (_lmbInternalCd > 0)
        {
            _lmbInternalCd -= Time.deltaTime;
        }
        if (qLength > 0)
        {
            qLength -= Time.deltaTime;
        }
    }

    private void RmbManager()
    {
        if (isInvisible == true && _rmbInternalCd <= 0)
        {
            isInvisible = false;
        }
    }

    private void QManager()
    {
        if (qLength > 0)
        {
            transform.Rotate(new Vector3(0, 1, 0), 500 * Time.deltaTime);
            Instantiate(projectilePrefab, shootPoints[0].transform.position, shootPoints[0].transform.rotation);
            Instantiate(projectilePrefab, shootPoints[2].transform.position, shootPoints[2].transform.rotation);
        }
        else if (gunQSpell[1].activeSelf == true)
        {
            gunQSpell[1].SetActive(false);
            gunQSpell[0].SetActive(true);
        }
    }
}
