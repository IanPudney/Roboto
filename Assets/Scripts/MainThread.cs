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
    Thread mainThread;
    public bool onMainThread
    {
        get { return mainThread == System.Threading.Thread.CurrentThread; }
    }
    public static MainThread main
    {
        get; private set;
    }

    public void Awake()
    {
        mainThread = System.Threading.Thread.CurrentThread;
        main = this;
    }

    public Semaphore runCoroutine(IEnumerator numerator)
    {
        if (onMainThread)
        {
            StartCoroutine(numerator);
            return null; // it's invalid to wait for a coroutine to finish on the main thread, since that coroutine must itself run on the main thread.
        } else
        {
            mutex.WaitOne();
            Func f = (new CoroutineBinder(this, numerator)).execute;
            functions.Enqueue(f);
            Semaphore s = new Semaphore(0, 1);
            sems.Enqueue(s);
            mutex.ReleaseMutex();
            return s;
        }
    }

    public void waitCoroutine(IEnumerator numerator)
    {
        if(onMainThread)
        {
            throw new UnityException("It is invalid to wait on a coroutine in the main thread, because the coroutine must run in the main thread.");
        }
        runCoroutine(numerator).WaitOne();
    }
    public Semaphore Run(Func f)
    {
        if(onMainThread)
        {
            f();
            return new Semaphore(1, 1);
        } else
        {
            mutex.WaitOne();
            functions.Enqueue(f);
            Semaphore s = new Semaphore(0, 1);
            sems.Enqueue(s);
            mutex.ReleaseMutex();
            return s;
        }
    }

    public void Wait(Func f)
    {
        Run(f).WaitOne();
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