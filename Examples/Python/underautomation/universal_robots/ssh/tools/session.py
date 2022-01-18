import typing
from underautomation.universal_robots.ssh.tools.common.semaphore_light import SemaphoreLight
from underautomation.universal_robots.ssh.tools.messages.message import Message
from underautomation.universal_robots.ssh.tools.connection_info import ConnectionInfo
import clr
import os
clr.AddReference(os.path.realpath(os.path.join(os.path.dirname(__file__), "..", "..", "..", "..", 'lib', 'UnderAutomation.UniversalRobots.dll')))
from UnderAutomation.UniversalRobots.Ssh.Tools import Session as session

class Session:
	def __init__(self, _internal = 0):
		if(_internal == 0):
			self._instance = session()
		else:
			self._instance = _internal
	def add__error_occured(self, value: typing.Any) -> None:
		self._instance.add_ErrorOccured(value)
	def remove__error_occured(self, value: typing.Any) -> None:
		self._instance.remove_ErrorOccured(value)
	def add__disconnected(self, value: typing.Any) -> None:
		self._instance.add_Disconnected(value)
	def remove__disconnected(self, value: typing.Any) -> None:
		self._instance.remove_Disconnected(value)
	def add__host_key_received(self, value: typing.Any) -> None:
		self._instance.add_HostKeyReceived(value)
	def remove__host_key_received(self, value: typing.Any) -> None:
		self._instance.remove_HostKeyReceived(value)
	def add__user_authentication_banner_received(self, value: typing.Any) -> None:
		self._instance.add_UserAuthenticationBannerReceived(value)
	def remove__user_authentication_banner_received(self, value: typing.Any) -> None:
		self._instance.remove_UserAuthenticationBannerReceived(value)
	def add__request_success_received(self, value: typing.Any) -> None:
		self._instance.add_RequestSuccessReceived(value)
	def remove__request_success_received(self, value: typing.Any) -> None:
		self._instance.remove_RequestSuccessReceived(value)
	def add__request_failure_received(self, value: typing.Any) -> None:
		self._instance.add_RequestFailureReceived(value)
	def remove__request_failure_received(self, value: typing.Any) -> None:
		self._instance.remove_RequestFailureReceived(value)
	def add__channel_open_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelOpenReceived(value)
	def remove__channel_open_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelOpenReceived(value)
	def add__channel_open_confirmation_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelOpenConfirmationReceived(value)
	def remove__channel_open_confirmation_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelOpenConfirmationReceived(value)
	def add__channel_open_failure_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelOpenFailureReceived(value)
	def remove__channel_open_failure_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelOpenFailureReceived(value)
	def add__channel_window_adjust_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelWindowAdjustReceived(value)
	def remove__channel_window_adjust_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelWindowAdjustReceived(value)
	def add__channel_data_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelDataReceived(value)
	def remove__channel_data_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelDataReceived(value)
	def add__channel_extended_data_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelExtendedDataReceived(value)
	def remove__channel_extended_data_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelExtendedDataReceived(value)
	def add__channel_eof_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelEofReceived(value)
	def remove__channel_eof_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelEofReceived(value)
	def add__channel_close_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelCloseReceived(value)
	def remove__channel_close_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelCloseReceived(value)
	def add__channel_request_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelRequestReceived(value)
	def remove__channel_request_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelRequestReceived(value)
	def add__channel_success_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelSuccessReceived(value)
	def remove__channel_success_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelSuccessReceived(value)
	def add__channel_failure_received(self, value: typing.Any) -> None:
		self._instance.add_ChannelFailureReceived(value)
	def remove__channel_failure_received(self, value: typing.Any) -> None:
		self._instance.remove_ChannelFailureReceived(value)
	def connect(self) -> None:
		self._instance.Connect()
	def disconnect(self) -> None:
		self._instance.Disconnect()
	def register_message(self, messageName: str) -> None:
		self._instance.RegisterMessage(messageName)
	def un_register_message(self, messageName: str) -> None:
		self._instance.UnRegisterMessage(messageName)
	def dispose(self) -> None:
		self._instance.Dispose()
	@property
	def session_semaphore(self) -> SemaphoreLight:
		return SemaphoreLight(None, self._instance.SessionSemaphore)
	@property
	def is_connected(self) -> bool:
		return self._instance.IsConnected
	@property
	def session_id(self) -> int:
		return self._instance.SessionId
	@property
	def client_init_message(self) -> Message:
		return Message(self._instance.ClientInitMessage)
	@property
	def server_version(self) -> str:
		return self._instance.ServerVersion
	@property
	def client_version(self) -> str:
		return self._instance.ClientVersion
	@property
	def connection_info(self) -> ConnectionInfo:
		return ConnectionInfo(None, None, None, None, None, None, None, None, None, self._instance.ConnectionInfo)
