using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Game
{
    public class BulletLifecycleController : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private float _deadTimer = 2;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_deadTimer);

            Destroy(gameObject);
        }
    }
}
