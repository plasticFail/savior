using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform knight; // ref to what we want to follow

    void LateUpdate()
    {
        //camera position
        Vector3 temp = transform.position;
        //set player x to same as camera position 
        temp.x = knight.position.x;
        //set player y to same as camera position 
        temp.y = knight.position.y;
        //set back camera's temp positon to the camera's current positon
        transform.position = temp;
    }

}
