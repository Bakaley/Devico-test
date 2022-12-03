using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Collider2D))]
    public class BlackHoleOrbit : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _orbitSystem;
        
        [SerializeField] private float _rotationSpeed = 50;
        [SerializeField] private float _gravityCoefficient = 1;

        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.TryGetComponent(out Item item))
            {
                ApplyGravityForce(item);
            }
        }

        private void ApplyGravityForce(Item item)
        {
            Vector2 distance = transform.position - item.transform.position;
            float gravityForce = _gravityCoefficient / distance.magnitude;
            item.transform.Translate((distance).normalized * gravityForce,
                Space.World);
            item.transform.RotateAround(transform.position, Vector3.back, _rotationSpeed * Time.fixedDeltaTime);
            item.transform.rotation = Quaternion.identity;
        }

        public void SetOrbitColor(Gradient gradient, float timeOfChanging)
        {
            StartCoroutine(OrbitColorChangeCoroutine(gradient, timeOfChanging));
        }

        private IEnumerator OrbitColorChangeCoroutine(Gradient gradient, float timeOfChanging)
        {
            Gradient current = _orbitSystem.colorOverLifetime.color.gradient;
            float timer = 0;
            while (timer < timeOfChanging)
            {
                var colorOverLifetime = _orbitSystem.colorOverLifetime;
                colorOverLifetime.color = Utils.Gradient.Lerp(current, gradient, timer/timeOfChanging);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
