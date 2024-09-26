using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
   public class Define 
   {
       public enum Classes {
           Archer, Mage, Warrior, None
       }

       public enum EnemyType
       {
           Slime, Skeleton,
       }

       public enum PrefabType
       {
           Weapon, Enemy, Item,
       }

       public enum SceneType
       {
           UnKnown, MainMenu, InGame,
       }
   } 
}

