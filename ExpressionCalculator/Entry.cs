using System;
using System.Collections.Generic;
using System.Text;

namespace ExpressionCalculator {

    public struct Character {
        private char C;

        public Character( int c ) {
            C = ( char )c;
        }

        public Character( char c ) {
            C = c;
        }

        public static implicit operator Character( int c ) {
            return new Character( ( char )c );
        }

        public static implicit operator Character( char c ) {
            return new Character( c );
        }

        public static implicit operator int( Character c ) {
            return c.C;
        }

        public static implicit operator char( Character c ) {
            return c.C;
        }

        public static bool operator ==( Character a , int b ) {
            return a.C == b;
        }

        public static bool operator !=( Character a , int b ) {
            return !( a == b );
        }

        public static bool operator ==( int a , Character b ) {
            return ( b == a );
        }

        public static bool operator !=( int a , Character b ) {
            return !( b == a );
        }

        public override string ToString() {
            return string.Format( "char='{0}',int={1}" , char.ToString( this.C ) , ( int )this.C );
        }
    }

    public static class CMD {

        public static void BackSpace() {
            Console.Write( ' ' );
            Console.CursorLeft -= 1;
        }

        public static void NewLine() {
            Console.CursorTop += 1;
            Console.CursorLeft = 0;
        }
    }

    public class Entry {

        public static Dictionary<int[], String> Pars = new Dictionary<int[], string>();
        //TODO 
        public static String GroupPar(String x) {
            
            int[] ParIndex = new int[2];

            if (x.Contains("(")) {
                ParIndex[0] = x.LastIndexOf("(");
                ParIndex[1] = x.IndexOf(")") - x.LastIndexOf("(") + 1;
                String Par = x.Substring(ParIndex[0], ParIndex[1]);

                Pars.Add(ParIndex, Par);
                Console.WriteLine(Par);
            }
            //NewS will be a new string with the last group of parenthesis removed and a placeholder in its spot
            String NewS = "("; //Just for testing

            return (x.Contains("(")) ? GroupPar(NewS) : NewS;
        }

        public static void Main( string[ ] args ) {
            Character c = '\0';
            Dictionary<Character, int> Variables = new Dictionary<Character, int>();
            StringBuilder build = new StringBuilder();
            ConsoleKeyInfo Key;
            while( ( c = ( Key = Console.ReadKey() ).KeyChar ) != ';' ) {
                if( !char.IsWhiteSpace( c ) && !char.IsControl( c ) ) {
                    build.Append( c );
                }
                if( Key.Key == ConsoleKey.Backspace ) {
                    try {
                        build.Remove( build.Length - 1 , 1 );
                        CMD.BackSpace();
                    } catch( Exception ) {
                        continue;
                    }
                }
                if( Key.Key == ConsoleKey.Enter ) {
                    CMD.NewLine();
                    Console.WriteLine( build.ToString() );
                    break;
                }
            }

            GroupPar(build.ToString());
            //TODO Replace the placeholders for the groups of parenthesis with the values from Par dictionary

            Console.Read();
        }
    }
}