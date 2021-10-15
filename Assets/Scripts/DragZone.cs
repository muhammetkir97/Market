using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragZone : MonoBehaviour , IDragHandler,IEndDragHandler,IBeginDragHandler,IPointerDownHandler,IPointerUpHandler
{
    Transform PickedObject = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(PickedObject != null)
        {
            Vector3 objectPos = GetDragWorldPosition(eventData.position);
            
            //objectPos.y = 5;
            PickedObject.position = objectPos;
            Debug.Log(eventData.position);
        }

    }

    Vector3 GetDragWorldPosition(Vector3 pos)
    {
        Vector3 dragPos = Vector3.zero;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(pos);
        int layerMask = 1 << 10;
        if (Physics.Raycast(ray,out hit,Mathf.Infinity,layerMask))
        {
            dragPos = hit.point;
            Debug.DrawLine(Camera.main.gameObject.transform.position,hit.point,Color.red,1f);
        }

        return dragPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(eventData.position);
        int layerMask = 1 << 9;
        if (Physics.Raycast(ray,out hit,Mathf.Infinity,layerMask))
        {
            Debug.DrawLine(Camera.main.gameObject.transform.position,hit.point,Color.red,1f);
            MarketObject temp = hit.transform.GetComponent<MarketObject>();
            if(temp != null)
            {
                PickedObject = temp.transform;
                temp.SetStatus(false);

            }
        }
            
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(PickedObject != null)
        {
            PickedObject.GetComponent<MarketObject>().SetStatus(true);
            PickedObject = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
