using System.Collections.Generic;
using UnityEngine;

public class CollectionArea : MonoBehaviour
{
    [SerializeField] List<Transform> transforms;
    [SerializeField] List<Transform> walletSpawnPoints;
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

            instance.SetActive(true);

            instance.GetComponent<PlayerShooting>().enabled = true;
            instance.GetComponent<PlayerShooting>().SetOriginalPlayer(other.GetComponent<PlayerShooting>());
            instance.GetComponent<MoneyCollector>().enabled = false;
            instance.GetComponent<PlayerMovement>().enabled = false;
            instance.GetComponent<BoxCollider>().enabled = false;
            Destroy(instance.GetComponent<Rigidbody>());

            instance.tag = "Instance";

        }

        for (int i = 0; i < wallets.Count; i++)
        {
            instances[i].transform.parent = other.transform;
        }
    }
}
