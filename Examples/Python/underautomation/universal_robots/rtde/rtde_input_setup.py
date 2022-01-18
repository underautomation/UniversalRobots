import typing
from underautomation.universal_robots.rtde.internal.rtde_setup_2 import RtdeSetup2
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.Rtde import RtdeInputSetup as rtde_input_setup

class RtdeInputSetup(RtdeSetup2):
	def __init__(self, _internal = 0):
		if(_internal == 0):
			self._instance = rtde_input_setup()
		else:
			self._instance = _internal
