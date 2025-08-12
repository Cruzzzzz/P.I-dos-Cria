[System.Serializable]
public class PlayerData
{
    public float posX;
    public float posY;
    public int vida;

    public PlayerData(PlayerHealth player)
    {
        posX = player.transform.position.x;
        posY = player.transform.position.y;
        vida = player.GetCurrentHealth();
    }
}