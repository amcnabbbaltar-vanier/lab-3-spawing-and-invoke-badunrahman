using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Destroyu object after a few seconds

        Destroy(
            gameObject, 5f );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
