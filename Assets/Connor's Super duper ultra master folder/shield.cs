using UnityEngine;

public class Shield : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform shieldpoint;
    public GameObject shieldprototype;
    public bool shieldout = false;
    public float cooldownTime = 2f;
    public float nextshieldTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextshieldTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                startShield();
            }

        }


    }


    void startShield()
    {
        //Instantiate(shieldprototype, shieldpoint.position, shieldpoint.rotation);
        GameObject go = Instantiate(shieldprototype, shieldpoint.position, shieldpoint.rotation);
        go.transform.parent = GameObject.Find("shieldpoint").transform;
        shieldout = true;
    }



}
