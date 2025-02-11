﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TargetReflection;

namespace TargetReflection
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType("TargetReflection." + investigatedClass);
            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder stringBuilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType,new object[] { });
            

            stringBuilder.AppendLine($"Class under investigation:{investigatedClass}");
            foreach (FieldInfo field in fields.Where(f => requestedFields.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return stringBuilder.ToString().Trim();

        }
        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            Type classType = Type.GetType("TargetReflection." + investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (FieldInfo field in classFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }
            foreach(MethodInfo method in classPublicMethods.Where(m=>m.Name.StartsWith("set")))
            {
                Console.WriteLine( method.Name);
                stringBuilder.AppendLine($"{method.Name} have to be private!");
            }
            foreach(MethodInfo method in classNonPublicMethods.Where(m=>m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} have to be public!");
            }
            return stringBuilder.ToString().Trim();
        }
        public string RevealPrivateMethods(string investigatedClass)
        {
            Type classType = Type.GetType("TargetReflection."+investigatedClass);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"All private Methods of Class: {investigatedClass}");
            stringBuilder.AppendLine($"Base Class:{classType.BaseType.Name}");

            foreach(MethodInfo method in classMethods)
            {
                stringBuilder.AppendLine(method.Name);
            }
            return stringBuilder.ToString().Trim();

        }
        public string CollectGettersAndSetters(string investigatedClass)
        {
            Type classType = Type.GetType("TargetReflection."+investigatedClass);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} will set fields of {method.GetParameters().First().ParameterType}");
            }
            return stringBuilder.ToString().Trim();


        }


    }
}
