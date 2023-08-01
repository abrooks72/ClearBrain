using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchingSceneControllerMedium : MonoBehaviour
{

    public const int gridRowsMedium = 4;
    public const int gridColsMedium = 4;
    public const float offsetXMedium = 50f;
    public const float offsetYMedium = 50f;

    [SerializeField] private MainCard originalCardMedium;
    [SerializeField] private Sprite[] imagesMedium;

    private void Start()
    {
        Vector3 startPos = originalCardMedium.transform.position; //The position of the first card. All other cards are offset from here.

        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 };
        numbers = ShuffleArrayMedium(numbers); //This is a function we will create in a minute!

        for (int i = 0; i < gridColsMedium; i++)
        {
            for (int j = 0; j < gridRowsMedium; j++)
            {
                MainCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCardMedium;
                }
                else
                {
                    card = Instantiate(originalCardMedium) as MainCard;
                }

                int index = j * gridColsMedium + i;
                int id = numbers[index];
                card.ChangeSprite(id, imagesMedium[id]);

                float posX = (offsetXMedium * i) + startPos.x;
                float posY = (offsetYMedium * j) + startPos.y;
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

    private MainCard _firstRevealedMedium;
    private MainCard _secondRevealedMedium;

    private int _scoreMedium = 0;
    [SerializeField] private TextMesh scoreLabelMedium;

    public bool canReveal
    {
        get { return _secondRevealedMedium == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if (_firstRevealedMedium == null)
        {
            _firstRevealedMedium = card;
        }
        else
        {
            _secondRevealedMedium = card;
            StartCoroutine(CheckMatchMedium());
        }
    }

    private IEnumerator CheckMatchMedium()
    {
        if (_firstRevealedMedium.id == _secondRevealedMedium.id)
        {
            _scoreMedium++;
            scoreLabelMedium.text = "Score: " + _scoreMedium;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            _firstRevealedMedium.Unreveal();
            _secondRevealedMedium.Unreveal();
        }

        _firstRevealedMedium = null;
        _secondRevealedMedium = null;

    }

    public void Restart()
    {
        SceneManager.LoadScene("Scene_001");
    }

}
