//              WARNING
// This file is an empty shell containing only public C# items.
// The internal code is hidden; to access it, you need to obtain a Source licence of the library.


namespace Rtde {

	public enum RtdeOutputData {

		/// <summary>
		/// Time elapsed since the controller was started [s]
		/// </summary>
		Timestamp = 0,

		/// <summary>
		/// Target joint positions
		/// </summary>
		TargetQ = 1,

		/// <summary>
		/// Target joint velocities
		/// </summary>
		TargetQd = 2,

		/// <summary>
		/// Target joint accelerations
		/// </summary>
		TargetQdd = 3,

		/// <summary>
		/// Target joint currents
		/// </summary>
		TargetCurrent = 4,

		/// <summary>
		/// Target joint moments (torques)
		/// </summary>
		TargetMoment = 5,

		/// <summary>
		/// Actual joint positions
		/// </summary>
		ActualQ = 6,

		/// <summary>
		/// Actual joint velocities
		/// </summary>
		ActualQd = 7,

		/// <summary>
		/// Actual joint currents
		/// </summary>
		ActualCurrent = 8,

		/// <summary>
		/// Joint control currents
		/// </summary>
		JointControlOutput = 9,

		/// <summary>
		/// Actual Cartesian coordinates of the tool: (x,y,z,rx,ry,rz), where rx, ry and rz is a rotation vector representation of the tool orientation
		/// </summary>
		ActualTcpPose = 10,

		/// <summary>
		/// Actual speed of the tool given in Cartesian coordinates. The speed is given in [m/s] and the rotational part of the TCP speed (rx, ry, rz) is the angular velocity given in [rad/s]
		/// </summary>
		ActualTcpSpeed = 11,

		/// <summary>
		/// Generalized forces in the TCP. It compensates the measurement for forces and torques generated by the�payload
		/// </summary>
		ActualTcpForce = 12,

		/// <summary>
		/// Target Cartesian coordinates of the tool: (x,y,z,rx,ry,rz), where rx, ry and rz is a rotation vector representation of the tool orientation
		/// </summary>
		TargetTcpPose = 13,

		/// <summary>
		/// Target speed of the tool given in Cartesian coordinates.�The speed is given in [m/s] and the rotational part of the TCP speed (rx, ry, rz) is the angular velocity given in [rad/s]
		/// </summary>
		TargetTcpSpeed = 14,

		/// <summary>
		/// Current state of the digital inputs.�0-7: Standard, 8-15: Configurable, 16-17: Tool
		/// </summary>
		ActualDigitalInputBits = 15,

		/// <summary>
		/// Temperature of each joint in degrees Celsius
		/// </summary>
		JointTemperatures = 16,

		/// <summary>
		/// Controller real-time thread execution time
		/// </summary>
		ActualExecutionTime = 17,

		/// <summary>
		/// Robot mode
		/// </summary>
		RobotMode = 18,

		/// <summary>
		/// Joint control modes
		/// </summary>
		JointMode = 19,

		/// <summary>
		/// Safety mode
		/// </summary>
		SafetyMode = 20,

		/// <summary>
		/// Safety status
		/// </summary>
		SafetyStatus = 21,

		/// <summary>
		/// Tool x, y and z accelerometer values
		/// </summary>
		ActualToolAccelerometer = 22,

		/// <summary>
		/// Speed scaling of the trajectory limiter
		/// </summary>
		SpeedScaling = 23,

		/// <summary>
		/// Target speed fraction
		/// </summary>
		TargetSpeedFraction = 24,

		/// <summary>
		/// Norm of Cartesian linear momentum
		/// </summary>
		ActualMomentum = 25,

		/// <summary>
		/// Safety Control Board: Main voltage
		/// </summary>
		ActualMainVoltage = 26,

		/// <summary>
		/// Safety Control Board: Robot voltage (48V)
		/// </summary>
		ActualRobotVoltage = 27,

		/// <summary>
		/// Safety Control Board: Robot current
		/// </summary>
		ActualRobotCurrent = 28,

		/// <summary>
		/// Actual joint voltages
		/// </summary>
		ActualJointVoltage = 29,

		/// <summary>
		/// Current state of the digital outputs.�0-7: Standard, 8-15: Configurable, 16-17: Tool
		/// </summary>
		ActualDigitalOutputBits = 30,

		/// <summary>
		/// Program state
		/// </summary>
		RuntimeState = 31,

		/// <summary>
		/// Position of robot elbow in Cartesian Base Coordinates
		/// </summary>
		ElbowPosition = 32,

		/// <summary>
		/// Velocity of robot elbow in Cartesian Base Coordinates
		/// </summary>
		ElbowVelocity = 33,

		/// <summary>
		/// Bits 0-3:� Is power on | Is program running | Is teach button pressed | Is power button pressed
		/// </summary>
		RobotStatusBits = 34,

		/// <summary>
		/// Bits 0-10: Is normal mode | Is reduced mode | Is protective stopped | Is recovery mode |�Is safeguard stopped |�Is system emergency stopped |�Is robot emergency stopped |�Is emergency stopped |�Is violation |�Is fault |�Is stopped due to safety
		/// </summary>
		SafetyStatusBits = 35,

		/// <summary>
		/// Bits 0-3: analog input 0 | analog input 1 | analog output 0 |�analog output 1, {0=current[mA], 1=voltage[V]}
		/// </summary>
		AnalogIOTypes = 36,

