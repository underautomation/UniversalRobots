import typing
from underautomation.universal_robots.ssh.tools.messages.message import Message
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.Ssh.Tools.Messages.Connection import RequestFailureMessage as request_failure_message

class RequestFailureMessage(Message):
	def __init__(self, _internal = 0):
		if(_internal == 0):
			self._instance = request_failure_message()
		else:
			self._instance = _internal