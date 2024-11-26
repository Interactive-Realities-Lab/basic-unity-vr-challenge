using UnityEngine;

public class ChangeColorOnGrab : MonoBehaviour{
    private Renderer objectRenderer;

    void Start(){
        objectRenderer = GetComponent<Renderer>();
    }

    void Update(){
        // color changes when press "space" on keyboard
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    public void ChangeColor(){
        objectRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}