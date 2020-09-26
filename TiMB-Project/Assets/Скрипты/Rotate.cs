using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0, 1, 0));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // поле зрение камеры
        RaycastHit hit = new RaycastHit(); // хранит данные объекта с котором пересекся вектор камеры и параметры пересечения
        if (Physics.Raycast(ray, out hit)) // выполняется если хоть один объект встретился
        {
            Vector3 rot = transform.eulerAngles; // запись предыдущего угла Эйлера "Rotation"
            transform.LookAt(hit.point); // перевод в угол поворота из полученных координат при пересечении с объектом
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); // установка нового угла
        }
    }
}
