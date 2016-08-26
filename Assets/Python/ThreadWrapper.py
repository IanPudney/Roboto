from UnityEngine import *
from PyBehaviour import PyBehaviour
class ThreadWrapper(Object):
	def __init__(self, wrapped_object):
		super(ThreadWrapper, self).__setattr__("wrapped_object", wrapped_object)
		#self.wrapped_object = wrapped_object
	def __getattr__(self, name):
		return getattr(self.wrapped_object, name)
	def __setattr__(self, name, value):
		return setattr(self.wrapped_object, name, value)