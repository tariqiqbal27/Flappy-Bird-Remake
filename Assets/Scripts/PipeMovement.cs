using UnityEngine;
using Random = UnityEngine.Random;

public class PipeMovement : MonoBehaviour {
    
    [SerializeField] public float speed = 2f;

    [SerializeField] Sprite[] pipes;
    [SerializeField] public SpriteRenderer[] childSpriteRenderer;
    private int _numPipes;

    

    private void Awake() {
        childSpriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Start() {
        _numPipes = pipes.Length;
        int indexTop = Random.Range(0, _numPipes);
        int indexBottom = Random.Range(0, _numPipes);
        childSpriteRenderer[0].sprite = pipes[indexTop];
        childSpriteRenderer[1].sprite = pipes[indexBottom];
    }

    void Update() {
        // move to left
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < -8.5) {
            float y = Random.Range(-2f, 2f);
            int indexTop = Random.Range(0, _numPipes);
            int indexBottom = Random.Range(0, _numPipes);
            childSpriteRenderer[0].sprite = pipes[indexTop];
            childSpriteRenderer[1].sprite = pipes[indexBottom];
            transform.position = new Vector3(13.5f, y,  transform.position.z);
        }
        
    }
    
}
