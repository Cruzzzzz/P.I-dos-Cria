[System.Serializable]
public class PlayerData
{
    public float posX;
    public float posY;
    public int vida;
    public int dinheiro;

    public PlayerData(PlayerHealth player, PlayerMoney money)
    {
        posX = player.transform.position.x;
        posY = player.transform.position.y;
        vida = player.GetCurrentHealth();
        dinheiro = money.currentMoney;
    }
}