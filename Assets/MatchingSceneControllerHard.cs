using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchingSceneControllerHard : MonoBehaviour
{

    public const int gridRowsHard = 4;
    public const int gridColsHard = 6;
    public const float offsetXHard = 50f;
    public const float offsetYHard = 50f;

    [SerializeField] private MainCard originalCardHard;
    [SerializeField] private Sprite[] imagesHard;

    private void Start()
    {
        Vector3 startPos = originalCardHard.transform.position; //The position of the first card. All other cards are offset from here.

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11 };
        numbers = ShuffleArrayMedium(numbers); //This is a function we will create in a minute!

        for (int i = 0; i < gridColsHard; i++)
        {
            for (int j = 0; j < gridRowsHard; j++)
            {
                MainCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCardHard;
                }
                else
                {
                    card = Instantiate(originalCardHard) as MainCard;
                }

                int index = j * gridColsHard + i;
                int id = numbers[index];
                card.ChangeSprite(id, imagesHard[id]);

                float posX = (offsetXHard * i) + startPos.x;
                float posY = (offsetYHard * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }

    private int[] ShuffleArrayMedium(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------

    private MainCard _firstRevealedHard;
    private MainCard _secondRevealedHard;

    private int _scoreMedium = 0;
    [SerializeField] private TextMesh scoreLabelHard;

    public bool canReveal
    {
        get { return _secondRevealedHard == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if (_firstRevealedHard == null)
        {
            _firstRevealedHard = card;
        }
        else
        {
            _secondRevealedHard = card;
            StartCoroutine(CheckMatchHard());
        }
    }

    private IEnumerator CheckMatchHard()
    {
        if (_firstRevealedHard.id == _secondRevealedHard.id)
        {
            _scoreMedium++;
            scoreLabelHard.text = "Score: " + _scoreMedium;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealedHard.Unreveal();
            _secondRevealedHard.Unreveal();
        }

        _firstRevealedHard = null;
        _secondRevealedHard = null;

    }

    public void Restart()
    {
        SceneManager.LoadScene("Scene_001");
    }

}

