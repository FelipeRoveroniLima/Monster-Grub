using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float gameTime = 120;
    
    [SerializeField] private EndGameScreen endGameScreen;
    
    public static int score = 0;

    [SerializeField] private ScriptableSandwich[] sandwiches = new ScriptableSandwich[0];
    public static ScriptableSandwich[] Sandwiches => Instance.sandwiches;

    [SerializeField] private Vector3[] ingredientsPositions = new Vector3[0];

    [SerializeField] private SpriteRenderer currentPic;
    
    [SerializeField] private Sprite[] orderPics;

    private ScriptableSandwich _currentSandwichIndex;

    public static int SandwichOrder;


    [SerializeField] private GameObject plate;

    private readonly Random _random = new Random();

    public void Start()
    {
        plate.tag = "isInPlate";
        StartOrders();
    }

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    private void StartOrders()
    {
        int order = _random.Next(0, 4);

        _currentSandwichIndex = sandwiches[order];
        
        if (_currentSandwichIndex == sandwiches[0])
        {
            Debug.Log("Cheese Abomination");
            SandwichOrder = 0;
            currentPic.sprite = orderPics[0];
        }

        if (_currentSandwichIndex == sandwiches[1])
        {
            Debug.Log("Count Salami");
            SandwichOrder = 1;
            currentPic.sprite = orderPics[1];
        }
        
        if (_currentSandwichIndex == sandwiches[2])
        {
            Debug.Log("Meat Monster");
            SandwichOrder = 2;
            currentPic.sprite = orderPics[2];
        }
        
        if (_currentSandwichIndex == sandwiches[3])
        {
            Debug.Log("Swamp Thing");
            SandwichOrder = 3;
            currentPic.sprite = orderPics[3];
        }
        
        if (_currentSandwichIndex == sandwiches[4])
        {
            Debug.Log("Vegetarian Ghost");
            SandwichOrder = 4;
            currentPic.sprite = orderPics[4];
        }
    }

    private void Update()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            enabled = false;
            endGameScreen.Setup(score);
        }
    }
}
 