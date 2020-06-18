using UnityEngine;

public class ShiftExplosionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.2f);
    }
}
