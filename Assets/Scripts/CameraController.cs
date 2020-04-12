using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Keys attributes")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;


    [Header("Scroll attributes")]
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    private bool doMovement = true;

    private void Update()
    {
		
		if (GameManager.gameIsOver)
        {
            this.enabled = false;
            return;
        }
		
        if (Input.GetKeyDown(KeyCode.Escape)) doMovement = !doMovement;

        if (!doMovement) return;

        // go top
        if (Input.GetKey("z") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        // go bottom
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); 
        }
        // go right
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        // go left
        if (Input.GetKey("q") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); 
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;

        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}
