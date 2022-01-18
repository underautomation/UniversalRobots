import typing
from underautomation.universal_robots.ssh.tools.security.cryptography.symmetric_cipher import SymmetricCipher
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.Ssh.Tools.Security.Cryptography import StreamCipher as stream_cipher

class StreamCipher(SymmetricCipher):
	def __init__(self, _internal = 0):
		if(_internal == 0):
			self._instance = stream_cipher()
		else:
			self._instance = _internal
