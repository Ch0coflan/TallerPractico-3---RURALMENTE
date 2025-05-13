using System;
using UnityEngine;

namespace Camera_Map
{
    public class AnimationActive : MonoBehaviour
    {
       private Animator _animator;


      private void Start()
      {
          _animator = GetComponent<Animator>();
      }

      public void PlayAnimation()
      {
          _animator.SetTrigger("Casa");
      }
      
      
      
    }
    
}
