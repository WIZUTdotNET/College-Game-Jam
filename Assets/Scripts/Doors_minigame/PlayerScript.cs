using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Sprite[] _playerSprites;
    private SpriteRenderer _playerSpriteRenderer;
    private Sprite _newSprite;
    private Rigidbody2D _rigidbody2D;
    private string _playerColor;
    private int _score;
    private int _spriteID;
    private int _oldSpriteID;
    
    private void Start()
    {
        _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
        _oldSpriteID = -1;
        ChangeColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody2D.MovePosition(transform.position + Vector3.up);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            _rigidbody2D.MovePosition(transform.position + Vector3.down);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
        {
            string otherColor = other.GetComponent<Door>().doorColor;
            CheckDoor(otherColor);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Door"))
            if (_score % 5 == 0)
                Connect();
    }
    

    private void ChangeColor()
    {
        while ((_spriteID = Random.Range(0, _playerSprites.Length)) == _oldSpriteID) ;
        _newSprite = _playerSprites[_spriteID];
        _playerSpriteRenderer.sprite = _newSprite;
        _oldSpriteID = _spriteID;

        int underscoreLocation = _newSprite.name.IndexOf("_");
        _playerColor = _newSprite.name.Substring(0, underscoreLocation);
    }

    private void CheckDoor(string doorColor)
    {
        if (doorColor == _playerColor)
        {
            _score++;
        }
        else
        {
            Lose();
        }
    }

    private void Lose()
    {
        DoorsMovement[] allDoorsWithEvent = (DoorsMovement[]) GameObject.FindObjectsOfType(typeof(DoorsMovement));
        foreach (var doorsMovement in allDoorsWithEvent)
        {
            doorsMovement.DestroyDoors();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Connect()
    {
        ChangeColor();
        TickSystem.SpeedThingsUp();
    }
}
