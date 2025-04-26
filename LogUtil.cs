using UnityEngine;

public static class LogUtil
{
    public static void Log(
        object caller,
        string logString = null,
        LogType logType = LogType.Log,
        bool editorOnly = false,
        Color textColor = default,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
    {
        if (caller == null)
        {
            Debug.unityLogger.Log(LogType.Error, $"<color=#{ColorUtility.ToHtmlStringRGB(Color.red)}>[LogUtil]",
                $"Caller is null. <b>MemberName</b>: \"{memberName}\". LogString: \"{logString}\".</color>");
            return;
        }

        if (!Application.isEditor && editorOnly)
            return;

        Object context = caller switch
        {
            GameObject go => go,
            Component component => component.gameObject,
            _ => null
        };

        logString = string.IsNullOrEmpty(logString) ? string.Empty : logString;
        var color = ColorUtility.ToHtmlStringRGB(textColor == default ? Color.white : textColor);
        logString = $"<color=#{color}>[{caller.GetType().Name}] <b>\"{memberName}\"</b>. {logString}</color>";

        if (context)
            Debug.unityLogger.Log(logType, (object) logString, context);
        else
            Debug.unityLogger.Log(logType, logString);
    }

    public static void LogWarning(
        object caller,
        string logString = null,
        bool editorOnly = false,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
    {
        Log(caller, logString, LogType.Warning, editorOnly, textColor: Color.yellow, memberName);
    }

    public static void LogError(
        object caller,
        string logString = null,
        bool editorOnly = false,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
    {
        Log(caller, logString, LogType.Error, editorOnly, textColor: Color.red, memberName);
    }

    public static void LogGreen(
        object caller,
        string logString = null,
        bool editorOnly = false,
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "")
    {
        Log(caller, logString, LogType.Log, editorOnly, textColor: Color.green, memberName);
    }
}
