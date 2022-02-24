using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D gridArea;

    private void Start()
    {
        StartCoroutine(ChangePosition());
    }

    public void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        this.transform.position = new Vector2(x, y);
    }
   
    private IEnumerator ChangePosition()
    {
        RandomizePosition();
        yield return new WaitForSeconds(Random.Range(10f, 15f));
        StartCoroutine(ChangePosition());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Player1")
        {
            StartCoroutine(ChangePosition());
        }
    }

}
