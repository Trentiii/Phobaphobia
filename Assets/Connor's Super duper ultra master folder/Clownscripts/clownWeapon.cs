using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clownWeapon : MonoBehaviour
{
    
    public int attackDamage = 20;

    public Vector3 attackOffset;
    public float attackRange = 2f;
    public LayerMask attackMask;

    public void attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colinfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if(colinfo != null)
        {
            colinfo.GetComponent<Player>().TakeDamage(attackDamage);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
