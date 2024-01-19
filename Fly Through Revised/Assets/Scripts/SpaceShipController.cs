using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShipController : MonoBehaviour
{
    [Header("Speed of moving forward")] public float speed = 1f;
    [Header("Speed of moving vertically and horizontally")] public float speed2DMax = 1f;
    [Header("Speed of reverse rotation")] public float speed2DBack = 1f;
    [Header("Speed of rotation")] public float rotationSpeed = 0.1f;

    private Touch touch;
    private int[] collectedStars = new int[3];
    private Vector2 touchPosition;
    private Quaternion rotationX;
    private Quaternion rotationZ;
    private float xRotationLimit = 0.18f;    //47 fix to euler angle 47
    private float zRotationLimit = 0.4f;   //16 fix to euler angle 16
    private float initialTouchPosX; // Location of touch on X-axis
    private float initialTouchPosY; // Location of touch on Y-axis
    private float speedX;   //Speed of finger moving across the screen on X-axis
    private float speedY;   //Speed of finger moving across the screen on Y-axis

    void Start()
    {
        collectedStars[0] = 0;
        collectedStars[1] = 0;
        collectedStars[2] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GameManager.instance.getCurrentState());
        //Transition Movement from menu screen
        if (GameManager.instance.getCurrentState() == GameManager.GameState.MoveForward && this.gameObject.transform.parent.gameObject.tag == "Player") 
        {
            this.gameObject.transform.parent.position += new Vector3(0, 0, Time.deltaTime * speed);
        } 
        //In game Movement
        else if (GameManager.instance.getCurrentState() == GameManager.GameState.Game && this.gameObject.transform.parent.gameObject.tag == "Player")
        {
            this.gameObject.transform.parent.position += new Vector3(0, 0, Time.deltaTime * speed);

            this.gameObject.transform.eulerAngles = new Vector3(
                    this.gameObject.transform.eulerAngles.x,
                    0,
                    this.gameObject.transform.eulerAngles.z);

            if (Input.touchCount > 0)   //While finger is touching the screen
            {
                touch = Input.GetTouch(0);
                //Position
                if (touch.phase == TouchPhase.Began)
                {
                    initialTouchPosX = touch.position.x;
                    initialTouchPosY = touch.position.y;
                }

                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    speedX = (touch.position.x - initialTouchPosX) / Screen.width * 2;
                    speedY = (touch.position.y - initialTouchPosY) / Screen.height * 2;

                    //Debug.Log("Initial Pos: "+ initialTouchPosY);
                    //Debug.Log("Current Pos: " + touch.position.y);
                    if (speedX > speed2DMax) { speedX = speed2DMax; }   //Max speed for going right
                    if (speedX < -speed2DMax) { speedX = -speed2DMax; } //Max speed for going left
                    if (speedY > speed2DMax) { speedY = speed2DMax; }   //Max speed for going up
                    if (speedY < -speed2DMax) { speedY = -speed2DMax; } //Max speed for going down

                    //Debug.Log(speedX * speed2DMax);
                    //Debug.Log("Old: " + this.gameObject.transform.parent.position.x);
                    this.gameObject.transform.parent.position += new Vector3( speedX * Time.deltaTime, speedY * Time.deltaTime, 0f);
                    //Debug.Log("New: " + this.gameObject.transform.parent.position.x);

                    if (transform.rotation.z > -zRotationLimit && transform.rotation.z < zRotationLimit) // Turn right or left
                    {
                        rotationZ = Quaternion.Euler(0f, 0f, -touch.deltaPosition.x * rotationSpeed);
                    }
                    if (transform.rotation.x > -xRotationLimit && transform.rotation.x < xRotationLimit)    //Go up or down
                    {
                        rotationX = Quaternion.Euler(-touch.deltaPosition.y * rotationSpeed, 0f, 0f);
                    }
                    transform.rotation = rotationZ * transform.rotation;
                    transform.rotation = rotationX * transform.rotation;

                    if (transform.eulerAngles.z <= 313f && transform.eulerAngles.z >= 180f)    // Fix Right turn
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(
                            this.gameObject.transform.eulerAngles.x,
                            this.gameObject.transform.eulerAngles.y,
                            -47f);

                    }
                    if (transform.eulerAngles.z >= 47f && transform.eulerAngles.z <= 180f) //Fix Left turn
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(
                            this.gameObject.transform.eulerAngles.x,
                            this.gameObject.transform.eulerAngles.y,
                            47f);
                    }
                    if (transform.eulerAngles.x >= 20f && transform.eulerAngles.x <= 180f)    // Fix Down turn
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(
                            20f,
                            this.gameObject.transform.eulerAngles.y,
                            this.gameObject.transform.eulerAngles.z);
                    }
                    if (transform.eulerAngles.x <= 340f && transform.eulerAngles.x >= 180f) //Fix Up turn
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(
                            -20f,
                            this.gameObject.transform.eulerAngles.y,
                            this.gameObject.transform.eulerAngles.z);
                    }
                }
            }
            else   //While finger is not touching the screen
            {
                if (transform.eulerAngles.z > 0f && transform.eulerAngles.z <= 180f) //Facing Left to forward
                {
                    this.gameObject.transform.eulerAngles = new Vector3(
                    this.gameObject.transform.eulerAngles.x,
                    this.gameObject.transform.eulerAngles.y,
                    this.gameObject.transform.eulerAngles.z - speed2DBack * Time.deltaTime);
                }
                if (transform.eulerAngles.z < 360f && transform.eulerAngles.z >= 180f) //Facing Right to forward
                {
                    this.gameObject.transform.eulerAngles = new Vector3(
                    this.gameObject.transform.eulerAngles.x,
                    this.gameObject.transform.eulerAngles.y,
                    this.gameObject.transform.eulerAngles.z + speed2DBack * Time.deltaTime);
                }
                if (transform.eulerAngles.x > 0f && transform.eulerAngles.x <= 180f) //Facing Down to forward
                {
                    this.gameObject.transform.eulerAngles = new Vector3(
                    this.gameObject.transform.eulerAngles.x - speed2DBack * Time.deltaTime,
                    this.gameObject.transform.eulerAngles.y,
                    this.gameObject.transform.eulerAngles.z);
                }
                if (transform.eulerAngles.x < 360f && transform.eulerAngles.x >= 180f) //Facing Up to forward
                {
                    this.gameObject.transform.eulerAngles = new Vector3(
                    this.gameObject.transform.eulerAngles.x + speed2DBack * Time.deltaTime,
                    this.gameObject.transform.eulerAngles.y,
                    this.gameObject.transform.eulerAngles.z);
                }
            }
        }
    }

    // Gets called after turn around animation on the ship
    public void moveForward()
    {
        this.gameObject.GetComponent<Animator>().enabled = false;
        GameManager.instance.UpdateGameState(GameManager.GameState.MoveForward);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Entrance")
        {
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().LoadNextLevel(GameManager.instance.selectedLevel);
        }
        else if (col.gameObject.tag == "Obstacle" || col.gameObject.tag == "environment")
        {
            Debug.Log("SpaceShipController collided");

            AudioManager.instance.ExplosionSFX();
        }
        else if (col.gameObject.tag == "Goal")
        {
            Debug.Log("Game Clear");
            GameManager.instance.UpdateGameState(GameManager.GameState.LevelClear);

            if (PlayerPrefs.GetInt("LevelUnlocked", 1) < SceneManager.GetActiveScene().buildIndex + 1) { PlayerPrefs.SetInt("LevelUnlocked", SceneManager.GetActiveScene().buildIndex + 1); }
            if (collectedStars[0] == 1) { PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex + "First", collectedStars[0]);}
            if (collectedStars[1] == 1) { PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex + "Middle", collectedStars[1]); }
            if (collectedStars[2] == 1) { PlayerPrefs.SetInt("Level" + SceneManager.GetActiveScene().buildIndex + "Last", collectedStars[2]); }

            AudioManager.instance.ClearSFX();
        }
        else if (col.gameObject.tag == "Star")
        {
            if (col.gameObject.name == "FirstStar(Clone)") { collectedStars[0] = 1; }
            else if (col.gameObject.name == "MiddleStar(Clone)") { collectedStars[1] = 1; }
            else if (col.gameObject.name == "LastStar(Clone)") { collectedStars[2] = 1; }
            else { Debug.Log("Dont't know what the name is!"); }
            AudioManager.instance.StarSFX();
            Destroy(col.gameObject);
        }
    }

    public void resetStarValues()
    {
        collectedStars[0] = 0;
        collectedStars[1] = 0;
        collectedStars[2] = 0;
    }
}
