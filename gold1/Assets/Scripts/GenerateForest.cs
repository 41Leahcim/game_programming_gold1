using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateForest : MonoBehaviour {
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int numberOfObjects;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    [SerializeField] private GameObject[] avoidObjects;
    [SerializeField] private float minimalDistance;

    // Checks whether the requested position is within any object, that should be avoided
    bool LegalPosition(Vector3 position){
        foreach(GameObject avoidable in avoidObjects){
            // Retrieve the position and scale of the object to avoid
            Vector3 avoidablePosition = avoidable.transform.position;
            Vector3 avoidableScale = avoidable.transform.localScale;

            // Return false, if requested position is within the object to avoid
            if(avoidablePosition.x + avoidableScale.x + minimalDistance < position.x &&
               avoidablePosition.x - avoidableScale.x - minimalDistance > position.x &&
               avoidablePosition.z + avoidableScale.z + minimalDistance < position.z &&
               avoidablePosition.z - avoidableScale.z - minimalDistance > position.z) {
                return false;
            }
        }

        // Return true, if the requested position is not within any object that should be avoided
        return true;
    }

    // Start is called before the first frame update
    void Start() {
        // Generate a random forest with numberOfObjects objects
        int i = 0;
        while(i < numberOfObjects){
            // Select a random object
            GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];

            // Generate a random position
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            Vector3 position = new Vector3(x, 0.0f, z);

            // Check whether the generated position is legal, and place the object if it is
            if(LegalPosition(position)){
                Instantiate(prefab, position, prefab.transform.rotation);
                i++;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
