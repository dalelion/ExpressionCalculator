using ExpressionCalculator.Type;
using System;
using System.Text;

namespace ExpressionCalculator {

    public class CaretWriter {

        /// <summary>
        /// Handler for the caret position
        /// </summary>
        private struct Position {
            private int x;
            private int y;
            public int X {
                get { return x; }
                set {
                    //Cursor Updating
                    if( x + value >= 0 )
                        x = value;
                    Console.CursorLeft = x;
                }
            }
            public int Y {
                get { return y; }
                set {
                    //Cursor Updating
                    if( y + value >= 0 )
                        y = value;
                    Console.CursorTop = y;
                }
            }

            /// <summary>
            /// Create a new position handler.
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            public Position( int x , int y ) {
                this.x = x;
                this.y = y;
            }
        }

        /// <summary>
        /// The cursor should be at this position.
        /// </summary>
        private Position Cursor;

        /// <summary>
        /// This is where it writes characters
        /// </summary>
        private StringBuilder Builder;

        /// <summary>
        /// CaretWriter. For specialized input. Still under testing/writing. Takes a StringBuilder as a parameter.
        /// </summary>
        /// <param name="b"></param>
        public CaretWriter( StringBuilder b ) {
            this.Builder = b;
            this.Cursor = new Position( Console.CursorLeft , Console.CursorTop );
        }

        /// <summary>
        /// Deletes one character and moves the caret to the left once
        /// </summary>
        public void BackSpace() {
            try {
                this.Builder.Remove( Cursor.X - 1 , 1 );
            } catch( Exception ) {
                //Do Nothing
            } finally {
                Cursor.X -= 1;
                Console.Write( ' ' );
                Cursor.X += 0;
            }
        }

        /// <summary>
        /// Moves the cursor down and to the left creating a newline but, without adding a newline character.
        /// </summary>
        public void NewLine() {
            Cursor.Y += 1;
            Cursor.X = 0;
        }

        /// <summary>
        /// Moves the caret to the left once
        /// </summary>
        public void Left() {
            try {
                Cursor.X -= 1;
            } catch( Exception ) {
                return;
            }
        }

        /// <summary>
        /// Moves the caret to the right once, if it is within the builder length
        /// </summary>
        public void Right() {
            try {
                if( Cursor.X < this.Builder.Length )
                    Cursor.X += 1;
            } catch( Exception ) {
                return;
            }
        }

        /// <summary>
        /// Write this character to the screen and moves the caret to the right.
        /// </summary>
        /// <param name="c"></param>
        public void Write( Character c ) {
            if( Cursor.X >= this.Builder.Length )
                this.Builder.Append( c );
            else
                this.Builder.Remove( Cursor.X , 1 ).Insert( Cursor.X , c );
            Console.Out.Write( c );
            Cursor.X += 1;
        }
    }
}