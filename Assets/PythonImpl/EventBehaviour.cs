using UnityEngine;
using System.Collections;

public class EventBehaviour : MonoBehaviour {
    public delegate void VoidDelegate();
    public delegate void IntDelegate(int param);
    public delegate void AFloatIntDelegate(float[] arr, int param);
    public delegate void CollisionDelegate(Collision param);
    public delegate void Collision2DDelegate(Collision2D param);
    public delegate void ControllerColliderHitDelegate(ControllerColliderHit param);
    public delegate void NetworkDisconnectionDelegate(NetworkDisconnection param);
    public delegate void NetworkConnectionErrorDelegate(NetworkConnectionError param);
    public delegate void FloatDelegate(float param);
    public delegate void Joint2DDelegate(Joint2D param);
    public delegate void MasterServerEventDelegate(MasterServerEvent param);
    public delegate void NetworkMessageInfoDelegate(NetworkMessageInfo param);
    public delegate void GameObjectDelegate(GameObject param);
    public delegate void NetworkPlayerDelegate(NetworkPlayer param);
    public delegate void RenderTexturesDelegate(RenderTexture left, RenderTexture right);
    public delegate void BitStreamNetworkMessageInfoDelegate(BitStream stream, NetworkMessageInfo info);
    public delegate void ColliderDelegate(Collider param);
    public delegate void Collider2DDelegate(Collider2D param);


