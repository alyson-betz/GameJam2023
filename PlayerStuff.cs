using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuff: MonoBehaviour
{
    Rigidbody2D body;
    Camera cam;
    GameObject g;
    //axes
    Vector2 axes;
    public float Speed = 20.0f;
    public Inventory inventory;
    
   

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        axes = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        var item = collision.gameObject.GetComponent<Item>();
        
        if ( item != null)
        {
            Debug.Log("I hit an item");
            AddToInventory(item);
            Destroy(collision.gameObject);
        }

    }

    //meant for calculating physics, but not updated every frame
    void FixedUpdate() 
    {
        if (!inventory.inventoryOpen)
        {
            body.velocity = new Vector2(axes.x * Speed, axes.y * Speed);
            body.transform.eulerAngles = PointToMouse(body.transform);
        }
    }

    private Vector3 PointToMouse(Transform player)
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        return new Vector3(0, 0, angle - 90); //this feels wrong...
    }


    private void AddToInventory(Item item)
    {
        inventory.AddToInventory(item);
    }
    
}
