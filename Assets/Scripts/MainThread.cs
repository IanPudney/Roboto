using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Scripting;
using System;
using System.Threading;

public class MainThread : MonoBehaviour
{
    public delegate void Func();
    static Queue<Func> functions = new Queue<Func>();
    static Queue<Semaphore> sems = new Queue<Semaphore>();
    Mutex mutex = new Mutex();

    public static MainThread main
    {
        get; private set;
    }

    public void Awake()
    {
        main = this;
    }

    public Semaphore runCoroutine(IEnumerator numerator)
    {
        mutex.WaitOne();
        Func f = (new CoroutineBinder(this, numerator)).execute;
        functions.Enqueue(f);
        Semaphore s = new Semaphore(0, 1);
        sems.Enqueue(s);
        mutex.ReleaseMutex();
        return s;
        // don't wait on the semaphore, because this starts it async
    }

    public void waitCoroutine(IEnumerator numerator)
    {
        runCoroutine(numerator).WaitOne();
    }

    public void Run(Func f)
    {
        mutex.WaitOne();
        functions.Enqueue(f);
        Semaphore s = new Semaphore(0, 1);
        sems.Enqueue(s);
        mutex.ReleaseMutex();
        s.WaitOne();
    }

    void Update()
    {
        mutex.WaitOne();
        while (functions.Count > 0) {
            Func f = functions.Dequeue();
            Semaphore s = sems.Dequeue();
            mutex.ReleaseMutex();
            f();
            s.Release();
            mutex.WaitOne();
        }
        mutex.ReleaseMutex();
    }
}

class CoroutineBinder
{
    IEnumerator numerator;
    MonoBehaviour behaviour;
    public CoroutineBinder(MonoBehaviour behaviour, IEnumerator numerator)
    {
        this.behaviour = behaviour;
        this.numerator = numerator;
    }
    public void execute()
    {
        behaviour.StartCoroutine(numerator);
    }
}