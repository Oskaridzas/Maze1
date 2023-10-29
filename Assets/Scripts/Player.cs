using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.name.Contains("Path") || !collision.gameObject.name.Contains("Finish"))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        var finalPosition = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPosition);
    }
}
