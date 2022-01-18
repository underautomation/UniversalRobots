import typing
from underautomation.universal_robots.socket_communication.socket_client import SocketClient
from underautomation.universal_robots.internal.urservice_base import URServiceBase
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.SocketCommunication.Internal import SocketCommunicationServerBase as socket_communication_server_base

class SocketCommunicationServerBase(URServiceBase):
	def __init__(self, _internal = 0):
		if(_internal == 0):
			self._instance = socket_communication_server_base()
		else:
			self._instance = _internal
	def start(self, port: int) -> None:
		self._instance.Start(port)
	def add__socket_client_connection(self, value: typing.Any) -> None:
		self._instance.add_SocketClientConnection(value)
	def remove__socket_client_connection(self, value: typing.Any) -> None:
		self._instance.remove_SocketClientConnection(value)
	def add__socket_get_var(self, value: typing.Any) -> None:
		self._instance.add_SocketGetVar(value)
	def remove__socket_get_var(self, value: typing.Any) -> None:
		self._instance.remove_SocketGetVar(value)
	def add__socket_request(self, value: typing.Any) -> None:
		self._instance.add_SocketRequest(value)
	def remove__socket_request(self, value: typing.Any) -> None:
		self._instance.remove_SocketRequest(value)
	def add__socket_client_disconnection(self, value: typing.Any) -> None:
		self._instance.add_SocketClientDisconnection(value)
	def remove__socket_client_disconnection(self, value: typing.Any) -> None:
		self._instance.remove_SocketClientDisconnection(value)
	def stop(self) -> None:
		self._instance.Stop()
	def socket_write(self, message: str) -> None:
		self._instance.SocketWrite(message)
	@property
	def connected_clients(self) -> SocketClient:
		return SocketClient(self._instance.ConnectedClients)
	@property
	def enabled(self) -> bool:
		return self._instance.Enabled
	@property
	def port(self) -> int:
		return self._instance.Port