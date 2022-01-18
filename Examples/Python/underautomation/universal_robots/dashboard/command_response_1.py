import typing
from underautomation.universal_robots.dashboard.command_response import CommandResponse
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.Dashboard import CommandResponse as command_response_1

class CommandResponse1(CommandResponse):
	def __init__(self, command: CommandResponse, _internal = 0):
		if(_internal == 0):
			self._instance = command_response_1(command)
		else:
			self._instance = _internal
	def __repr__(self):
		return self._instance.ToString()
