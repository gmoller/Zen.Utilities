using System;
using System.Diagnostics;
using System.Reflection;

namespace Zen.Utilities
{
    public static class ObjectCreator
    {
        public static object CreateInstance(string assemblyQualifiedName)
        {
            var objectType = Type.GetType(assemblyQualifiedName);
            var instantiatedObject = Activator.CreateInstance(objectType ?? throw new InvalidOperationException($"Failed to GetType for [{assemblyQualifiedName}]"));
            if (instantiatedObject is null) throw new InvalidOperationException($"Failed to CreateInstance for [{assemblyQualifiedName}]");

            return instantiatedObject;
        }

        public static object CreateInstance(string assemblyQualifiedName, params object[] args)
        {
            var objectType = Type.GetType(assemblyQualifiedName);
            var instantiatedObject = Activator.CreateInstance(objectType ?? throw new InvalidOperationException($"Failed to GetType for [{assemblyQualifiedName}]"), args);
            if (instantiatedObject is null) throw new InvalidOperationException($"Failed to CreateInstance for [{assemblyQualifiedName}]");

            return instantiatedObject;
        }

        public static MethodInfo GetMethod(string assemblyQualifiedName, string methodName)
        {
            var objectType = Type.GetType(assemblyQualifiedName);
            if (objectType is null) throw new InvalidOperationException($"Failed to GetType for [{assemblyQualifiedName}]");

            var methodInfo = objectType.GetMethod(methodName);
            if (methodInfo is null) throw new InvalidOperationException($"Failed to GetMethod for [{methodName}]");

            return methodInfo;
        }

        public static CallingType GetCallerType(int level)
        {
            var stackTrace = new StackTrace();
            var stackFrame = stackTrace.GetFrame(level + 1);
            if (stackFrame == null) throw new Exception();

            var callingMethod = stackFrame.GetMethod();
            if (callingMethod == null) throw new Exception();

            var callingType = callingMethod.ReflectedType;
            if (callingType == null) throw new Exception();

            var callingNamespace = callingType.Namespace;
            var callingTypeFullName = $"{callingNamespace}.{callingType.Name}";
            var callingAssemblyFullName = callingType.Assembly.FullName;

            var returnCallingType = new CallingType {TypeFullName = callingTypeFullName, AssemblyFullName = callingAssemblyFullName };

            return returnCallingType;
        }
    }
}