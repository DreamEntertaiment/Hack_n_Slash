using UnityEngine;

public class SpellController : MonoBehaviour
{

    public void LmbSpell(Vector3 position)
    {
        Debug.Log("Attack");
    }

    public void RmbSpell(Vector3 position)
    {
        Debug.Log("IFrame");
    }

    public void QSpell(Transform player)
    {
        Debug.Log("QSpell");
    }

    public void ESpell(Vector3 position)
    {
        Debug.Log("ESpell");
    }

    public void RSpell(Vector3 position)
    {
        Debug.Log("RSpell");
    }

    public void ShiftSpell(Vector3 position)
    {
        Debug.Log("Shift");
    }
}
