using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public GameObject SBoost;

    private void Start()
    {
        StartCoroutine(ChangePosition());
    }

    public void RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;

        // Pick a random position inside the bounds
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        // Round the values to ensure it aligns with the grid
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


    /*    IEnumerator changePosTimer()
        {
            yield return new WaitForSeconds(10f);
            StartCoroutine(chnagePos());
        }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Pickup();
            RandomizePosition();
        }
    }
    void Pickup()
    {
        Instantiate(SBoost, transform.position, transform.rotation);

        Destroy(gameObject);
    }

}
