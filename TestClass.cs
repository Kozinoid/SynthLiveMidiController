﻿using System;

namespace SynthLiveMidiController
{
    class TestClass
    {
        // PRINT SYSEX
        public static void PrintBuffer(byte[] buffer, string tittle = "Array:")
        {
            //=================================== TEST ===============================
            Console.WriteLine(tittle);
            Console.WriteLine("Length: {0}", buffer.Length);

            foreach (byte bt in buffer) 
            {
                Console.Write("{0:X2} ", bt);
            }
            Console.WriteLine();
            //========================================================================
        }
    }
}
