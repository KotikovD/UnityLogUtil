using UnityEngine;
using Object = UnityEngine.Object;

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
#if !UNITY_EDITOR
         if (editorOnly)
            return;
#endif

        if (caller == null)
        {
#if UNITY_EDITOR
            Debug.unityLogger.Log(LogType.Error, $"<color=#{ColorUtility.ToHtmlStringRGB(Color.red)}>[{nameof(LogUtil)}] " +
                $"Caller is null. <b>MemberName</b>: \"{memberName}\". LogString: \"{logString}\".</color>");
#else
            Debug.unityLogger.Log(LogType.Error, $"[{nameof(LogUtil)}] Caller is null. MemberName: \"{memberName}\". LogString: \"{logString}\".");
#endif
            return;
        }

#if UNITY_EDITOR
        var color = ColorUtility.ToHtmlStringRGB(textColor == default ? Color.white : textColor);
        logString = $"<color=#{color}>[{caller.GetType().Name}] <b>\"{memberName}\"</b>. {(string.IsNullOrEmpty(logString) ? string.Empty : logString)}</color>";
#else
        logString = $"[{caller.GetType().Name}] \"{memberName}\". {(string.IsNullOrEmpty(logString) ? string.Empty : logString)}";
#endif

        Object context = caller switch
        {
            GameObject go => go,
            Component component => component.gameObject,
            _ => null
            };

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
