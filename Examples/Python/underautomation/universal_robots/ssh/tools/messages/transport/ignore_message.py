import typing
from underautomation.universal_robots.ssh.tools.messages.message import Message
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.Ssh.Tools.Messages.Transport import IgnoreMessage as ignore_message

class IgnoreMessage(Message):
	def __init__(self, data: int, _internal = 0):
		if(_internal == 0):
			self._instance = ignore_message(data)
		else:
			self._instance = _internal
	@property
	def data(self) -> int:
		return self._instance.Data
