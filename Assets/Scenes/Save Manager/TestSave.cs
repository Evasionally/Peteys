using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSave : MonoBehaviour
{
   private string test;
   private void Start()
   {
      test = "test";
   }

   private void OnCollisionEnter(Collision other)
   {
      SaveFile save = new SaveFile("test");
      save.Write("hello", "friend");
      string state = save.GetValue("hello");
      
      Debug.Log($"The save returned {state}");
   }
}
