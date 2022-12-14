using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get => FindObjectOfType<GameManager>(); }

    private float nextFire;
    private const float fireRate = 0.15f;

    private Player PlayerPrefab { get; set; }
    private GameObject BulletPrefab { get; set; }
    private GameObject BlockPrefab { get; set; }

    private Transform EnvironmentRef { get; set; }

    public UIManager uiManager;

    private void Awake()
    {
        PlayerPrefab = Resources.Load<Player>("player");
        BulletPrefab = Resources.Load<GameObject>("bullet");
        BlockPrefab = Resources.Load<GameObject>("block");

        EnvironmentRef = GameObject.Find("Environment").transform;
    }

    private void Start()
    {
        Block.OnCollisionEnter += () =>
        {
            var hit = Instantiate(Resources.Load<AudioSource>("hit"));
            hit.mute = GameObject.Find("SFX Source").GetComponent<AudioSource>().mute;

            if(SettingsManager.VibraEnable)
            {
                Handheld.Vibrate();
            }
        };
    }

    private void CreateLine()
    {
        Block[] blocks = FindObjectsOfType<Block>();
        foreach(Block b in blocks)
        {
            b.MoveDown();
        }
        
        float blockSize = 0.5f;
        float padding = 0.1f;

        float screenWorldWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        int blockCount = Mathf.RoundToInt(screenWorldWidth * 2 / (blockSize + padding));
        float xStart = -screenWorldWidth + (blockCount == 9 ? 0.4f : 0.325f);

        for(int i = 0; i < blockCount; i++)
        {
            if (Random.Range(0, 100) < 15)
            {
                continue;
            }

            Vector2 position = new Vector2(xStart + i * (blockSize + padding), GameObject.Find("topBorder").transform.position.y - 0.2f);
            Instantiate(BlockPrefab, position, Quaternion.identity, EnvironmentRef);
        }
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(BulletPrefab, EnvironmentRef);
        }
    }

    public void StartGame()
    {
        InvokeRepeating(nameof(CreateLine), 0.0f, 3.0f);
        Instantiate(PlayerPrefab, EnvironmentRef);
    }

    public void EndGame()
    {
        CancelInvoke(nameof(CreateLine));

        if (FindObjectOfType<Player>())
        {
            Destroy(FindObjectOfType<Player>().gameObject);
        }

        Block[] blocks = FindObjectsOfType<Block>();
        foreach(Block b in blocks)
        {
            Destroy(b.gameObject);
        }

        Bullet[] bullets = FindObjectsOfType<Bullet>();
        foreach(Bullet b in bullets)
        {
            Destroy(b.gameObject);
        }

        uiManager.OpenWindow(5);
    }
}