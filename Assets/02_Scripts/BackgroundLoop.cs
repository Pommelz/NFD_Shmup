using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    [SerializeField] List<GameObject> background;
    private Camera cameraMain;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        cameraMain = Camera.main;
        screenBounds = cameraMain.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cameraMain.transform.position.z));
        foreach (GameObject obj in background)
        {
            LoadChildObjects(obj);
        }
    }

    private void LoadChildObjects(GameObject obj)
    {
        float objectHeight = obj.GetComponent<SpriteRenderer>().bounds.size.y;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.y * 2 / objectHeight);
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i < childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(obj.transform.position.x, objectHeight * i, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
    void RepositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length >1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectHeight = lastChild.GetComponent<SpriteRenderer>().bounds.extents.y;
            if(transform.position.y + screenBounds.y > lastChild.transform.position.y + halfObjectHeight)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x, lastChild.transform.position.y + halfObjectHeight * 2, lastChild.transform.position.z);
            }else if(transform.position.y - screenBounds.y < firstChild.transform.position.y - halfObjectHeight){
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x, firstChild.transform.position.y + halfObjectHeight * 2, firstChild.transform.position.z);
            }

        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        foreach(GameObject obj in background)
        {
            RepositionChildObjects(obj);
        }
    }
}
