using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake : MonoBehaviour
{
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public Vector2 direction = Vector2.right;
    public int initialSize = 4;
    private Vector2Int gridposition;
    public GameObject pauseUI;
    private bool isPaused;
    public Score scorecontrol;
    public GameOver gameOver;
    public Collider2D gridArea;
    private float minX, maxX, minY, maxY;


    private void Start()
    {
        ResetState();
        Bounds bound = gridArea.bounds;
        minX = bound.min.x;
        maxX = bound.max.x;
        minY = bound.min.y;
        maxY = bound.max.y;
    }

    private void Update()
    {
        if (this.direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.direction = Vector2.up;
                gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.direction = Vector2.down;
                gameObject.transform.localEulerAngles = new Vector3(0, 0, 180);
            }
        }
        else if (this.direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.direction = Vector2.right;
                gameObject.transform.localEulerAngles = new Vector3(0, 0, -90);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.direction = Vector2.left;
                gameObject.transform.localEulerAngles = new Vector3(0, 0, 90);
            }
        }
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        ScreenWrap();
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        float x = Mathf.Round(this.transform.position.x) + this.direction.x;
        float y = Mathf.Round(this.transform.position.y) + this.direction.y;
        this.transform.position = new Vector2(x, y);
    }
    private void ScreenWrap()
    {
        Vector3 newPos = transform.position;

        if (newPos.x > maxX)
        {
            newPos.x = -newPos.x + 1f;
        }
        else if (newPos.x <= minX)
        {
            newPos.x = -newPos.x - 1f;
        }

        if (newPos.y >= maxY)
        {
            newPos.y = -newPos.y + 1f;
        }
        else if (newPos.y <= minY)
        {
            newPos.y = -newPos.y - 1f;
        }

        transform.position = newPos;
    }

    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);

    }
    public void Burn()
    {
        Transform segment = _segments[_segments.Count - 1].transform;
        _segments.Remove(segment);
        Destroy(segment.gameObject);
    }

    public void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(this.transform);
        // this.transform.position = Vector3.zero;
        for (int i = 0; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }
    }
    public void killsnake()
    {
        Debug.Log("snake Died");
        gameOver.SnakeDied();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            scorecontrol.IncreaseScore(1);
        }
        else if (other.tag == "Obstacle")
        {
            killsnake();
        }
        else if (other.tag == "Bottle")
        {
            Burn();
            scorecontrol.DecreaseScore(1);
        }
    }
}
