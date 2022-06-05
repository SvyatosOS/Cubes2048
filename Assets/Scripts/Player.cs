using UnityEngine ;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed ;
    [SerializeField] private float pushForce ;
    [SerializeField] private float cubeMaxPosX ;
    [Space]
    [SerializeField] private TouchSlider touchSlider ;
    [SerializeField] AdsManager ads;

    private Cube mainCube ;
    private static int countCubes;
    int numberOfAttempts;
    private bool isPointerDown ;
    private bool canMove ;
    private Vector3 cubePos ;

    private void Start ()
    {
        numberOfAttempts = Random.Range(10, 20);
        SpawnCube () ;
      canMove = true ;

        touchSlider.OnPointerDownEvent += OnPointerDown;
        touchSlider.OnPointerDragEvent += OnPointerDrag;
        touchSlider.OnPointerUpEvent += OnPointerUp;
    }

   private void Update () 
   {
      if (isPointerDown)
         mainCube.transform.position = Vector3.Lerp (mainCube.transform.position, cubePos,moveSpeed * Time.deltaTime) ;
   }

   private void OnPointerDown () 
   {
      isPointerDown = true ;
   }

   private void OnPointerDrag (float xMovement)
   {
      if (isPointerDown) 
      {
         cubePos = mainCube.transform.position ;
         cubePos.x = xMovement * cubeMaxPosX ;
      }
   }

   private void OnPointerUp () 
   {
      if (isPointerDown && canMove)
      {
         isPointerDown = false ;
         canMove = false ;

         mainCube.CubeRigidbody.AddForce (Vector3.forward * pushForce, ForceMode.Impulse) ;

         Invoke ("SpawnNewCube", 0.3f) ;
      }
   }

   private void SpawnNewCube () 
   {
      mainCube.IsMainCube = false ;
      canMove = true ;
      SpawnCube () ;
   }

   private void SpawnCube ()
   {
      mainCube = CubeSpawner.Instance.SpawnRandom () ;
      mainCube.IsMainCube = true ;

      // reset cubePos variable
      cubePos = mainCube.transform.position ;
 
        countCubes++;
        ShowAd();
   }

    private void OnDestroy()
    {
        touchSlider.OnPointerDownEvent -= OnPointerDown;
        touchSlider.OnPointerDragEvent -= OnPointerDrag;
        touchSlider.OnPointerUpEvent -= OnPointerUp;
    }
    private void ShowAd()
    {
        if (countCubes % numberOfAttempts==0)
        {
            ads.StartShowAd();
        }
        
    }
}
