using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{

   bool hasPackage;
   [SerializeField] float tempoNuke = 0.5f;
   [SerializeField] Color32 corComPacote = new Color32(1,1,1,1);
   [SerializeField] Color32 corSemPacote = new Color32(0,0,0,0);

   SpriteRenderer spriteRenderer;


   void Start()
   {
        spriteRenderer = GetComponent<SpriteRenderer>();    
   }
   private void OnCollisionEnter2D(Collision2D other)
   {
       Debug.Log("IMPACTOOOOOOOOO");
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.tag == "Package" && !hasPackage) {
           Debug.Log("Pacote pego");
           hasPackage = true;
           Destroy(other.gameObject, tempoNuke);
           spriteRenderer.color = corComPacote;

       }

       if(other.tag == "Costumer" && hasPackage){
           Debug.Log("Pacote entregue");
           hasPackage = false;
           spriteRenderer.color = corSemPacote;
       }
   }
}
