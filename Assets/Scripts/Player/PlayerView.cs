using TMPro;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private TextMeshProUGUI playerCoinCountText;
    [SerializeField] private TextMeshProUGUI playerBagWeightText;
    [SerializeField] private TextMeshProUGUI playerBagCapacityText;

    private void OnDisable()
    {
        EventService.Instance.OnItemSoldWithFloatParams.RemoveListener(playerController.SetBagWeight);
        EventService.Instance.onItemBroughtWithIntParams.RemoveListener(playerController.DecreasePlayerCoin);
        EventService.Instance.OnItemSoldWithIntParams.RemoveListener(playerController.IncreasePlayerCoin);
    }

    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
        SetCoinText();
        SetPlayerBagCapacityText();
        SetBagWeightText();

        EventService.Instance.onItemBroughtWithIntParams.AddListener(playerController.DecreasePlayerCoin);
        EventService.Instance.OnItemSoldWithIntParams.AddListener(playerController.IncreasePlayerCoin);
        EventService.Instance.OnItemSoldWithFloatParams.AddListener(playerController.SetBagWeight);
    }

    public void SetCoinText()
    {
        playerCoinCountText.text = playerController.GetPlayerCoinCount().ToString();
    }

    public void SetBagWeightText()
    {
        playerBagWeightText.text = playerController.GetBagWeight().ToString("0.#");
        BagOverWeight();
    }

    private void BagOverWeight()
    {
        if (playerController.GetBagWeight() > playerController.GetBagCapacity())
            playerBagWeightText.color = Color.red;
        else
            playerBagWeightText.color = Color.white;
    }

    public void SetPlayerBagCapacityText()
    {
        playerBagCapacityText.text = " / " + playerController.GetBagCapacity().ToString() + " kg";
    }
}