using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
   [Header("Grab interactable")]
   [SerializeField] XRGrabInteractable grabInteractable;
   [Header("Raycasting info")]
   [SerializeField] Transform RaycastOrigin;
   [SerializeField] LayerMask targetLayer;
   AudioSource gunAudioSource;
   [SerializeField] AudioClip gunClipSFX;
    

    [Header("target hit graphic")]
    [SerializeField] GameObject hitGraphic;
   


   private void Awake()
   {
    if(TryGetComponent(out AudioSource audio))
    {
        gunAudioSource = audio;
    }
    else
    {
        gunAudioSource = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
    }
   }

   private void OnEnable() => grabInteractable.activated.AddListener(TriggerPulled);
   private void OnDisable() => grabInteractable.activated.RemoveListener(TriggerPulled);


   private void TriggerPulled(ActivateEventArgs arg0)
   {
        arg0.interactor.GetComponent<XRBaseController>().SendHapticImpulse(.5f, .25f);

        XRBaseController controller = arg0.interactor.GetComponent<XRBaseController>();

        gunAudioSource.PlayOneShot(gunClipSFX);

        FireRaycastIntoScene();

   }


   private void FireRaycastIntoScene()
   {
    RaycastHit hit;

    if(Physics.Raycast(RaycastOrigin.position, RaycastOrigin.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, targetLayer))
    {
        if(hit.transform.GetComponent<ITargetInterface>() != null)
        {
            hit.transform.GetComponent<ITargetInterface>().TargetShot(hit.point);

            if(!GameManager.Instance.ShouldCreateHitGraphic)
            {
                return;
            }


            CreateHitGraphicOnTarget(hit.point);
        }
        else
        {
            Debug.Log("Not inheriting from interface");
        }
    }

   }

   private void CreateHitGraphicOnTarget(Vector3 hitLocation)
   {
    GameObject hitMarker = Instantiate(hitGraphic, hitLocation, Quaternion.identity);

   }  
}

