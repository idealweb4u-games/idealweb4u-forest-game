using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{

    public Transform objectToFollow;
    public float followSpeed = 0.4f;
    bool isVisible = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    // Adds a 3 second delay before executing
    IEnumerator wait()
    {
        if (isVisible == true)
        {
            isVisible = false;
        }

        Debug.Log("Waiting for particles to be visible... ");
        yield return new WaitForSeconds(3);

        Debug.Log("Particles are visible now!");
        isVisible = true;

        while(true)
        {
            var delta = objectToFollow.position - transform.position;
            transform.position += delta * Time.deltaTime * followSpeed;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
