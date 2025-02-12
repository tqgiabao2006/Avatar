using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    [field: SerializeField] List<Transform> _points;
    [field: SerializeField] private float _speed;
    private int i;

    private void Start()
    {
        i = 0;
    }


    private void Update()
    {
        if(Vector2.Distance(this.transform.position, _points[i].transform.position) <= 0.2f)
        {
            i++;
            if(i == _points.Count)
            {
                i =0;
            }
        }else
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position, _points[i].transform.position, _speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  
    {
        if(collision.collider.gameObject.CompareTag("Player"))
        {
            collision.collider.gameObject.transform.SetParent(this.transform);

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
         if(collision.collider.gameObject.CompareTag("Player"))
        {
            collision.collider.gameObject.transform.SetParent(null);

        }
       
    }
    
}
