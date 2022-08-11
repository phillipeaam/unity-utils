using System;
using System.Collections;
using UnityEngine.Networking;

public class InternetHelper
{
    private const string GoogleSite = "https://google.com";

    public static IEnumerator CheckInternetConnection(Action<bool> action)
    {
        var uwr = new UnityWebRequest(GoogleSite);

        yield return uwr.SendWebRequest();

        var wasSuccess = uwr.error == null;
        action?.Invoke(wasSuccess);
    }
}