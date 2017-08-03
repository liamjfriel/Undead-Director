using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UndeadDirector
{
    static class ExtensionMethods
    {

        private static Random rand = new Random();
        private static Object locker = new Object();

        //Michael Hoffmans Angle algorithim
        //http://gamedevelopment.tutsplus.com/tutorials/make-a-neon-vector-shooter-in-xna-basic-gameplay--gamedev-9859
        public static float Angle(this Vector2 vector)
        {
            return (float)Math.Atan2((double)vector.Y, (double)vector.X);
        }

        //Michael Hoffmans From Polar Algorithim
        //http://gamedevelopment.tutsplus.com/tutorials/make-a-neon-vector-shooter-in-xna-basic-gameplay--gamedev-9859
        public static Vector2 FromPolar(float angle, float magnitude)
        {
            return magnitude * new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
        }


        //Patrtk Deoghare's Random Number Algorithim that avoids getting the same number over and over
        //http://stackoverflow.com/questions/2643421/correct-method-of-a-static-random-next-in-c/2643442#2643442
        public static int RandomNumber(int min, int max)
        {

            lock (locker)
            { // synchronize
                return rand.Next(min, max);
            }
        }


        //Michael Hoffmans ScaleTo Algorithim
        //http://gamedevelopment.tutsplus.com/tutorials/make-a-neon-vector-shooter-in-xna-more-gameplay--gamedev-10103
        public static Vector2 ScaleTo(this Vector2 vector, float length)
        {
            return vector * (length / vector.Length());
        }



    }
}