    public event VoidDelegate AwakeEvent;
    public virtual void Awake()
    {
        if (AwakeEvent != null) AwakeEvent();
    }
    public event VoidDelegate FixedUpdateEvent;
    public virtual void FixedUpdate()
    {
        if (FixedUpdateEvent != null) FixedUpdateEvent();
    }
    public event VoidDelegate LateUpdateEvent;
    public virtual void LateUpdate()
    {
        if (LateUpdateEvent != null) LateUpdateEvent();
    }
    public event IntDelegate OnAnimatorIKEvent;
    public virtual void OnAnimatorIK(int layerIndex)
    {
        if (OnAnimatorIKEvent != null) OnAnimatorIKEvent(layerIndex);
    }
    public event VoidDelegate OnAnimatorMoveEvent;
    public virtual void OnAnimatorMove()
    {
        if (OnAnimatorMoveEvent != null) OnAnimatorMoveEvent();
    }
    public event VoidDelegate OnApplicationFocusEvent;
    public virtual void OnApplicationFocus()
    {
        if (OnApplicationFocusEvent != null) OnApplicationFocusEvent();
    }
    public event VoidDelegate OnApplicationPauseEvent;
    public virtual void OnApplicationPause()
    {
        if (OnApplicationPauseEvent != null) OnApplicationPauseEvent();
    }
    public event VoidDelegate OnApplicationQuitEvent;
    public virtual void OnApplicationQuit()
    {
        if (OnApplicationQuitEvent != null) OnApplicationQuitEvent();
    }
    public event AFloatIntDelegate OnAudioFilterReadEvent;
    public virtual void OnAudioFilterRead(float[] data, int channels)
    {
        if (OnAudioFilterReadEvent != null) OnAudioFilterReadEvent(data, channels);
    }
    public event VoidDelegate OnBecameInvisibleEvent;
    public virtual void OnBecameInvisible()
    {
        if (OnBecameInvisibleEvent != null) OnBecameInvisibleEvent();
    }
    public event VoidDelegate OnBecameVisibleEvent;
    public virtual void OnBecameVisible()
    {
        if (OnBecameVisibleEvent != null) OnBecameVisibleEvent();
    }
    public event CollisionDelegate OnCollisionEnterEvent;
    public virtual void OnCollisionEnter(Collision col)
    {
        if (OnCollisionEnterEvent != null) OnCollisionEnterEvent(col);
    }
    public event Collision2DDelegate OnCollisionEnter2DEvent;
    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (OnCollisionEnter2DEvent != null) OnCollisionEnter2DEvent(col);
    }
    public event CollisionDelegate OnCollisionExitEvent;
    public virtual void OnCollisionExit(Collision col)
    {
        if (OnCollisionExitEvent != null) OnCollisionExitEvent(col);
    }
    public event Collision2DDelegate OnCollisionExit2DEvent;
    public virtual void OnCollisionExit2D(Collision2D col)
    {
        if (OnCollisionExit2DEvent != null) OnCollisionExit2DEvent(col);
    }
    public event CollisionDelegate OnCollisionStayEvent;
    public virtual void OnCollisionStay(Collision col)
    {
        if (OnCollisionStayEvent != null) OnCollisionStayEvent(col);
    }
    public event Collision2DDelegate OnCollisionStay2DEvent;
    public virtual void OnCollisionStay2D(Collision2D col)
    {
        if (OnCollisionStay2DEvent != null) OnCollisionStay2DEvent(col);
    }
    public event VoidDelegate OnConnectedToServerEvent;
    public virtual void OnConnectedToServer()
    {
        if (OnConnectedToServerEvent != null) OnConnectedToServerEvent();
    }
    public event ControllerColliderHitDelegate OnControllerColliderHitEvent;
    public virtual void OnControllerColliderHit(ControllerColliderHit col)
    {
        if (OnControllerColliderHitEvent != null) OnControllerColliderHitEvent(col);
    }
    public event VoidDelegate OnDestroyEvent;
    public virtual void OnDestroy()
    {
        if (OnDestroyEvent != null) OnDestroyEvent();
    }
    public event VoidDelegate OnDisableEvent;
    public virtual void OnDisable()
    {
        if (OnDisableEvent != null) OnDisableEvent();
    }
    public event NetworkDisconnectionDelegate OnDisconnectedFromServerEvent;
    public virtual void OnDisconnectedFromServer(NetworkDisconnection col)
    {
        if (OnDisconnectedFromServerEvent != null) OnDisconnectedFromServerEvent(col);
    }
    public event VoidDelegate OnDrawGizmosEvent;
    public virtual void OnDrawGizmos()
    {
        if (OnDrawGizmosEvent != null) OnDrawGizmosEvent();
    }
    public event VoidDelegate OnDrawGizmosSelectedEvent;
    public virtual void OnDrawGizmosSelected()
    {
        if (OnDrawGizmosSelectedEvent != null) OnDrawGizmosSelectedEvent();
    }
    public event VoidDelegate OnEnableEvent;
    public virtual void OnEnable()
    {
        if (OnEnableEvent != null) OnEnableEvent();
    }
    public event NetworkConnectionErrorDelegate OnFailedToConnectEvent;
    public virtual void OnFailedToConnect(NetworkConnectionError col)
    {
        if (OnFailedToConnectEvent != null) OnFailedToConnectEvent(col);
    }
    public event NetworkConnectionErrorDelegate OnFailedToConnectToMasterServerEvent;
    public virtual void OnFailedToConnectToMasterServer(NetworkConnectionError col)
    {
        if (OnFailedToConnectToMasterServerEvent != null) OnFailedToConnectToMasterServerEvent(col);
    }
    public event VoidDelegate OnGUIEvent;
    public virtual void OnGUI()
    {
        if (OnGUIEvent != null) OnGUIEvent();
    }
    public event FloatDelegate OnJointBreakEvent;
    public virtual void OnJointBreak(float param)
    {
        if (OnJointBreakEvent != null) OnJointBreakEvent(param);
    }
    public event Joint2DDelegate OnJointBreak2DEvent;
    public virtual void OnJointBreak2D(Joint2D joint)
    {
        if (OnJointBreak2DEvent != null) OnJointBreak2DEvent(joint);
    }
    public event IntDelegate OnLevelWasLoadedEvent;
    public virtual void OnLevelWasLoaded(int param)
    {
        if (OnLevelWasLoadedEvent  != null) OnLevelWasLoadedEvent(param);
    }
    public event MasterServerEventDelegate OnMasterServerEventDelegate;
    public virtual void OnMasterServerEvent(MasterServerEvent param)
    {
        if (OnMasterServerEventDelegate != null) OnMasterServerEventDelegate(param);
    }
    public event VoidDelegate OnMouseDownEvent;
    public virtual void OnMouseDown()
    {
        if (OnMouseDownEvent != null) OnMouseDownEvent();
    }
    public event VoidDelegate OnMouseDragEvent;
    public virtual void OnMouseDrag()
    {
        if (OnMouseDragEvent != null) OnMouseDragEvent();
    }
    public event VoidDelegate OnMouseEnterEvent;
    public virtual void OnMouseEnter()
    {
        if (OnMouseEnterEvent != null) OnMouseEnterEvent();
    }
    public event VoidDelegate OnMouseExitEvent;
    public virtual void OnMouseExit()
    {
        if (OnMouseExitEvent != null) OnMouseExitEvent();
    }
    public event VoidDelegate OnMouseOverEvent;
    public virtual void OnMouseOver()
    {
        if (OnMouseOverEvent != null) OnMouseOverEvent();
    }
    public event VoidDelegate OnMouseUpEvent;
    public virtual void OnMouseUp()
    {
        if (OnMouseUpEvent != null) OnMouseUpEvent();
    }
    public event VoidDelegate OnMouseUpAsButtonEvent;
    public virtual void OnMouseUpAsButton()
    {
        if (OnMouseUpAsButtonEvent != null) OnMouseUpAsButtonEvent();
    }
    public event NetworkMessageInfoDelegate OnNetworkInstantiateEvent;
    public virtual void OnNetworkInstantiate(NetworkMessageInfo param)
    {
        if (OnNetworkInstantiateEvent != null) OnNetworkInstantiateEvent(param);
    }
    public event GameObjectDelegate OnParticleCollisionEvent;
    public virtual void OnParticleCollision(GameObject param)
    {
        if (OnParticleCollisionEvent != null) OnParticleCollisionEvent(param);
    }
    public event NetworkPlayerDelegate OnPlayerConnectedEvent;
    public virtual void OnPlayerConnected(NetworkPlayer param)
    {
        if (OnPlayerConnectedEvent != null) OnPlayerConnectedEvent(param);
    }
    public event NetworkPlayerDelegate OnPlayerDisconnectedEvent;
    public virtual void OnPlayerDisconnected(NetworkPlayer param)
    {
        if (OnPlayerDisconnectedEvent != null) OnPlayerDisconnectedEvent(param);
    }
    public event VoidDelegate OnPostRenderEvent;
    public virtual void OnPostRender()
    {
        if (OnPostRenderEvent != null) OnPostRenderEvent();
    }
    public event VoidDelegate OnPreCullEvent;
    public virtual void OnPreCull()
    {
        if (OnPreCullEvent != null) OnPreCullEvent();
    }
    public event VoidDelegate OnPreRenderEvent;
    public virtual void OnPreRender()
    {
        if (OnPreRenderEvent != null) OnPreRenderEvent();
    }
    public event RenderTexturesDelegate OnRenderImageEvent;
    public virtual void OnRenderImage(RenderTexture left, RenderTexture right)
    {
        if (OnRenderImageEvent != null) OnRenderImageEvent(left, right);
    }
    public event VoidDelegate OnRenderObjectEvent;
    public virtual void OnRenderObject()
    {
        if (OnRenderObjectEvent != null) OnRenderObjectEvent();
    }
    public event BitStreamNetworkMessageInfoDelegate OnSerializeNetworkViewEvent;
    public virtual void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        if (OnSerializeNetworkViewEvent != null) OnSerializeNetworkViewEvent(stream, info);
    }
    public event VoidDelegate OnServerInitializedEvent;
    public virtual void OnServerInitialized()
    {
        if (OnServerInitializedEvent != null) OnServerInitializedEvent();
    }
    public event VoidDelegate OnTransformChildrenChangedEvent;
    public virtual void OnTransformChildrenChanged()
    {
        if (OnTransformChildrenChangedEvent != null) OnTransformChildrenChangedEvent();
    }
    public event VoidDelegate OnTransformParentChangedEvent;
    public virtual void OnTransformParentChanged()
    {
        if (OnTransformParentChangedEvent != null) OnTransformParentChangedEvent();
    }
    public event ColliderDelegate OnTriggerEnterEvent;
    public virtual void OnTriggerEnter(Collider param)
    {
        if (OnTriggerEnterEvent != null) OnTriggerEnterEvent(param);
    }
    public event Collider2DDelegate OnTriggerEnter2DEvent;
    public virtual void OnTriggerEnter2D(Collider2D param)
    {
        if (OnTriggerEnter2DEvent != null) OnTriggerEnter2DEvent(param);
    }
    public event ColliderDelegate OnTriggerExitEvent;
    public virtual void OnTriggerExit(Collider param)
    {
        if (OnTriggerExitEvent != null) OnTriggerExitEvent(param);
    }
    public event Collider2DDelegate OnTriggerExit2DEvent;
    public virtual void OnTriggerExit2D(Collider2D param)
    {
        if (OnTriggerExit2DEvent != null) OnTriggerExit2DEvent(param);
    }
    public event ColliderDelegate OnTriggerStayEvent;
    public virtual void OnTriggerStay(Collider param)
    {
        if (OnTriggerStayEvent != null) OnTriggerStayEvent(param);
    }
    public event Collider2DDelegate OnTriggerStay2DEvent;
    public virtual void OnTriggerStay2D(Collider2D param)
    {
        if (OnTriggerStay2DEvent != null) OnTriggerStay2DEvent(param);
    }
    public event VoidDelegate OnValidateEvent;
    public virtual void OnValidate()
    {
        if (OnValidateEvent != null) OnValidateEvent();
    }
    public event VoidDelegate OnWillRenderObjectEvent;
    public virtual void OnWillRenderObject()
    {
        if (OnWillRenderObjectEvent != null) OnWillRenderObjectEvent();
    }
    public event VoidDelegate ResetEvent;
    public virtual void Reset()
    {
        if (ResetEvent != null) ResetEvent();
    }
    public event VoidDelegate StartEvent;
    public virtual void Start()
    {
        if (StartEvent != null) StartEvent();
    }
    public event VoidDelegate UpdateEvent;
    public virtual void Update()
    {
        if (UpdateEvent != null) UpdateEvent();
    }
}
