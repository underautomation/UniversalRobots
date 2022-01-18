import typing
from underautomation.universal_robots.ssh.tools.messages.message import Message
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.Ssh.Tools.Messages.Transport import DebugMessage as debug_message

class DebugMessage(Message):
	def __init__(self, _internal = 0):
		if(_internal == 0):
			self._instance = debug_message()
		else:
			self._instance = _internal
	@property
	def is_always_display(self) -> bool:
		return self._instance.IsAlwaysDisplay
	@property
	def message(self) -> str:
		return self._instance.Message
	@property
	def language(self) -> str:
		return self._instance.Language