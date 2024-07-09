using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectionArea : MonoBehaviour
{
    [SerializeField] List<Transform> transforms;
    [SerializeField] List<Transform> walletSpawnPoints;
    [SerializeField] Transform walletSpawnPoint;
    [SerializeField] GameObject go;
    List<GameObject> gameObjects;
    List<GameObject> wallets;
    List<GameObject> instances;

    private void Awake()
    {
        gameObjects = new List<GameObject>();
        wallets = new List<GameObject>();
        instances = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wallet"))
        {

            InstantiateWalletInCollectionArea(other);
        }

    }


    void InstantiateWalletInCollectionArea(Collider other)
    {
        wallets.Add(other.gameObject);
        gameObjects.Add(other.gameObject);

        other.gameObject.SetActive(false);
        other.gameObject.tag = "Untagged";

        for (int i = 0; i < transforms.Count; i++)
        {
            if (gameObjects.Contains(other.gameObject))
            {
                GameObject instance = Instantiate(gameObjects[i], transforms[i].position, Quaternion.identity);

                instance.SetActive(true);
                transforms.RemoveAt(i);
                gameObjects.RemoveAt(i);

            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            InstantiatePlayer(other);

        }
    }

    void InstantiatePlayer(Collider other)
    {
        for (int i = 0; i < wallets.Count; i++)
        {

            GameObject instance = Instantiate(other.gameObject, new Vector3(walletSpawnPoints[i].position.x, other.gameObject.transform.position.y, walletSpawnPoints[i].position.z), Quaternion.identity);

            instances.Add(instance);

            instances[i].SetActive(true);

            instances[i].GetComponent<PlayerShooting>().enabled = true;
            instances[i].GetComponent<Money>().enabled = false;
            instances[i].GetComponent<PlayerMovement>().enabled = false;
            instances[i].GetComponent<BoxCollider>().size = new Vector3(0.5f, 1, 0.7f);
            instances[i].GetComponent<BoxCollider>().center = Vector3.zero;

            Destroy(instances[i].GetComponent<Rigidbody>());

            instances[i].tag = "Instance";

        }

        for (int i = 0; i < wallets.Count; i++)
        {
            instances[i].transform.parent = other.transform;
        }
    }
}