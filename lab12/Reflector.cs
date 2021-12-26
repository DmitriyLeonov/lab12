using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    public static class Reflector<T>
    {
        public static void Asembly(Type t)
        {
            MemberInfo[] members = t.GetMembers();
            string member = "";
            foreach (MemberInfo m in members)
            {
                member += (m.Module.Assembly + "");
            }
            Console.WriteLine(member);
            Console.WriteLine("----------------------------------------------------");
            string path = @"vivod.txt";
            using (StreamWriter sr = new StreamWriter(path, true, Encoding.Default))
            {
                sr.Write(member);
            }
        }

        public static void PublicConstructors(Type t)
        {
            MemberInfo[] members = t.GetMembers();
            string member = "";
            foreach (MemberInfo m in members)
            {
                member += (m.ReflectedType.GetConstructors() + "");
            }
            if (member.Equals(""))
            {
                Console.WriteLine("есть");
            }
            else
            {
                Console.WriteLine("нет");
            }
            Console.WriteLine("----------------------------------------------------");
            string path = @"vivod.txt";
            using (StreamWriter sr = new StreamWriter(path, true, Encoding.Default))
            {
                sr.Write(member);
            }
        }

        public static IEnumerable<string> PublicMethods(Type t)
        {
            MethodBase[] s = t.GetMethods();
            IEnumerable<string> result = new List<string>();
            Console.WriteLine("----------------------------------------------------");
            foreach (MethodBase x in s)
            {
                if (x.IsPublic)
                {
                    Console.WriteLine(x.Name);
                    result.Append(x.Name);
                }
            }
            return result;
        }

        public static IEnumerable<string> Interfaces(Type t)
        {
            IEnumerable<string> result = new List<string>();
            Console.WriteLine("----------------------------------------------------");
            Type[] ty = t.GetInterfaces();
            foreach (Type x in ty)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine(x.Name);
                result.Append(x.Name);
            }
            return result;
        }

        public static void Parametrs(Type t, Type pt)
        {
            MethodInfo[] s = t.GetMethods();
            ParameterInfo[] p;
            Console.WriteLine("----------------------------------------------------");
            for (int i = 0; i < s.Length; i++)
            {

                p = s[i].GetParameters();
                foreach (ParameterInfo j in p)
                {

                    if (j.ParameterType == pt)
                    {

                        Console.WriteLine(s[i].Name);
                        break;
                    }
                }

            }

        }

        public static void Invoke(Type t, string param, object[] paramArray)
        {
            Console.WriteLine("----------------------------------------------------");
            MethodInfo method = t.GetMethod(param);
            object obj = Activator.CreateInstance(t);
            method.Invoke(obj, paramArray);
        }

        public static T Create<T>(Type type, Type[] parameters, object[] values)
        {
            ConstructorInfo info = type.GetConstructor(parameters);
            object result = info.Invoke(values);
            return (T)result;
        }
    }
}
