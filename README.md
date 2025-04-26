# UnityLogUtil
UnityLogUtil is a lightweight and flexible logging utility for Unity. It allows you to easily output styled and colored log messages with rich contextual information, helping you debug faster and more effectively.

# Advantages
- Automatically logs the class and method name from where the log was called.
- Highlights logs with a standard color and allows you to use any custom color for better visual clarity.
- Supports logging only in the Unity Editor or everywhere 

# Usage examples
![alt text](https://github.com/KotikovD/UnityLogUtil/blob/main/UnityLogUtil.jpg?raw=true)
```csharp
LogUtil.LogError(this, "Red error log only for Editor", editorOnly: true);
LogUtil.LogWarning(this, "Logs with yellow color");
LogUtil.LogGreen(this, "Noticeable green log");
LogUtil.Log(this, "Regular white log");
LogUtil.Log(this, "Custom color for connoisseurs", textColor: Color.blue);
```

# Installation
Copy the **LogUtil.cs** file into any folder in your project (for example: *Assets/Scripts/Utils* or any other location)

# Compatibility
Unity: 2020.3 and newer

# License
This project is available for free for both commercial and non-commercial use.
