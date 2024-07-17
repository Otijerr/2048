using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class CubeController : MonoBehaviour
{
    [SerializeField] private List<Colors> _colors;

    [SerializeField] private TextMeshPro _textMeshPro;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Rigidbody2D _rb2D;

    [SerializeField] private bool inTriggered = false;
    [SerializeField] private float triggerTime = 0f;
    [SerializeField] private float triggerDuration = 2f;
    private bool isMove = true;
    public static int MaxRnd = 1;
    public static int MaxNumber = 2;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        int rnd = Random.Range(0, MaxRnd);
        _spriteRenderer.color = _colors[rnd].Color;
        _textMeshPro.text = _colors[rnd].Number;
    }
    void Update()
    {
        if (inTriggered)
        {
            triggerTime -= 1 * Time.deltaTime;
            if (triggerTime <= 0)
            {
                _gameManager.SaveScore();
                _gameManager.RestartLevel();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            inTriggered = true;
            triggerTime = triggerDuration;
            _gameManager.SpawnCube();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger"))
        {
            inTriggered = false;
        }
    }
    private void OnMouseUp()
    {
        _rb2D.isKinematic = false;
        isMove = false;
    }
    private void OnMouseDrag()
    {
        if (isMove)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePosition.x > 1.62)
            {
                mousePosition.x = 1.62f;
            }
            else if (mousePosition.x < -1.62)
            {
                mousePosition.x = -1.62f;
            }
            _rb2D.position = new Vector2(mousePosition.x, _rb2D.position.y);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        CubeController cube = collision.gameObject.GetComponent<CubeController>();
        if (cube != null)
        {
            if (_textMeshPro.text == cube._textMeshPro.text)
            {
                for (int i = 0; i < _colors.Count; i++)
                {
                    if (_colors[i].Number == cube._textMeshPro.text)
                    {
                        _spriteRenderer.color = _colors[i + 1].Color;
                        _textMeshPro.text = _colors[i + 1].Number;
                        if (MaxNumber < int.Parse(_textMeshPro.text))
                        {
                            MaxNumber *= 2;
                            MaxRnd++;
                        }
                        _gameManager.UpdateScore(int.Parse(_textMeshPro.text));
                        Destroy(collision.gameObject);
                    }
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CubeController cube = collision.gameObject.GetComponent<CubeController>();
        if (cube != null)
        {
            if (_textMeshPro.text == cube._textMeshPro.text)
            {
                for (int i = 0; i < _colors.Count; i++)
                {
                    if (_colors[i].Number == cube._textMeshPro.text)
                    {
                        _spriteRenderer.color = _colors[i + 1].Color;
                        _textMeshPro.text = _colors[i + 1].Number;
                        if (MaxNumber < int.Parse(_textMeshPro.text))
                        {
                            MaxNumber *= 2;
                            MaxRnd++;
                        }
                        _gameManager.UpdateScore(int.Parse(_textMeshPro.text));
                        Destroy(collision.gameObject);
                    }
                }
            }
        }
    }
}
[System.Serializable]
public class Colors
{
    public Color Color;
    public string Number;
}
