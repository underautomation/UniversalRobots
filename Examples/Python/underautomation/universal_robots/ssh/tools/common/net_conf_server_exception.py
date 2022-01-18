import typing
from underautomation.universal_robots.ssh.tools.common.ssh_exception import SshException
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.Ssh.Tools.Common import NetConfServerException as net_conf_server_exception

class NetConfServerException(SshException):
	def __init__(self, message: str, innerException: typing.Any, _internal = 0):
		if(_internal == 0):
			self._instance = net_conf_server_exception(message, innerException)
		else:
			self._instance = _internal