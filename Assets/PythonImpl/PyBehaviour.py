from UnityEngine import *

class PyBehaviour(object):   
	def __init__(self, wrapped_object, key_value_pairs):
		self.wrapped_object = wrapped_object
		for key_value_pair in key_value_pairs:  
			setattr(self, key_value_pair.name, key_value_pair.getValue()) 

	def __getattr__(self, name):
		return getattr(self.wrapped_object, name)
		
	def Awake(self):
		pass
	
	def FixedUpdate(self):
		pass
	
	
	def LateUpdate(self):
		pass 
	
	
	def OnAnimatorIK(self, layerIndex):
		pass
	
	
	def OnAnimatorMove(self):
		pass
	
	
	def OnApplicationFocus(self):
		pass
	
	
	def OnApplicationPause(self):
		pass
	
	
	def OnApplicationQuit(self):
		pass
	
	
	def OnAudioFilterRead(self, data, channels):
		pass
	
	
	def OnBecameInvisible(self):
		pass
	
	
	def OnBecameVisible(self):
		pass
	
	
	def OnCollisionEnter(self, col):
		pass
	
	
	def OnCollisionEnter2D(self, col):
		
		pass
	
	
	def OnCollisionExit(self, col):
		pass
	
	
	def OnCollisionExit2D(self, col):
		
		pass
	
	
	def OnCollisionStay(self, col):
		pass
	
	
	def OnCollisionStay2D(self, col):
		
		pass
	
	
	def OnConnectedToServer(self):
		pass
	
	
	def OnControllerColliderHit(self, col):
		pass
	
	
	def OnDestroy(self):
		pass
		
	
	
	def OnDisable(self):
		pass
	
	
	def OnDisconnectedFromServer(self, col):
		pass
	
	
	def OnDrawGizmos(self):
		pass
	
	
	def OnDrawGizmosSelected(self):
		pass
	
	
	def OnEnable(self):
		pass
	
	
	def OnFailedToConnect(self, col):
		pass
	
	
	def OnFailedToConnectToMasterServer(self, col):
		pass
	
	
	def OnGUI(self):
		pass
	
	
	def OnJointBreak(self, param):
		pass
	
	
	def OnJointBreak2D(self, joint):
		
		pass
	
	
	def OnLevelWasLoaded(self, param):
		pass
	
	
	def OnMasterServerEvent(self, param):
		pass
	
	
	def OnMouseDown(self):
		pass
	
	
	def OnMouseDrag(self):
		pass
	
	
	def OnMouseEnter(self):
		pass
	
	
	def OnMouseExit(self):
		pass
	
	
	def OnMouseOver(self):
		pass
	
	
	def OnMouseUp(self):
		pass
	
	
	def OnMouseUpAsButton(self):
		pass
	
	
	def OnNetworkInstantiate(self, param):
		pass
	
	
	def OnParticleCollision(self, param):
		pass
	
	
	def OnPlayerConnected(self, param):
		pass
	
	
	def OnPlayerDisconnected(self, param):
		pass
	
	
	def OnPostRender(self):
		pass
	
	
	def OnPreCull(self):
		pass
	
	
	def OnPreRender(self):
		pass
	
	
	def OnRenderImage(self, left, right):
		pass
	
	
	def OnRenderObject(self):
		pass
	
	
	def OnSerializeNetworkView(self, stream, info):
		pass
	
	
	def OnServerInitialized(self):
		pass
	
	
	def OnTransformChildrenChanged(self):
		pass
	
	
	def OnTransformParentChanged(self):
		pass
	
	
	def OnTriggerEnter(self, param):
		pass
	
	
	def OnTriggerEnter2D(self, param):
		
		pass
	
	
	def OnTriggerExit(self, param):
		pass
	
	
	def OnTriggerExit2D(self, param):
		
		pass
	
	
	def OnTriggerStay(self, param):
		pass
	
	
	def OnTriggerStay2D(self, param): 
		pass
	
	
	def OnValidate(self):
		pass
	
	
	def OnWillRenderObject(self):
		pass
	
	
	def Reset(self):
		pass
	
	
	def Start(self):
		pass
	
	
	def Update(self):
		pass
	
