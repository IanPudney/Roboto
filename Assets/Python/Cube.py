from UnityEngine import *
from PyBehaviour import PyBehaviour   
class Cube(PyBehaviour):
	def Start(self):
		super(Cube, self).Start()
		self.gameObject.GetComponent[Rigidbody]().AddTorque(Vector3(4, 4, 4));
		pass
	
	