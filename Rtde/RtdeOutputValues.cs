//              WARNING
// This file is an empty shell containing only public C# items.
// The internal code is hidden; to access it, you need to obtain a Source licence of the library.

using Common;

namespace Rtde {

	public class RtdeOutputValues : RtdeBaseValues<RtdeOutputData> {


		protected override RtdeValue[] InternalValues { get; }


		protected override RtdeValue InternaleGetValue(RtdeOutputData data)
		{
			// Source is hidden, a Source licence is needed to access internal code...
			return default;
		}


		public object GetValue(RtdeOutputSetupItem item)
		{
			// Source is hidden, a Source licence is needed to access internal code...
			return default;
		}

		/// <summary>
		/// Time elapsed since the controller was started [s]
		/// </summary>
		public double Timestamp { get; set; }

		/// <summary>
		/// Target joint positions
		/// </summary>
		public JointsDoubleValues TargetQ { get; set; }

		/// <summary>
		/// Target joint velocities
		/// </summary>
		public JointsDoubleValues TargetQd { get; set; }

		/// <summary>
		/// Target joint accelerations
		/// </summary>
		public JointsDoubleValues TargetQdd { get; set; }

		/// <summary>
		/// Target joint currents
		/// </summary>
		public JointsDoubleValues TargetCurrent { get; set; }

		/// <summary>
		/// Target joint moments (torques)
		/// </summary>
		public JointsDoubleValues TargetMoment { get; set; }

		/// <summary>
		/// Actual joint positions
		/// </summary>
		public JointsDoubleValues ActualQ { get; set; }

		/// <summary>
		/// Actual joint velocities
		/// </summary>
		public JointsDoubleValues ActualQd { get; set; }

		/// <summary>
		/// Actual joint currents
		/// </summary>
		public JointsDoubleValues ActualCurrent { get; set; }

		/// <summary>
		/// Joint control currents
		/// </summary>
		public JointsDoubleValues JointControlOutput { get; set; }

		/// <summary>
		/// Actual Cartesian coordinates of the tool: (x,y,z,rx,ry,rz), where rx, ry and rz is a rotation vector representation of the tool orientation
		/// </summary>
		public Pose ActualTcpPose { get; set; }

		/// <summary>
		/// Actual speed of the tool given in Cartesian coordinates. The speed is given in [m/s] and the rotational part of the TCP speed (rx, ry, rz) is the angular velocity given in [rad/s]
		/// </summary>
		public Pose ActualTcpSpeed { get; set; }

		/// <summary>
		/// Generalized forces in the TCP. It compensates the measurement for forces and torques generated by the�payload
		/// </summary>
		public CartesianCoordinates ActualTcpForce { get; set; }

		/// <summary>
		/// Target Cartesian coordinates of the tool: (x,y,z,rx,ry,rz), where rx, ry and rz is a rotation vector representation of the tool orientation
		/// </summary>
		public Pose TargetTcpPose { get; set; }

		/// <summary>
		/// Target speed of the tool given in Cartesian coordinates.�The speed is given in [m/s] and the rotational part of the TCP speed (rx, ry, rz) is the angular velocity given in [rad/s]
		/// </summary>
		public Pose TargetTcpSpeed { get; set; }

		/// <summary>
		/// Current state of the digital inputs.�0-7: Standard, 8-15: Configurable, 16-17: Tool
		/// </summary>
		public ulong ActualDigitalInputBits { get; set; }

		/// <summary>
		/// Temperature of each joint in degrees Celsius
		/// </summary>
		public JointsDoubleValues JointTemperatures { get; set; }

		/// <summary>
		/// Controller real-time thread execution time
		/// </summary>
		public double ActualExecutionTime { get; set; }

		/// <summary>
		/// Robot mode
		/// </summary>
		public int RobotMode { get; set; }

		/// <summary>
		/// Joint control modes
		/// </summary>
		public JointsIntValues JointMode { get; set; }

		/// <summary>
		/// Safety mode
		/// </summary>
		public int SafetyMode { get; set; }

		/// <summary>
		/// Safety status
		/// </summary>
		public int SafetyStatus { get; set; }

