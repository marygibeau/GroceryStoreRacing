using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovementManager : MonoBehaviour
{
    float speed = 2;
    public GameObject building;
    public Vector3 buildingOriginalPosition;
    // Start is called before the first frame update
    void Start()
    {
        buildingOriginalPosition = building.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        building.transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public void TranslateScene()
    {
        building.transform.position = buildingOriginalPosition;
    }

    public void IncreaseSpeed()
    {
        speed++;
    }

    public void IncreaseSpeedByAmount(int amount) {
        speed += amount;
    }

    public void DecreaseSpeed()
    {
        speed--; 
    }
}
