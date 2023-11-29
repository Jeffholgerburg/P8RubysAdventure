using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.magnitude > 1000.0f);
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force);
    private void OnCollisionEnter(Collision collision)
    {
        
    }

    EnemyController e = other.collider.GetComponent<EnemyController>();
    if (e != null)
    {
        e.Fix();
    }