		/// <summary>
		/// Standard analog input 0 [mA or V]
		/// </summary>
		StandardAnalogInput0 = 37,

		/// <summary>
		/// Standard analog input 1 [mA or V]
		/// </summary>
		StandardAnalogInput1 = 38,

		/// <summary>
		/// Standard analog output 0 [mA or V]
		/// </summary>
		StandardAnalogOutput0 = 39,

		/// <summary>
		/// Standard analog output 1 [mA or V]
		/// </summary>
		StandardAnalogOutput1 = 40,

		/// <summary>
		/// I/O current [mA]
		/// </summary>
		IOCurrent = 41,

		/// <summary>
		/// Euromap67 input bits
		/// </summary>
		Euromap67InputBits = 42,

		/// <summary>
		/// Euromap67 output bits
		/// </summary>
		Euromap67OutputBits = 43,

		/// <summary>
		/// Euromap 24V voltage [V]
		/// </summary>
		Euromap67_24VVoltage = 44,

		/// <summary>
		/// Euromap 24V current [mA]
		/// </summary>
		Euromap67_24VCurrent = 45,

		/// <summary>
		/// Tool mode
		/// </summary>
		ToolMode = 46,

		/// <summary>
		/// Output domain {0=current[mA], 1=voltage[V]} Bits 0-1: tool_analog_input_0 | tool_analog_input_1
		/// </summary>
		ToolAnalogInputTypes = 47,

		/// <summary>
		/// Tool analog input 0 [mA or V]
		/// </summary>
		ToolAnalogInput0 = 48,

		/// <summary>
		/// Tool analog input 1 [mA or V]
		/// </summary>
		ToolAnalogInput1 = 49,

		/// <summary>
		/// Tool output voltage [V]
		/// </summary>
		ToolOutputVoltage = 50,

		/// <summary>
		/// Tool current [mA]
		/// </summary>
		ToolOutputCurrent = 51,

		/// <summary>
		/// Tool temperature in degrees Celsius
		/// </summary>
		ToolTemperature = 52,

		/// <summary>
		/// TCP force scalar [N]
		/// </summary>
		TcpForceScalar = 53,

		/// <summary>
		/// General purpose bits
		/// </summary>
		OutputBitRegisters0To31 = 54,

		/// <summary>
		/// General purpose bits
		/// </summary>
		OutputBitRegisters32To63 = 55,

		/// <summary>
		/// 64 general purpose bits. X: [64..127] - The upper range of the boolean output registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		OutputBitRegisters = 56,

		/// <summary>
		/// 48 general purpose integer registers. X: [0..23] - The lower range of the integer output registers is reserved for FieldBus/PLC interface usage. X: [24..47] - The upper range of the integer output registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		OutputIntRegisters = 57,

		/// <summary>
		/// 48 general purpose double registers. X: [0..23] - The lower range of the double output registers is reserved for FieldBus/PLC interface usage. X: [24..47] - The upper range of the double output registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		OutputDoubleRegisters = 58,

		/// <summary>
		/// General purpose bits (input read back). This range of the boolean output registers is reserved for FieldBus/PLC interface usage.
		/// </summary>
		InputBitRegisters0To31 = 59,

		/// <summary>
		/// General purpose bits (input read back), This range of the boolean output registers is reserved for FieldBus/PLC interface usage.
		/// </summary>
		InputBitRegisters32To63 = 60,

		/// <summary>
		/// �64 general purpose bits, X: [64..127] - The upper range of the boolean output registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		InputBitRegisters = 61,

		/// <summary>
		/// 48 general purpose integer registers. X: [0..23] - The lower range of the integer input registers is reserved for FieldBus/PLC interface usage. X: [24..47] - The upper range of the integer input registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		InputIntRegisters = 62,

		/// <summary>
		/// �48 general purpose double registers. X: [0..23] - The lower range of the double input registers is reserved for FieldBus/PLC interface usage. X: [24..47] - The upper range of the double input registers can be used by external RTDE clients (i.e URCAPS).
		/// </summary>
		InputDoubleRegisters = 63,

		/// <summary>
		/// The current output mode
		/// </summary>
		ToolOutputMode = 64,

		/// <summary>
		/// The current mode of digital output 0
		/// </summary>
		ToolDigitalOutput0mode = 65,

		/// <summary>
		/// The current mode of digital output 1
		/// </summary>
		ToolDigitalOutput1Mode = 66,

		/// <summary>
		/// Payload mass Kg
		/// </summary>
		Payload = 67,

		/// <summary>
		/// Payload Center of Gravity (CoGx, CoGy, CoGz) m
		/// </summary>
		PayloadCOG = 68,

		/// <summary>
		/// Payload inertia matrix elements (Ixx,Iyy,Izz,Ixy,Ixz,Iyz] expressed in kg*m^2
		/// </summary>
		PayloadInertia = 69,

		/// <summary>
		/// Script line number that is actually in control of the robot given the robot is locked by one of the threads in the script. If no thread is locking the robot this field is set to '0'. Script line number should not be confused with program tree line number displayed on polyscope.
		/// </summary>
		ScriptControlLine = 70,

		/// <summary>
		/// Raw force and torque measurement, not compensated for forces and torques caused by the�payload
		/// </summary>
		FTRawWrench = 71,
	}
}