		/// <summary>
		/// Tool x, y and z accelerometer values
		/// </summary>
		public Vector3D ActualToolAccelerometer { get; set; }

		/// <summary>
		/// Speed scaling of the trajectory limiter
		/// </summary>
		public double SpeedScaling { get; set; }

		/// <summary>
		/// Target speed fraction
		/// </summary>
		public double TargetSpeedFraction { get; set; }

		/// <summary>
		/// Norm of Cartesian linear momentum
		/// </summary>
		public double ActualMomentum { get; set; }

		/// <summary>
		/// Safety Control Board: Main voltage
		/// </summary>
		public double ActualMainVoltage { get; set; }

		/// <summary>
		/// Safety Control Board: Robot voltage (48V)
		/// </summary>
		public double ActualRobotVoltage { get; set; }

		/// <summary>
		/// Safety Control Board: Robot current
		/// </summary>
		public double ActualRobotCurrent { get; set; }

		/// <summary>
		/// Actual joint voltages
		/// </summary>
		public JointsDoubleValues ActualJointVoltage { get; set; }

		/// <summary>
		/// Current state of the digital outputs.�0-7: Standard, 8-15: Configurable, 16-17: Tool
		/// </summary>
		public ulong ActualDigitalOutputBits { get; set; }

		/// <summary>
		/// Program state
		/// </summary>
		public uint RuntimeState { get; set; }

		/// <summary>
		/// Position of robot elbow in Cartesian Base Coordinates
		/// </summary>
		public Vector3D ElbowPosition { get; set; }

		/// <summary>
		/// Velocity of robot elbow in Cartesian Base Coordinates
		/// </summary>
		public Vector3D ElbowVelocity { get; set; }

		/// <summary>
		/// Bits 0-3:� Is power on | Is program running | Is teach button pressed | Is power button pressed
		/// </summary>
		public uint RobotStatusBits { get; set; }

		/// <summary>
		/// Bits 0-10: Is normal mode | Is reduced mode | Is protective stopped | Is recovery mode |�Is safeguard stopped |�Is system emergency stopped |�Is robot emergency stopped |�Is emergency stopped |�Is violation |�Is fault |�Is stopped due to safety
		/// </summary>
		public uint SafetyStatusBits { get; set; }

		/// <summary>
		/// Bits 0-3: analog input 0 | analog input 1 | analog output 0 |�analog output 1, {0=current[mA], 1=voltage[V]}
		/// </summary>
		public uint AnalogIOTypes { get; set; }

		/// <summary>
		/// Standard analog input 0 [mA or V]
		/// </summary>
		public double StandardAnalogInput0 { get; set; }

		/// <summary>
		/// Standard analog input 1 [mA or V]
		/// </summary>
		public double StandardAnalogInput1 { get; set; }

		/// <summary>
		/// Standard analog output 0 [mA or V]
		/// </summary>
		public double StandardAnalogOutput0 { get; set; }

		/// <summary>
		/// Standard analog output 1 [mA or V]
		/// </summary>
		public double StandardAnalogOutput1 { get; set; }

		/// <summary>
		/// I/O current [mA]
		/// </summary>
		public double IOCurrent { get; set; }

		/// <summary>
		/// Euromap67 input bits
		/// </summary>
		public uint Euromap67InputBits { get; set; }

		/// <summary>
		/// Euromap67 output bits
		/// </summary>
		public uint Euromap67OutputBits { get; set; }

		/// <summary>
		/// Euromap 24V voltage [V]
		/// </summary>
		public double Euromap67_24VVoltage { get; set; }

		/// <summary>
		/// Euromap 24V current [mA]
		/// </summary>
		public double Euromap67_24VCurrent { get; set; }

		/// <summary>
		/// Tool mode
		/// </summary>
		public uint ToolMode { get; set; }

		/// <summary>
		/// Output domain {0=current[mA], 1=voltage[V]} Bits 0-1: tool_analog_input_0 | tool_analog_input_1
		/// </summary>
		public uint ToolAnalogInputTypes { get; set; }

		/// <summary>
		/// Tool analog input 0 [mA or V]
		/// </summary>
		public double ToolAnalogInput0 { get; set; }

