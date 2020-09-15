using System;

namespace AD
{
    public static class BracketChecker
    {

        static MyStack<char> stack = new MyStack<char>();

        public static bool CheckBrackets(string s)
        {
            try {
                foreach (char c in s) {
                    if (c.Equals('(')) {
                        stack.Push(c);
                    } else if (!stack.IsEmpty()) {
                        stack.Pop();
                    } else {
                        return false;
                    }
                }

                if (stack.IsEmpty()) {
                    return true;
                }

                return false;
            } catch {
                return false;
            }
        }

        public static bool CheckBrackets2(string s)
        {
            throw new System.NotImplementedException();
        }

    }

    class BracketCheckerInvalidInputException : Exception
    {
    }

}
