using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class ExtendedCoroutineRunner
    {
        private MonoBehaviour _coroutineRunner;
        private Coroutine _runningCoroutine;
        private Action _onCoroutineAbortAction;

        private bool IsRunning => _runningCoroutine != null;

        public ExtendedCoroutineRunner(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void RunCoroutine(Func<Coroutine> coroutineToRun, Action onCoroutineAbort)
        {
            if (IsRunning) StopCoroutine();
            _onCoroutineAbortAction = onCoroutineAbort;
            _coroutineRunner.StartCoroutine(CoroutineRunner(coroutineToRun));
        }

        private IEnumerator CoroutineRunner(Func<Coroutine> coroutineRunner)
        {
           yield return _runningCoroutine = coroutineRunner();
           Debug.Log("Coroutine finished");
           _runningCoroutine = null;
        }

        private void StopCoroutine()
        {
            Debug.Log("Aborting coroutine");
            _onCoroutineAbortAction();
            _coroutineRunner.StopCoroutine(_runningCoroutine);
            _runningCoroutine = null;
        }
    }
}