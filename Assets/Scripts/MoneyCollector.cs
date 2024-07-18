using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyCollector : MonoBehaviour
{
    [SerializeField] float baseMoneyMultiplier;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {

            float calculatedAmountToBeAdded = (baseMoneyMultiplier + SceneManager.GetActiveScene().buildIndex * 2) * SaveManager.Instance.gameData.moneyIncomeMultiplier;

            MoneyManager.Instance.AddMoney(calculatedAmountToBeAdded);

            Destroy(other.gameObject);

        }

    }



}