		/// <summary>
		/// Tool analog input 1 [mA or V]
		/// </summary>
		public double ToolAnalogInput1 { get; set; }

		/// <summary>
		/// Tool output voltage [V]
		/// </summary>
		public int ToolOutputVoltage { get; set; }

		/// <summary>
		/// Tool current [mA]
		/// </summary>
		public double ToolOutputCurrent { get; set; }

		/// <summary>
		/// Tool temperature in degrees Celsius
		/// </summary>
		public double ToolTemperature { get; set; }

		/// <summary>
		/// TCP force scalar [N]
		/// </summary>
		public double TcpForceScalar { get; set; }

		/// <summary>
		/// General purpose bits
		/// </summary>
		public uint OutputBitRegisters0To31 { get; set; }

		/// <summary>
		/// General purpose bits
		/// </summary>
		public uint OutputBitRegisters32To63 { get; set; }

		/// <summary>
		/// 64 general purpose bits. X: [64..127] - The upper range of the boolean output registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		public RtdeBitRegistersValue OutputBitRegisters { get; }

		/// <summary>
		/// 48 general purpose integer registers. X: [0..23] - The lower range of the integer output registers is reserved for FieldBus/PLC interface usage. X: [24..47] - The upper range of the integer output registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		public RtdeIntRegistersValue OutputIntRegisters { get; }

		/// <summary>
		/// 48 general purpose double registers. X: [0..23] - The lower range of the double output registers is reserved for FieldBus/PLC interface usage. X: [24..47] - The upper range of the double output registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		public RtdeDoubleRegistersValue OutputDoubleRegisters { get; }

		/// <summary>
		/// General purpose bits (input read back). This range of the boolean output registers is reserved for FieldBus/PLC interface usage.
		/// </summary>
		public uint InputBitRegisters0To31 { get; set; }

		/// <summary>
		/// General purpose bits (input read back), This range of the boolean output registers is reserved for FieldBus/PLC interface usage.
		/// </summary>
		public uint InputBitRegisters32To63 { get; set; }

		/// <summary>
		/// �64 general purpose bits, X: [64..127] - The upper range of the boolean output registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		public RtdeBitRegistersValue InputBitRegisters { get; }

		/// <summary>
		/// 48 general purpose integer registers. X: [0..23] - The lower range of the integer input registers is reserved for FieldBus/PLC interface usage. X: [24..47] - The upper range of the integer input registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		public RtdeIntRegistersValue InputIntRegisters { get; }

		/// <summary>
		/// �48 general purpose double registers. X: [0..23] - The lower range of the double input registers is reserved for FieldBus/PLC interface usage. X: [24..47] - The upper range of the double input registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		public RtdeDoubleRegistersValue InputDoubleRegisters { get; }

		/// <summary>
		/// The current output mode
		/// </summary>
		public byte ToolOutputMode { get; set; }

		/// <summary>
		/// The current mode of digital output 0
		/// </summary>
		public byte ToolDigitalOutput0mode { get; set; }

		/// <summary>
		/// The current mode of digital output 1
		/// </summary>
		public byte ToolDigitalOutput1Mode { get; set; }

		/// <summary>
		/// Payload mass Kg
		/// </summary>
		public double Payload { get; set; }

		/// <summary>
		/// Payload Center of Gravity (CoGx, CoGy, CoGz) m
		/// </summary>
		public Vector3D PayloadCOG { get; set; }

		/// <summary>
		/// Payload inertia matrix elements (Ixx,Iyy,Izz,Ixy,Ixz,Iyz] expressed in kg*m^2
		/// </summary>
		public CartesianCoordinates PayloadInertia { get; set; }

		/// <summary>
		/// Script line number that is actually in control of the robot given the robot is locked by one of the threads in the script. If no thread is locking the robot this field is set to '0'. Script line number should not be confused with program tree line number displayed on polyscope.
		/// </summary>
		public uint ScriptControlLine { get; set; }

		/// <summary>
		/// Raw force and torque measurement, not compensated for forces and torques caused by the�payload
		/// </summary>
		public CartesianCoordinates FTRawWrench { get; set; }
	}
}
