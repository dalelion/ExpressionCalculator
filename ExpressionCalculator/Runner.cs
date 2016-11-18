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
            ConsoleKeyInfo Info;
            Func<ConsoleKeyInfo> Get = () => {
                var pressed = Console.ReadKey(true);
                c = pressed.KeyChar;
                return pressed;
            };
            CaretWriter caret = new CaretWriter();
            while( ( Info = Get() ).Key != ConsoleKey.Enter ) {
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
                    /*
                case ConsoleKey.D9:
                    caret = new CaretWriter( caret );
                    caret.Write( c );
                    continue;

                case ConsoleKey.D0:
                    caret.Write( c );
                    var current = caret;
                    caret = caret.EndOfCaret();
                    caret.NewLine();
                    Console.Write( current );
                    current.Last();
                    continue;
                    */
                    default:
                        break;
                }
                if( !char.IsWhiteSpace( c ) && !char.IsControl( c ) && char.GetUnicodeCategory( c ) != UnicodeCategory.OtherPunctuation ) {
                    caret.Write( c );
                }
            }
            Console.Write( '\n' );
            StringBuilder build = caret;
            Console.WriteLine( build.ToString() );

            Formatting.GroupPar( build.ToString() );
            //TODO Replace the placeholders for the groups of parenthesis with the values from Par dictionary

            Console.Read();
        }
    }
}