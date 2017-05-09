using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using System.Collections;


namespace UnityStandardAssets.Vehicles.Car
{
	
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use
		private string carMPH;
		public Text carSpeed;
		public Text restart;
		public Text blowUpSpeed;
		public Boolean death;
		public bool isCoroutineExecuting = false;




        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
			carMPH = 0.ToString ();
			carSpeed.text = carMPH;
			AudioListener.volume = 1;
			int time = 0;
	
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
			var explode = GameObject.Find("BigExplosionEffect");

#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
			carSpeed.text = convertSpeed() + " MPH";
			blowUpSpeed.text = "Blow up Speed: "+m_Car.blowUpSpeed.ToString();

			//Boolean death = checkSpeed(Int32.Parse(convertSpeed()));
		
			StartCoroutine(checkSpeed(Int32.Parse(convertSpeed())));

			//Debug.Log("Death: " + death);
			if(death){
				
				explode.GetComponent<AudioSource>().Play();
				explode.GetComponent<ParticleSystem>().Play();
				Destroy(GameObject.Find("SkyCar"));
				Destroy(GameObject.Find("WheelsHubs"));
				m_Car.exploded = true;
				restart.text = "Press R to restart";
				StartCoroutine(stopSound(explode));





			
			}
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }

		private string convertSpeed(){
			double carSpeed = Math.Round (m_Car.CurrentSpeed);
			carMPH = carSpeed.ToString ();
			return carMPH;
		}
			


		private IEnumerator checkSpeed(int speed){

			if (!isCoroutineExecuting) {
				if (speed > m_Car.blowUpSpeed) {
				
					isCoroutineExecuting = true;

					Debug.Log ("waiting...");
					yield return new WaitForSeconds (3f);
					speed = Int32.Parse(convertSpeed());

					if (speed > m_Car.blowUpSpeed) {
						Debug.Log ("Exploading...");
						death = true;
					}

					isCoroutineExecuting = false;
				}
			}
			if (death != true) {
				death = false;
			}
		}
			
			

		IEnumerator stopSound(GameObject explosion){
			yield return new WaitForSeconds (.5f);
			//Return back to normal blow up speed after 5 seconds
			explosion.GetComponent<ParticleSystem>().Stop();
			AudioListener.volume = 0;
		}
	
	
			
}
}