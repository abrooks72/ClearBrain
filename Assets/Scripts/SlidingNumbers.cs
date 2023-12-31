using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlidingNumbers : MonoBehaviour
{

    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] private TilesScript[] tiles;
    private int emptySpaceIndex = 15;
    private bool _isFinished;
    [SerializeField] private GameObject endPanel;
    [SerializeField] private Text endPanelTimeText;
    void Start()
    {
        _camera = Camera.main;
        endPanel.SetActive(false);
        Shuffle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                Debug.Log(hit.transform.name);

                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 7.5)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = findIndex(thisTile);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }
        }
        if (!_isFinished)
        {
            int correctTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                        correctTiles++;
                }
            }

            if (correctTiles == tiles.Length - 1)
            {
                endPanel.SetActive(true);
                _isFinished = true;
                var a = GetComponent<TimerScript>();
                a.StopTimer();
                endPanelTimeText.text = a.minutes + ":" + a.seconds;
            }
        }
        
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Shuffle()
    {
        if(emptySpaceIndex != 15)
        {
            var tileOn15LastPos = tiles[15].targetPosition;
            tiles[15].targetPosition = emptySpace.position;
            emptySpace.position = tileOn15LastPos;
            tiles[emptySpaceIndex] = tiles[15];
            tiles[15] = null;
            emptySpaceIndex = 15;
        }
        int invertion;
        do
        {

            for (int i = 0; i <= 14; i++)
            {
                if (tiles[i] != null)
                {
                    var lastPos = tiles[i].targetPosition;
                    int randomIndex = Random.Range(0, 14);
                    tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                    tiles[randomIndex].targetPosition = lastPos;
                    var tile = tiles[i];
                    tiles[i] = tiles[randomIndex];
                    tiles[randomIndex] = tile;
                }
            }
            invertion = GetInversions();
            Debug.Log("Puzzle Shuffled");
        } while (invertion %2 != 0);
    }

    public int findIndex(TilesScript ts)
    {
        for(int i = 0; i < tiles.Length; i++)
        {
            if(tiles[i] != null)
            {
                if(tiles[i] == ts)
                {
                    return i;
                }
            }
        }

        return -1;
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for(int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for(int j = i; j < tiles.Length; j++)
            {
                if(tiles[j] != null)
                {
                    if(tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }
}
