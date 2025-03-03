public class PlayerController
{
    private PlayerView playerView;
    private PlayerModel playerModel;

    public PlayerController(PlayerView playerView, PlayerModel playerModel)
    {
        this.playerView = playerView;
        this.playerModel = playerModel;
        this.playerView.SetPlayerController(this);
    }

    public int GetPlayerCoinCount() => playerModel.numberOfCoins;

    public void IncreasePlayerCoin(int coin)
    {
        playerModel.numberOfCoins += coin;
        playerView.SetCoinText();
    }

    public void DecreasePlayerCoin(int coin)
    {
        playerModel.numberOfCoins -= coin;
        playerView.SetCoinText();
    }

    public void SetBagWeight(float weight)
    {
        playerModel.bagWeight = weight;
        playerView.SetBagWeightText();
    }

    public float GetBagCapacity() => playerModel.bagCapacity;
    public float GetBagWeight() => playerModel.bagWeight;
}