using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject prefab;

/*    string[] answ = new Data().answers;*/
    private void Start()
    {
        float x = Canvas.GetComponent<RectTransform>().rect.x;
        float y = Canvas.GetComponent<RectTransform>().rect.y;
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j< 3;j++)
            {
                x += 10+ prefab.GetComponent<RectTransform>().rect.width;
                GameObject obj = Instantiate(prefab, prefab.transform.position = new Vector3(x, y, 0), Quaternion.identity);
                obj.transform.SetParent(Canvas.transform, false);
            }
            x = Canvas.GetComponent<RectTransform>().rect.x;
            y += 10 + prefab.GetComponent<RectTransform>().rect.height;
        }
    }
}
