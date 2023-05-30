using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    //саме яблуко, яке буде падати з дерева
    public GameObject applePrefab;
    //швидкість переміщення яблуні
    public float speed = 1f;
    //обмеження по руху яблуні зліва і справа
    public float leftAndRightAdge = 10f;
    //імовірність зміни напрямку руху яблуні
    public float chanceToChangeDirections = 0.1f;
    //частота створення яблук
    public float secondBetweenAppleDrops = 1f;   
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }
    private void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = this.transform.position;
        Invoke("DropApple", secondBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.x += speed * Time.deltaTime;
        this.transform.position = pos;

        if(pos.x <-leftAndRightAdge)
        {
            speed = Mathf.Abs(speed); 
        }
        else if(pos.x>leftAndRightAdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    private void FixedUpdate()
    {
        if(Random.value<chanceToChangeDirections)
        {
            speed *= -1;
        }
    }
}
