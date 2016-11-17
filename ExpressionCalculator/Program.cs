using System;
using System.Collections.Generic;

namespace ExpressionCalculator {

    public struct Character {
        private char C;

        public Character (int c) {
            C = (char)c;
        }

        public static implicit operator Character (int c) {
            return new Character(c);
        }

        public static implicit operator Character (char c) {
            return new Character(c);
        }

        public static implicit operator int (Character c) {
            return c.C;
        }

        public static implicit operator char (Character c) {
            return c.C;
        }

        public static bool operator == (Character a, int b) {
            return a.C == b;
        }
        public static bool operator == (Character a, int b) {
            return a.C == b;
        }

        public static bool operator != (Character a, int b) {
            return !(a == b);
        }

        public static bool operator == (int a, Character b) {
            return (b == a);
        }

        public static bool operator != (int a, Character b) {
            return !(b == a);
        }
    }

    public class Program {

        public static void Main (string[] args) {
            Character c = '\0';
            Dictionary<Character, int> Variables = new Dictionary<Character, int>();
            while ((c = Console.In.Peek()) != ';') {
                if (char.IsLetter(c)) {
                }
            }
        }
    }
}