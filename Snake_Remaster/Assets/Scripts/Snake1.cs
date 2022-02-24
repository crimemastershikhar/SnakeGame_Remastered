using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake1 : MonoBehaviour
{
        private List<Transform> _segments = new List<Transform>();
        public Transform segmentPrefab;
        public Vector2 direction = Vector2.up;
        public int initialSize = 4;
    public Score scorecontrol1;

        private void Start()
        {
            ResetState();
        }
    private void Update()
    {
        if (this.direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                this.direction = Vector2.down;
            }
        }
        else if (this.direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.direction = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A))
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
                    for (int i = 1; i < _segments.Count; i++)
                    {
                        Destroy(_segments[i].gameObject);
                    }
                    _segments.Clear();
                _segments.Add(this.transform);
        for (int i = 0; i < this.initialSize; i++)
        {
            _segments.Add(Instantiate(this.segmentPrefab));
        }
    }       
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Food")
            {
                Grow();
            scorecontrol1.IncreaseScore(1);
            }
            else if (other.tag == "Obstacle")
            {
                GameOver();
            }
            else if (other.tag == "Bottle")
            {
                Burn();
            }
         }

    }
