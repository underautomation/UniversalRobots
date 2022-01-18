import typing
from underautomation.universal_robots.xml_rpc.xml_rpc_type import XmlRpcType
from underautomation.universal_robots.xml_rpc.xml_rpc_value import XmlRpcValue
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.XmlRpc import XmlRpcBooleanValue as xml_rpc_boolean_value

class XmlRpcBooleanValue(XmlRpcValue):
	def __init__(self, value: bool, _internal = 0):
		if(_internal == 0):
			self._instance = xml_rpc_boolean_value(value)
		else:
			self._instance = _internal
	def __repr__(self):
		return self._instance.ToString()
	@property
	def type(self) -> XmlRpcType:
		return XmlRpcType(self._instance.Type)
