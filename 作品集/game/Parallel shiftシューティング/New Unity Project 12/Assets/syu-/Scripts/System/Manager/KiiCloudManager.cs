using UnityEngine;
using System.Collections;

using KiiCorp.Cloud.Storage;
using KiiCorp.Cloud.Analytics;

public class KiiCloudManager : MonoBehaviour
{
	[SerializeField] private string _AppID;
	[SerializeField] private string _AppKey;

	private static bool OnRemoteCertificateValidationCallback(System.Object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate,
	                                                          System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors )
	{
		System.Net.HttpWebRequest request = sender as System.Net.HttpWebRequest;
		
		string hostName = request.RequestUri.Host;
		if( hostName == "api-jp.kii.com" ||
		   hostName == "api.kii.com" ||
		   hostName == "api-cn2.kii.com" )
		{
			return true;
		}
		
		return false;
	}

	public class KiiErrorInfoBase
	{
		public string errorCode;
		public string message;
	}
	
	public class KiiErrorUserAlreadyExists : KiiErrorInfoBase
	{
		public string field;
		public string value;
	}

	
	void Awake()
	{
		string deviceID = SystemInfo.deviceUniqueIdentifier;
		
		System.Net.ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(OnRemoteCertificateValidationCallback);
		
		Kii.Initialize( _AppID, _AppKey, Kii.Site.JP );
		
		KiiAnalytics.Initialize( _AppID, _AppKey, KiiAnalytics.Site.JP, deviceID );
	}




}