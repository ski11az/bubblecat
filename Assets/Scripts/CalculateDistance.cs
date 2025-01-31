using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    [SerializeField] GameObject point1_gameobject;
    [SerializeField] public GameObject point2_gameobject;
    [SerializeField] float baseDistance; // Ideal distance when "distance"-value should be 1 (no effects applied)

    private float _distance;

    private void Start()
    {
        if(point1_gameobject && point2_gameobject)
        {
            baseDistance = Vector3.Distance(point1_gameobject.transform.position, point2_gameobject.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (point1_gameobject && point2_gameobject)
        {
            _distance = GetDistance();
        }

        
        float maxDistance = 10f; 
        float normalizedDistance = Mathf.Clamp01(_distance / maxDistance);

        
        float volume = Mathf.Exp(-normalizedDistance * 10); 
        volume = Mathf.Clamp(volume, 0f, 1f); 

     
        float maxVolume = 0.8f;
        volume *= maxVolume; 

     
        float minVolume = 0.1f; 

        // Apply the volume to the audio source
        AudioManager.Instance.monsterSource.volume = Mathf.Max(volume, minVolume);
    }

    public float GetDistance() { // Returns distance as a value between 0-1
        // return Vector3.Distance(point1_gameobject.transform.position, point2_gameobject.transform.position) / baseDistance;
        return Mathf.Max(point2_gameobject.transform.position.y - point1_gameobject.transform.position.y, 0) / baseDistance;
    }

    public void SetTarget(int pointNo, GameObject target)
    {
        switch(pointNo)
        {
            case 1:
                point1_gameobject = target;
                break;
            case 2:
                point2_gameobject = target;
                break;
            default:
                Debug.Log("This isn't supposed to happen");
                break;
        }
    }
}
