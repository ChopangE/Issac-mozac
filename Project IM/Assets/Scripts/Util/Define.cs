using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
   public class Define 
   {
       public enum Classes {
           Archor, Mage, Warrior, None
       }

       public enum EnemyType
       {
           Slime, Skeleton,
       }

       public enum PrefabType
       {
           Weapon, Enemy,
       }

       public enum SceneType
       {
           UnKnown,MainMenu, InGame,
       }
   } 
}

