namespace Something.Scripts.Architecture
{
    public class GameConfig
    {
        public float damage;

        public GameConfig()
        {
            damage = 1f;
        }

        public void SetNewStats(GameConfig newConfig)
        {
            damage = newConfig.damage;
        }
    
        public GameConfig GetToDefault()
        {
            return new GameConfig();
        }
    }
}