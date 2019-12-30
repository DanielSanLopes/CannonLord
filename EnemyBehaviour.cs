using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public Transform player;

    private Transform _transform;
    private Vector3 thisPosi;
    private float direction;
    private float[] bounds = new float [2];

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 33);

        _transform = this.GetComponent<Transform>();
        direction = 0;

        while (direction == 0)
            direction = Random.Range(-1, 1);

        thisPosi.x = _transform.localPosition.x;
        bounds[0] = thisPosi.x - 2;
        bounds[1] = thisPosi.x + 2;

    }

    // Update is called once per frame
    void Update() 
    {
        thisPosi.x = _transform.localPosition.x;
        thisPosi.y = _transform.localPosition.y;
        thisPosi.z = _transform.localPosition.z;


        if (thisPosi.x >= bounds[1])
            direction = -1;
        if (thisPosi.x <= bounds[0])
            direction = 1;

        _transform.localPosition =  new Vector3(thisPosi.x + (2f * direction) * Time.deltaTime, thisPosi.y, thisPosi.z - 0.4f * Time.deltaTime);

        _transform.LookAt(player);

    }

}
