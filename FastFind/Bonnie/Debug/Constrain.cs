using System;

namespace Bonnie.Debug
{
    public class Constrain
    {
        public static void NotNull(object obj)
        {
            if (obj == null)
            {
                throw new ConstrainException("违反NotNull约束");
            }
        }

        public static void NotEmptyString(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ConstrainException("违反NotEmptyString约束");
            }
        }

        public static void NotNegative(int x)
        {
            if (x < 0)
            {
                throw new ConstrainException("违反NotNegative约束");
            }
        }

        public static void Equals(int a, int b)
        {
            if (a != b)
            {
                throw new ConstrainException("违反Equals约束");
            }
        }

        public static void BeTrue(bool b)
        {
            if (b != true)
            {
                throw new ConstrainException("违反BeTrue约束");
            }
        }

        public static void TypeIs(object obj, Type type)
        {
            if (obj.GetType() != type)
            {
                throw new ConstrainException("违反TypeIs约束");
            }
        }

        public static void TypeIs(object obj, params Type[] types)
        {
            // 这里写的还不是很完整，没有考虑 obj == null 的情况
            Constrain.NotNull(obj);
            Type objType = obj.GetType();

            foreach (Type type in types)
            {
                if (type.IsAssignableFrom(objType))
                {
                    return;
                }
            }
            throw new ConstrainException("违反TypeIs约束");
        }

        public static void UnreachableCode()
        {
            throw new ConstrainException("违反UnreachableCode约束");
        }

        public static void UnreachableCode(string debugMessage)
        {
            throw new ConstrainException("违反UnreachableCode约束：" + debugMessage);
        }
    }

    public class ConstrainException : Exception
    {
        public ConstrainException(string message) : base(message)
        {

        }
    }
}
