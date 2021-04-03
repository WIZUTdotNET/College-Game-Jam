using System;
using UnityEngine;

public class DoorsMovement : MonoBehaviour
{
    private Rigidbody2D _wall;
    private EventHandler<TickSystem.OnTickEvents> tickSystemDelegate;
    private Vector2 _screenBounds;

    private void Start()
    {
        _wall = GetComponent<Rigidbody2D>();
        tickSystemDelegate = delegate(object sender, TickSystem.OnTickEvents events)
        {
            _wall.MovePosition(transform.position + Vector3.left);
        };
        TickSystem.OnTick += tickSystemDelegate;

        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(
            Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void Update()
    {
        if (transform.position.x <= -_screenBounds.x * 1.2f)
        {
            DestroyDoors();
        }
    }

    public void DestroyDoors()
    {
        TickSystem.OnTick -= tickSystemDelegate;
        Destroy(gameObject);
    }
}