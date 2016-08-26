using UnityEngine;
using System.Collections;
using System;
public class PythonScript : EventBehaviour {
    public string pythonClass;
    Interpreter python = new Interpreter();
    public object pyInstance { get; private set; }
    public ConfigurableValue[] keyValues;
    public override void Awake()
    {
        pyInstance = python.ConstructPyClass(pythonClass, pythonClass, new object[]{ this, keyValues});        
        base.Awake();
        CallPyMethod("Awake");
    }
    
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        CallPyMethod("FixedUpdate");
    }
    
    public override void LateUpdate()
    {
        base.LateUpdate();
        CallPyMethod("LateUpdate");
    }
    
    public override void OnAnimatorIK(int layerIndex)
    {
        base.OnAnimatorIK(layerIndex);
        CallPyMethod("OnAnimatorIK", new object[] { layerIndex });
    }
    
    public override void OnAnimatorMove()
    {
        base.OnAnimatorMove();
        CallPyMethod("OnAnimatorMove");
    }
    
    public override void OnApplicationFocus()
    {
        base.OnApplicationFocus();
        CallPyMethod("OnApplicationFocus");
    }
    
    public override void OnApplicationPause()
    {
        base.OnApplicationPause();
        CallPyMethod("OnApplicationPause");
    }
    
    public override void OnApplicationQuit()
    {
        base.OnApplicationQuit();
        CallPyMethod("OnApplicationQuit");
    }
    
    public override void OnAudioFilterRead(float[] data, int channels)
    {
        base.OnAudioFilterRead(data, channels);
        CallPyMethod("OnAudioFilterRead", new object[] { data, channels });
    }
    
    public override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
        CallPyMethod("OnBecameInvisible");
    }
    
    public override void OnBecameVisible()
    {
        base.OnBecameVisible();
        CallPyMethod("OnBecameVisible");
    }
    
    public override void OnCollisionEnter(Collision col)
    {
        base.OnCollisionEnter(col);
        CallPyMethod("OnCollisionEnter", new object[] { col });
    }
    
    public override void OnCollisionEnter2D(Collision2D col)
    {
        base.OnCollisionEnter2D(col);
        CallPyMethod("OnCollisionEnter2D", new object[] { col });
    }
    
    public override void OnCollisionExit(Collision col)
    {
        base.OnCollisionExit(col);
        CallPyMethod("OnCollisionExit", new object[] { col });
    }
    
    public override void OnCollisionExit2D(Collision2D col)
    {
        base.OnCollisionExit2D(col);
        CallPyMethod("OnCollisionExit2D", new object[] { col });
    }
    
    public override void OnCollisionStay(Collision col)
    {
        base.OnCollisionStay(col);
        CallPyMethod("OnCollisionStay", new object[] { col });
    }
    
    public override void OnCollisionStay2D(Collision2D col)
    {
        base.OnCollisionStay2D(col);
        CallPyMethod("OnCollisionStay2D", new object[] { col });
    }
    
    public override void OnConnectedToServer()
    {
        base.OnConnectedToServer();
        CallPyMethod("OnConnectedToServer");
    }
    
    public override void OnControllerColliderHit(ControllerColliderHit col)
    {
        base.OnControllerColliderHit(col);
        CallPyMethod("OnControllerColliderHit", new object[] { col });
    }
    
    public override void OnDestroy()
    {
        CallPyMethod("OnDestroy");
        base.OnDestroy();
    }
    
    public override void OnDisable()
    {
        base.OnDisable();
        CallPyMethod("OnDisable");
    }
    
    public override void OnDisconnectedFromServer(NetworkDisconnection col)
    {
        base.OnDisconnectedFromServer(col);
        CallPyMethod("OnDisconnectedFromServer", new object[] { col });
    }
    
    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        CallPyMethod("OnDrawGizmos");
    }
    
    public override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        CallPyMethod("OnDrawGizmosSelected");
    }
    
    public override void OnEnable()
    {
        base.OnEnable();
        CallPyMethod("OnEnable");
    }
    
    public override void OnFailedToConnect(NetworkConnectionError col)
    {
        base.OnFailedToConnect(col);
        CallPyMethod("OnFailedToConnect", new object[] { col });
    }
    
    public override void OnFailedToConnectToMasterServer(NetworkConnectionError col)
    {
        base.OnFailedToConnectToMasterServer(col);
        CallPyMethod("OnFailedToConnectToMasterServer", new object[] { col });
    }
    
    public override void OnGUI()
    {
        base.OnGUI();
        CallPyMethod("OnGUI");
    }
    
    public override void OnJointBreak(float param)
    {
        base.OnJointBreak(param);
        CallPyMethod("OnJointBreak", new object[] { param });
    }
    
    public override void OnJointBreak2D(Joint2D joint)
    {
        base.OnJointBreak2D(joint);
        CallPyMethod("OnJointBreak2D", new object[] { joint });
    }
    
    public override void OnLevelWasLoaded(int param)
    {
        base.OnLevelWasLoaded(param);
        CallPyMethod("OnLevelWasLoaded", new object[] { param });
    }
    
    public override void OnMasterServerEvent(MasterServerEvent param)
    {
        base.OnMasterServerEvent(param);
        CallPyMethod("OnMasterServerEvent", new object[] { param });
    }
    
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        CallPyMethod("OnMouseDown");
    }
    
    public override void OnMouseDrag()
    {
        base.OnMouseDrag();
        CallPyMethod("OnMouseDrag");
    }
    
    public override void OnMouseEnter()
    {
        base.OnMouseEnter();
        CallPyMethod("OnMouseEnter");
    }
    
    public override void OnMouseExit()
    {
        base.OnMouseExit();
        CallPyMethod("OnMouseExit");
    }
    
    public override void OnMouseOver()
    {
        base.OnMouseOver();
        CallPyMethod("OnMouseOver");
    }
    
    public override void OnMouseUp()
    {
        base.OnMouseUp();
        CallPyMethod("OnMouseUp");
    }
    
    public override void OnMouseUpAsButton()
    {
        base.OnMouseUpAsButton();
        CallPyMethod("OnMouseUpAsButton");
    }
    
    public override void OnNetworkInstantiate(NetworkMessageInfo param)
    {
        base.OnNetworkInstantiate(param);
        CallPyMethod("OnNetworkInstantiate", new object[] { param });
    }
    
    public override void OnParticleCollision(GameObject param)
    {
        base.OnParticleCollision(param);
        CallPyMethod("OnParticleCollision", new object[] { param });
    }
    
    public override void OnPlayerConnected(NetworkPlayer param)
    {
        base.OnPlayerConnected(param);
        CallPyMethod("OnPlayerConnected", new object[] { param });
    }
    
    public override void OnPlayerDisconnected(NetworkPlayer param)
    {
        base.OnPlayerDisconnected(param);
        CallPyMethod("OnPlayerDisconnected", new object[] { param });
    }
    
    public override void OnPostRender()
    {
        base.OnPostRender();
        CallPyMethod("OnPostRender");
    }
    
    public override void OnPreCull()
    {
        base.OnPreCull();
        CallPyMethod("OnPreCull");
    }
    
    public override void OnPreRender()
    {
        base.OnPreRender();
        CallPyMethod("OnPreRender");
    }
    
    public override void OnRenderImage(RenderTexture left, RenderTexture right)
    {
        base.OnRenderImage(left, right);
        CallPyMethod("OnRenderImage", new object[] { left, right });
    }
    
    public override void OnRenderObject()
    {
        base.OnRenderObject();
        CallPyMethod("OnRenderObject");
    }
    
    public override void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        base.OnSerializeNetworkView(stream, info);
        CallPyMethod("OnSerializeNetworkView", new object[] { stream, info });
    }
    
    public override void OnServerInitialized()
    {
        base.OnServerInitialized();
        CallPyMethod("OnServerInitialized");
    }
    
    public override void OnTransformChildrenChanged()
    {
        base.OnTransformChildrenChanged();
        CallPyMethod("OnTransformChildrenChanged");
    }
    
    public override void OnTransformParentChanged()
    {
        base.OnTransformParentChanged();
        CallPyMethod("OnTransformParentChanged");
    }
    
    public override void OnTriggerEnter(Collider param)
    {
        base.OnTriggerEnter(param);
        CallPyMethod("OnTriggerEnter", new object[] { param });
    }
    
    public override void OnTriggerEnter2D(Collider2D param)
    {
        base.OnTriggerEnter2D(param);
        CallPyMethod("OnTriggerEnter2D", new object[] { param });
    }
    
    public override void OnTriggerExit(Collider param)
    {
        base.OnTriggerExit(param);
        CallPyMethod("OnTriggerExit", new object[] { param });
    }
    
    public override void OnTriggerExit2D(Collider2D param)
    {
        base.OnTriggerExit2D(param);
        CallPyMethod("OnTriggerExit2D", new object[] { param });
    }
    
    public override void OnTriggerStay(Collider param)
    {
        base.OnTriggerStay(param);
        CallPyMethod("OnTriggerStay", new object[] { param });
    }
    
    public override void OnTriggerStay2D(Collider2D param)
    {
        base.OnTriggerStay2D(param);
        CallPyMethod("OnTriggerStay2D", new object[] { param });
    }
    
    public override void OnValidate()
    {
        base.OnValidate();
        CallPyMethod("OnValidate");
    }
    
    public override void OnWillRenderObject()
    {
        base.OnWillRenderObject();
        CallPyMethod("OnWillRenderObject");
    }
    
    public override void Reset()
    {
        base.Reset();
        CallPyMethod("Reset");
    }
    
    public override void Start()
    {
        base.Start();
        CallPyMethod("Start");
    }
    
    public override void Update()
    {
        base.Update();
        CallPyMethod("Update");
    }


    private void CallPyMethod(string method, object[] args = null)
    {
        if(args == null)
        {
            python.InvokeMethod(pyInstance, method, new object[0]);
        } else
        {
            python.InvokeMethod(pyInstance, method, args);
        }
        string output = python.GetOutput();
        if (output != "")
        {
            Debug.Log(output);    
        }
    }

    public int keyValuesLength
    {
        get
        {
            return keyValues.Length;
        }
        set
        {
            Array.Resize<ConfigurableValue>(ref keyValues, value);
        }
    }
}
[Serializable]
public class ConfigurableValue 
{
    public enum ConfigurableValueType { Int, Float, Vector3, Object, Color };
    public string name;
    public ConfigurableValueType type;
    public int valueInt;
    public float valueFloat;
    public Vector3 valueVector3;
    public UnityEngine.Object valueObject;
    public Color valueColor;
    public object getValue()
    {
        if(type == ConfigurableValueType.Int)
        {
            return valueInt;
        } else if(type == ConfigurableValueType.Float)
        {
            return valueFloat;
        } else if(type == ConfigurableValueType.Vector3)
        {
            return valueVector3;
        } else if(type == ConfigurableValueType.Object)
        {
            return valueObject;
        } else if(type == ConfigurableValueType.Color)
        {
            return valueColor;
        } else
        {
            return null;
        }
    }
}
