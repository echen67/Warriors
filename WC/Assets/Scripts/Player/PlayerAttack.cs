using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public int attackDamage;
    public int attackRange;

	void Start () {
	
	}
	
	void Update () {
        RaycastHit2D hitLeft = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(-1, 0), attackRange);
        RaycastHit2D hitRight = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(1, 0), attackRange);
    }
}
