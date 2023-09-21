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
            wallets.Add(other.gameObject);
            gameObjects.Add(other.gameObject);

            other.gameObject.SetActive(false);
            Debug.Log(wallets.Count);
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

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            for (int i = 0; i < wallets.Count; i++)
            {
                Debug.Log(wallets.Count);

                float xPos;

                if (i % 2 == 0)
                {
                    if (i == 0)
                    {
                        xPos = other.transform.position.x + i + 1;
                    }
                    else
                    {
                        xPos = other.transform.position.x + i;
                    }

                }
                else
                {
                    xPos = other.transform.position.x - i;
                }

                GameObject instance = Instantiate(other.gameObject, new Vector3(xPos, other.transform.position.y, other.transform.position.z), Quaternion.identity);
                instances.Add(instance);
                instances[i].SetActive(true);

                instances[i].GetComponent<PlayerShooting>().enabled = true;
                instances[i].GetComponent<Money>().enabled = false;
                instances[i].GetComponent<PlayerMovement>().enabled = false;

                other.gameObject.GetComponent<PlayerMovement>().cloneAmount = i - 0.5f;
                //instances[i].GetComponent<Collider>().enabled = false;
                //Destroy(instances[i].GetComponent<Rigidbody>());



                instances[i].tag = "Instance";

            }

            for (int i = 0; i < wallets.Count; i++)
            {
                instances[i].transform.parent = other.transform;
            }

        }
    }
}
