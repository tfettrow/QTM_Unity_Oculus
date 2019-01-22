using System.Collections;
using System.Collections.Generic;
//using System.Collections.Generic.Queue;
using UnityEngine;
using QualisysRealTime.Unity;
using System.Linq;
public class CorrectGyro : MonoBehaviour {
    private Camera cam;

    public float HeadRotation_mocap;
    public float HeadRotation_imu;
	public Vector3 adjustment_vector;
    public float alpha = 0.05f;
    
	//public float VRreset;
    //public float Adjustment = 0;
	private bool Take_Mocap_Avg;
    private bool Correct_Gryo_Drift;
    private bool Buffer_Data;
    private float correct_gyro;

    // private Vector3 startPos;
    //private Vector3 
    // Use this for initialization
    private float MaxCapacity = 500;

	Queue<float> mocap_data = new Queue<float>();
	//public float queue_display;
	public float mocap_yaw_avg;
    //private float mocap_data_sum;
	//public float mocap_data_count;

	Queue<float> imu_data = new Queue<float>();
	//public float queue_display;
	public float imu_yaw_avg;
    public float angle_difference;
    public float angle_difference_alpha;
    public float angle_difference_alpha_delta;

    public float transform_eulerAngles_y;
    //public float imu_data_sum;
    //public float imu_data_count;

    void Start () 
	{
        cam = GetComponentInChildren <Camera>();
        //startPos = transform.localPosition;

        //HeadRotation = (Vector3)GameObject.Find("SceneControls").GetComponent<QualisysRealTime.Unity.Infinite_World_LR_Game>().HeadRotation_qtm;
        //VRreset = GameObject.Find("SceneControls").GetComponent<QualisysRealTime.Unity.Infinite_World_LR_Game>().VRreset;

		//GameObject go = GameObject.Find ("SceneControls");
		//QualisysRealTime.Unity.Infinite_World_LR_Game infinite_World_LR_Game = go.GetComponent <QualisysRealTime.Unity.Infinite_World_LR_Game> ();
		//correct_gyro = infinite_World_LR_Game.VRreset;
        
		//correct_gyro = Infinite_World_LR_Game.VRreset;

		//QualisysRealTime.Unity.Infinite_World_LR_Game>().HeadRotation_qtm;
        //    Infinite_World_LR.GetComponent<HeadRotation_qtm>;
    }

    // Update is called once per frame
    void Update() {

        // 
        // HeadRotation_mocap = transform.eulerAngles;
        
        HeadRotation_mocap = Infinite_World_LR_Game.HeadRotation_qtm_y;

        HeadRotation_imu = cam.transform.eulerAngles.y;

        if (HeadRotation_mocap >= 180)
        {
            HeadRotation_mocap = HeadRotation_mocap - 360;
        }

        if (HeadRotation_imu >= 180)
        {
            HeadRotation_imu = HeadRotation_imu - 360;
        }
        
        angle_difference = (HeadRotation_mocap - HeadRotation_imu);

        angle_difference_alpha = alpha * angle_difference;
        angle_difference_alpha_delta = angle_difference_alpha * Time.deltaTime;

        transform_eulerAngles_y = transform.eulerAngles.y + angle_difference_alpha_delta;
        adjustment_vector.y = transform_eulerAngles_y;
        transform.localEulerAngles = adjustment_vector;
        // This is stuff that is necessary if you want to perform drift correction by labview demand
        //if (Buffer_Data == false)
        //{
        //    correct_gyro = Infinite_World_LR_Game.correct_gyro_infiniteworld;
        //}

        //if(correct_gyro == 1)
        //{
        //	Buffer_Data = true;
        //     correct_gyro = 0;
        //Adjustment = Adjustment + 5;
        //HeadRotation_mocap.y = HeadRotation_mocap.y + Adjustment;
        //}

        //if (Buffer_Data) 
        //{
        //	if (mocap_data.Count >= MaxCapacity)
        //	{
        //		mocap_data.Dequeue ();
        //		imu_data.Dequeue ();
        //		Buffer_Data = false;
        //		Take_Mocap_Avg = true;
        //	}
        //	mocap_data.Enqueue (HeadRotation_mocap.y);
        //	imu_data.Enqueue (HeadRotation_imu.y);
        //}

        //if (Take_Mocap_Avg)
        //{
        // take average of mocap
        //    mocap_yaw_avg = mocap_data.Sum() / mocap_data.Count();
        //	imu_yaw_avg = imu_data.Sum () / imu_data.Count ();
        // take average of imu


        //	Take_Mocap_Avg = false;
        //	Correct_Gryo_Drift = true;
        //    mocap_data.Clear ();
        //    imu_data.Clear ();
        //}

        //if (Correct_Gryo_Drift) 
        //{


        //mocap_data

        // determine difference
        //angle_difference = HeadRotation_imu.y - HeadRotation_mocap.y;
        //adjustment_vector.y = adjustment_vector.y + -angle_difference;

        //	angle_difference = imu_yaw_avg - mocap_yaw_avg;
        //	adjustment_vector.y = -angle_difference;

        // apply inverse difference to parent transform (this one)


        //transform.eulerAngles = adjustment_vector;
        //			Correct_Gryo_Drift = false;
        //	}
        ///////////////////////////////////////////////////////////////////////////

        //transform.eulerAngles = adjustment_vector;
    }
}
