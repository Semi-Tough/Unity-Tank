using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public ResourceService ResourceService;
    public AudioService AudioService;
    public PoolService PoolService;
    
    public StartSystem StartSystem;
    public GameSystem GameSystem;
    private void Awake()
    {
        DontDestroyOnLoad(this);

        ResourceService.InitService();
        AudioService.InitService();
        PoolService.InitService();
        
        StartSystem.InitSystem();
        GameSystem.InitSystem();
        StartSystem.InitStartScene();
    }
}