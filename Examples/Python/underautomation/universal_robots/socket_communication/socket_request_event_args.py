import typing
from underautomation.universal_robots.socket_communication.socket_client import SocketClient
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.SocketCommunication import SocketRequestEventArgs as socket_request_event_args

class SocketRequestEventArgs:
	def __init__(self, _internal = 0):
		if(_internal == 0):
			self._instance = socket_request_event_args()
		else:
			self._instance = _internal
