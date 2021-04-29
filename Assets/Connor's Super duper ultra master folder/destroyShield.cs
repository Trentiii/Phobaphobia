using UnityEngine;

public class destroyShield : MonoBehaviour
{
    public GameObject shieldpoint;
    public Shield Sscript;
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject shieldpoint = GameObject.Find("shieldpoint");
        Sscript = shieldpoint.GetComponent<Shield>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > Sscript.nextshieldTime & Sscript.shieldout == true)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                Destroy(gameObject);
                Sscript.nextshieldTime = Time.time + Sscript.cooldownTime;
                Sscript.shieldout = false;
            }
        }
    }

}
