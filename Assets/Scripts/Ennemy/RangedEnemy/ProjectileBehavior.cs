using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    float _projSpeed = 5f;
    Rigidbody2D _rb;
    [SerializeField]
    Transform _target;
    Vector2 _moveDirection;
    Vector2 _currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (!gameObject.name.Equals("originalProj"))
        {
            _rb = GetComponent<Rigidbody2D>();
            _moveDirection = (_target.transform.position - transform.position).normalized * _projSpeed;
            _rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Target") && !gameObject.name.Equals("originalProj"))
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag.Equals("Player"))
        {
            PlayerBehaviour pb = col.gameObject.GetComponent<PlayerBehaviour>();
            pb.CallEnnemyCollision();
        }
    }
}
