using ExpressionCalculator.Type;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ExpressionCalculator.EntryRunner {

    public class Entry {

        public static void Main( string[ ] args ) {
            Character c = '\0';
            Dictionary<Character, int> Variables = new Dictionary<Character, int>();
            StringBuilder build = new StringBuilder();
            ConsoleKeyInfo Info;
            Func<ConsoleKeyInfo> Get = () => {
                var pressed = Console.ReadKey(true);
                c = pressed.KeyChar;
                return pressed;
            };
            CaretWriter caret = new CaretWriter(build);
            while( ( Info = Get() ).Key != ConsoleKey.Enter ) {
                if( !char.IsWhiteSpace( c ) && !char.IsControl( c ) && char.GetUnicodeCategory( c ) != UnicodeCategory.OtherPunctuation ) {
                    caret.Write( c );
                }
                switch( Info.Key ) {
                    case ConsoleKey.Backspace:

                        caret.BackSpace();
                        break;

                    case ConsoleKey.Spacebar:
                        caret.Write( ' ' );
                        break;

                    case ConsoleKey.LeftArrow:
                        caret.Left();
                        break;

                    case ConsoleKey.RightArrow:
                        caret.Right();
                        break;

                    default:
                        break;
                }
            }
            Console.Write( '\n' );
            Console.WriteLine( build.ToString() );

            Formatting.GroupPar(build.ToString());
            //TODO Replace the placeholders for the groups of parenthesis with the values from Par dictionary
            Console.Read();
        }
    }
}