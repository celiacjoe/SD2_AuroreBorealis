using UnityEngine;

namespace OscSimpl.Examples
{
	public class GettingStartedSending : MonoBehaviour
	{
		[SerializeField] OscOut _oscOut;

		OscMessage _message2; // Cached message.
        
        private int Nbr_portOut;
		public string address1 = "/f7/f1";
		public string address2 = "/f7/f2";
        public string address3 = "/High";
        private string LocalIPTarget;
        public float floatValue;
        public float floatValue2;

       // float fract (float t) { return t-Mathf.Floor(t); }
       // float  rd (float t) { return fract(Mathf.Sin(float.Dot(Mathf.Floor(t),45.236f))*7845.236f); }


        void Start()
		{
            LocalIPTarget = _oscOut.remoteIpAddress;
            Nbr_portOut = _oscOut.port;
           // LocalIPTarget = "192.168.1.25";
            // Ensure that we have a OscOut component.
            if ( !_oscOut ) _oscOut = gameObject.AddComponent<OscOut>();

			// Prepare for sending messages locally on this device on port 7000.
			_oscOut.Open(Nbr_portOut, LocalIPTarget);

            // ... or, alternatively target remote devices with a IP Address.
            //oscOut.Open( 7000, "192.168.1.101" );

            // If you want to send a single value then you can use this one-liner.
            //_oscOut.Send( address1, 0.5f );

            // If you want to send a message with multiple values, then you
            // need to create a message, add your values and send it.
            // Always cache the messages you create, so that you can reuse them.
            //_message2 = new OscMessage( address2 );
            //_message2.Add( Time.frameCount ).Add( Time.time ).Add( Random.value );
            //_oscOut.Send( _message2 );
            // _oscOut.Send(address2, 0.6f);
        }


		void Update()
		{
            float tt = Time.time * 0.25f;
            _oscOut.Send(address1, Mathf.Pow(Mathf.PerlinNoise(tt, 12), 5));
            _oscOut.Send(address2, Mathf.Pow(Mathf.PerlinNoise(tt, 43), 4));
            _oscOut.Send(address3, Mathf.Pow(Mathf.PerlinNoise(tt, 24), 6));
            // We update the content of message2 and send it again.
            //   _message2.Set( 0, Time.frameCount );
            //	_message2.Set( 1, Time.time );
            //	_message2.Set( 2, Random.value );
            //	_oscOut.Send( _message2 );
        }
	}
}