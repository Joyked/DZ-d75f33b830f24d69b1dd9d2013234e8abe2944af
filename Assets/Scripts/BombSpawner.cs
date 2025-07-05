using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections;

public class BombSpawner : BaseSpawner<Bomb>
{
   [SerializeField] private CubeSpawner _cubeSpawner;
   
   
   public void SetParameters(int poolCapacity, int poolMaxSize)
   {
      _poolCapacity = poolCapacity;
      _poolMaxSize = poolMaxSize;
   }

   private void OnEnable()
   {
      _cubeSpawner.PositionForSpawnBomb += Spawn;
   }

   private void OnDisable() =>
      _cubeSpawner.PositionForSpawnBomb -= Spawn;

   private void Spawn(Vector3 position)
   {
      var bomb = _pool.Get();
      bomb.transform.position = position;
      ReturnToPool(bomb);
   }
   
   private void ReturnToPool(Bomb bomb)
   {
      int minSecond = 2;
      int maxSecond = 6;
      int randomSecond = Random.Range(minSecond, maxSecond);
      StartCoroutine(ExplosionTimer(randomSecond, bomb));
   }
    
   private IEnumerator ExplosionTimer(float second, Bomb bomb)
   {
      float elapsedTime = 0f;
      
      while (elapsedTime < second)
      {
         float progress = elapsedTime / second;
         float newAlpha = Mathf.Lerp(1f, 0.1f, progress);
         bomb.Repaint(newAlpha);
         elapsedTime += Time.deltaTime;
         yield return null;
      }
      
      bomb.Explode();
      bomb.gameObject.SetActive(false);
      _pool.Release(bomb);
   }
}
