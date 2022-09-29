using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public ScoreManager scoreManager;
    public float speed = 2.0f;
    public Boundary boundary;
    public float verticalPosition;
    public bool usingMobileInput = false;

    private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        transform.position = new Vector2(0.0f, verticalPosition);
        camera = Camera.main;

        // Platform Detection for input
        usingMobileInput = Application.platform == RuntimePlatform.Android || 
            Application.platform == RuntimePlatform.IPhonePlayer;

        /*if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
        {
            usingMobileInput = false;
        }
        else
        {
            usingMobileInput = true;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (usingMobileInput)
        {
            GetMobileInput();
        }
        else
        {
            GetConventionalInput();
        }

        Move();

        if (Input.GetKeyUp(KeyCode.K))
        {
            scoreManager.AddPoints(10);
        }
    }

    void GetConventionalInput()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        transform.position += new Vector3(x, 0, 0);
        //transform.position = new Vector2(Mathf.Clamp(transform.position.x, boundary.min, boundary.max), verticalPosition);
    }

    void GetMobileInput()
    {
        foreach (Touch touch in Input.touches)
        {
            var destination = camera.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * speed);
        }
    }

    void Move()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, boundary.min, boundary.max), verticalPosition);
    }
}
