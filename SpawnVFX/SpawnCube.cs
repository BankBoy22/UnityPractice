using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    public float maxValue;
    public float minValue;
    public float getValue;

    public float SpawnTime;

    public Material Original;
    public Material SpawnMaterial;

    private bool isStart = false;
    private bool isSpawn = false;
    private bool isSpawning = false;


    private void Start()
    {
        getValue = minValue;
    }

    private void Update()
    {
        if (isStart && !isSpawn)
        {
            SpawnObj();
        }
        
        if (isStart && isSpawn)
        {
            DestroyObj();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<MeshRenderer>().material = SpawnMaterial;
            if (isSpawn)
            {
                getValue = maxValue;
            }
            else
            {
                getValue = minValue;
            }      
            isStart = true;   
        }
    }

    private void SpawnObj()
    {
        getValue += SpawnTime * Time.deltaTime;

        if (maxValue > getValue)
        {
            SpawnMaterial.SetFloat("_Value", getValue);
        }

        else
        {
            SpawnMaterial.SetFloat("_Value", maxValue);
            gameObject.GetComponent<MeshRenderer>().material = Original;
            isStart = false;
            isSpawn = true;
            Debug.Log("Spawn");
        }
    }

    private void DestroyObj()
    {
        getValue -= SpawnTime * Time.deltaTime;

        if (minValue < getValue)
        {
            SpawnMaterial.SetFloat("_Value", getValue);
        }

        else
        {
            SpawnMaterial.SetFloat("_Value", minValue);
            isStart = false;
            isSpawn = false;
        }
    }
}
