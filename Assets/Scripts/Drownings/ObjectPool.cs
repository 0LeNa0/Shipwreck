using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    private List<GameObject> pooledDrownings = new List<GameObject>();
    [SerializeField] private int drowningsCount = 30;

    [SerializeField] private GameObject drowningPrefab;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }    
    }

    void Start()
    {
        for (int i = 0; i < drowningsCount; i++) {
            GameObject go = Instantiate(drowningPrefab);
            go.SetActive(false);
            pooledDrownings.Add(go);
        }
    }

    public GameObject GetBrickFromPool() {
        for (int i = 0; i < pooledDrownings.Count; i++) {
            if (!pooledDrownings[i].activeInHierarchy) {
                return pooledDrownings[i];
            }
        }
        return null;
    }

}
