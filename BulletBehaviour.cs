using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody _rBody;

    // Start is called before the first frame update
    void Start()
    {
        _rBody = this.GetComponent<Rigidbody>();
        _rBody.AddRelativeForce(0, 0, 500, ForceMode.Acceleration);
        GameManager.canShoot = false;
        Destroy(this.gameObject, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy") {
            GameManager.points += 1;
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        } else
            Destroy(this.gameObject);
    }

    private void OnDestroy() {
        GameManager.canShoot = true;
    }
}
