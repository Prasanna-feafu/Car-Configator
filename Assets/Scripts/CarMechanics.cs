using UnityEngine;

public class CarMechanics : MonoBehaviour
{
	public CarJoystick joystickController;

	public void GetInput()
	{
		m_horizontalInput = joystickController.Horizontal;
		m_verticalInput = -joystickController.Vertical;
	}

	private void Steer()
	{
		m_steeringAngle = maxSteerAngle * m_horizontalInput;
		frontDriverW.steerAngle = m_steeringAngle;
		frontPassengerW.steerAngle = m_steeringAngle;
	}

	private void Accelerate()
	{
		frontDriverW.motorTorque = m_verticalInput * motorForce;
		frontPassengerW.motorTorque = m_verticalInput * motorForce;
	}

	public void BreakingOn()
	{
		frontDriverW.brakeTorque = breakingForce;
		frontPassengerW.brakeTorque = breakingForce;
		rearDriverW.brakeTorque = breakingForce;
		rearPassengerW.brakeTorque = breakingForce;
	}

	public void BreakingUp()
    {
		frontDriverW.brakeTorque = 0f;
		frontPassengerW.brakeTorque = 0f;
		rearDriverW.brakeTorque = 0f;
		rearPassengerW.brakeTorque = 0f;
	}

	private void UpdateWheelPoses()
	{
		UpdateWheelPose(frontDriverW, frontDriverT);
		UpdateWheelPose(frontPassengerW, frontPassengerT);
		UpdateWheelPose(rearDriverW, rearDriverT);
		UpdateWheelPose(rearPassengerW, rearPassengerT);
	}

	private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
	{
		Vector3 _pos = _transform.position;
		Quaternion _quat = _transform.rotation;

		_collider.GetWorldPose(out _pos, out _quat);

		_transform.position = _pos;
		_transform.rotation = _quat;
	}

	private void FixedUpdate()
	{
		GetInput();
		Steer();
		Accelerate();
		UpdateWheelPoses();
	}

	private float m_horizontalInput;
	private float m_verticalInput;
	private float m_steeringAngle;

	public WheelCollider frontDriverW, frontPassengerW;
	public WheelCollider rearDriverW, rearPassengerW;
	public Transform frontDriverT, frontPassengerT;
	public Transform rearDriverT, rearPassengerT;
	public float maxSteerAngle, motorForce, breakingForce;
}
