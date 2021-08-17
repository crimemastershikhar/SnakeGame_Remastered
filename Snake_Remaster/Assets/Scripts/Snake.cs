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
    public Score scorecontrol;
    public GameOver GameOver;


    private void Start()
        {
        ResetState();
        }

    private void Update()
    {
        // Only allow turning up or down while moving in the x-axis
        if (this.direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.direction = Vector2.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (this.direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.direction = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.direction = Vector2.left;
            }
        }
    }
    private void FixedUpdate()
        {
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
            }
            // Move the snake in the direction it is facing
            float x = Mathf.Round(this.transform.position.x) + this.direction.x;
            float y = Mathf.Round(this.transform.position.y) + this.direction.y;
            this.transform.position = new Vector2(x, y);
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
                    // Start at 1 to skip destroying the head
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
/*        gameover.PlayerDied();*/
    }
    public void Gameover()
    {
        SceneManager.LoadScene(0);
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
            Gameover();
            }
            else if (other.tag == "Bottle")
            {
                Burn();
            }
         }

    }
