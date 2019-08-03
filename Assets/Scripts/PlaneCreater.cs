using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCreater : MonoBehaviour
{
    public Texture background;
    public Texture topPlaneBackground;
    public Texture leftPlaneBackground;
    public Texture rightPlaneBackground;
    GameObject backgroundPlane,ChildObject;
    Ray ray;
    RaycastHit hit;
    float offset = 0.025f;
    float OffsetZ = 2.35f;
    float offsetX = 0.4f;
    Camera camera;
    Color color;
    float t = 1;
    float zoomValue=10;
    bool isRoll;
    void Start()
    {
        print(gameObject.transform.childCount);
        camera = GameObject.FindGameObjectWithTag(Tags.Camera).GetComponent<Camera>();
        SetAllPlanes();
    }

    public void SetAllPlanes()
    {
        if (gameObject.transform.childCount==1)
        {
            Destroy(transform.GetChild(0).gameObject);
            Invoke("SetAllPlanes", 0.001f);
        }
        else
        {
            SetPlane(background, Tags.Background, transform, Vector3.zero, Vector3.one);
            backgroundPlane = GameObject.Find(Tags.Background);
            PlaneSetup();
            
        }

        //print("PlaneSetup");
    }


     void PlaneSetup()
    {
            if (!isRoll)
            {
                TopPlane(OffsetZ);
                DownPlane(-OffsetZ);
                isRoll = true;
            }
            else
            {
                TopPlane(-OffsetZ);
                DownPlane(OffsetZ);
                isRoll = false;
            }

    }
    public void TopPlane(float offsetz)
    {
        Vector3 topPos = new Vector3(0, offset, offsetz);
        Vector3 topScale = new Vector3(offsetX + offsetX + offset + offset + offset, offsetX, offsetX);
        SetPlane(topPlaneBackground, Tags.TopHalfPlane, backgroundPlane.transform, topPos, topScale);
       
    }

    public void DownPlane(float offsetz)
    {
        Vector3 RPos = new Vector3(OffsetZ, offset, offsetz);
        Vector3 Scale = new Vector3(offsetX, offsetX, offsetX);
        SetPlane(rightPlaneBackground, Tags.RightBottomPlane, backgroundPlane.transform, RPos, Scale);
        Vector3 LPos = new Vector3(-OffsetZ, offset, offsetz);
        SetPlane(leftPlaneBackground, Tags.LeftBottomPlane, backgroundPlane.transform, LPos, Scale);
    }

    public void SetPlane(Texture texture,string planeName, Transform parent,Vector3 pos,Vector3 scale)
    {
       
            GameObject plane = CreatePlane(texture);
            plane.name = planeName;
            plane.transform.parent = parent;
            plane.transform.localPosition = pos;
            plane.transform.localScale = scale;
            plane.transform.localRotation = Quaternion.identity;

    }

    public GameObject CreatePlane(Texture texture)
    {
        GameObject plane= GameObject.CreatePrimitive(PrimitiveType.Plane);
        plane.GetComponent<MeshRenderer>().material.mainTexture = texture;
        return plane;
    }

    public void Raycast()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
           // print(hit.transform.gameObject.name);

            if(hit.transform.gameObject.name==Tags.LeftBottomPlane)
            {
                ApplyFading(hit, leftPlaneBackground);
                //  hit.transform.GetComponent<MeshRenderer>().material = Resources.Load("Mat") as Material;
                // hit.transform.GetComponent<MeshRenderer>().material.mainTexture = leftPlaneBackground;

                // t = t - Time.deltaTime;
                // Renderer ren = hit.transform.gameObject.GetComponent<Renderer>();

                // ren.material.SetFloat("_Mode", 2);
                //ren.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                //  ren.material.SetColor("_Color", ColorFade());
                //hit.transform.gameObject.SetActive(false);
                //ren.material.mainTexture = leftPlaneBackground;
                //hit.transform.gameObject.SetActive(true);
                // Color c1 = new Color(ren.material.color.r, ren.material.color.g, ren.material.color.b, 0.25f);
                // ren.material.SetColor("_Color", ColorFade());
                // color = new Color(1, 1, 1, 1);
                // ren.material.DisableKeyword("_ALPHATEST_ON");
                // ColorFading(ren);
                //  print(hit.transform.gameObject.GetComponent<MeshRenderer>().sharedMaterial.color);

            }
           else if (hit.transform.gameObject.name == Tags.RightBottomPlane)
            {
                ApplyFading(hit, rightPlaneBackground);
                //hit.transform.GetComponent<MeshRenderer>().material = Resources.Load("Mat") as Material;
               // hit.transform.GetComponent<MeshRenderer>().material.mainTexture = rightPlaneBackground;

               // t = t - Time.deltaTime;
               // Renderer ren = hit.transform.gameObject.GetComponent<Renderer>();

                // ren.material.SetFloat("_Mode", 2);
                //ren.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
               // ren.material.SetColor("_Color", ColorFade());
                //hit.transform.gameObject.SetActive(false);
                //ren.material.mainTexture = leftPlaneBackground;
                //hit.transform.gameObject.SetActive(true);
                // Color c1 = new Color(ren.material.color.r, ren.material.color.g, ren.material.color.b, 0.25f);
                // ren.material.SetColor("_Color", ColorFade());
                // color = new Color(1, 1, 1, 1);
                // ren.material.DisableKeyword("_ALPHATEST_ON");
                // ColorFading(ren);
                //  print(hit.transform.gameObject.GetComponent<MeshRenderer>().sharedMaterial.color);

            }
           else if (hit.transform.gameObject.name == Tags.TopHalfPlane)
            {
                ApplyFading(hit, topPlaneBackground);
               // hit.transform.GetComponent<MeshRenderer>().material = Resources.Load("Mat") as Material;
               //hit.transform.GetComponent<MeshRenderer>().material.mainTexture = topPlaneBackground;

                //  t = t - Time.deltaTime;
                // Renderer ren = hit.transform.gameObject.GetComponent<Renderer>();

                // ren.material.SetFloat("_Mode", 2);
                //ren.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                // ren.material.SetColor("_Color", ColorFade());
                //hit.transform.gameObject.SetActive(false);
                //ren.material.mainTexture = leftPlaneBackground;
                //hit.transform.gameObject.SetActive(true);
                // Color c1 = new Color(ren.material.color.r, ren.material.color.g, ren.material.color.b, 0.25f);
                // ren.material.SetColor("_Color", ColorFade());
                // color = new Color(1, 1, 1, 1);
                // ren.material.DisableKeyword("_ALPHATEST_ON");
                // ColorFading(ren);
                //  print(hit.transform.gameObject.GetComponent<MeshRenderer>().sharedMaterial.color);

            }

        }
    }

    void ApplyFading(RaycastHit hit, Texture texture)
    {

        hit.transform.GetComponent<MeshRenderer>().material = Resources.Load(Tags.NewMat) as Material;
        hit.transform.GetComponent<MeshRenderer>().material.mainTexture = texture;
        t = t - Time.deltaTime;
        Renderer ren = hit.transform.gameObject.GetComponent<Renderer>();
        ren.material.SetColor("_Color", ColorFade());

    }
   
    Color ColorFade()
    {
        if(t>0)
        {
            color = new Color(1, 1, 1, Mathf.Clamp(t, 0, 1));
            //print(color + " " + t);
        }
        else
        {
            color = new Color(1, 1, 1, 1);
            t = 1;
        }

        return color;
    }
    private void Update()
    {
        Raycast();
    }

    float posX, posZ;
    public void Zoom(string action)
    {
        if (action == Tags.ZoomIN)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position .x+ 3,-15, 0), 0, Mathf.Clamp(transform.position.z - 1, 0, 5));
            camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - zoomValue, 50, 100);
        }
        else
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x - 3,-15, 0), 0, Mathf.Clamp(transform.position.z + 1, 0, 5));
            camera.fieldOfView = Mathf.Clamp(camera.fieldOfView + zoomValue, 50, 100);
        }

    }
















} // class
