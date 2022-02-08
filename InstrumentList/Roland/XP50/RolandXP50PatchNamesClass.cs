using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    public struct Program
    {
        public int bank;
        public int patch;

        public Program(int b, int p)
        {
            bank = b;
            patch = p;
        }
    }

    //-----------------------------  Static class containing all names of banks and patches  --------------------------------
    public static class BankNameConvertor
    {
        // TXt Filenames
        private static bool loaded = false;
        private static string defaultPath = "";
        private const string bankUserFileName = "USER.txt";
        private const string bankAFileName = "Bank A.txt";
        private const string bankBFileName = "Bank B.txt";
        private const string bankCFileName = "Bank C.txt";
        private const string bankGMFileName = "GM.txt";
        private const string bankExpAFileName = "Bank EXP-A.txt";
        private const string bankExpBFileName = "Bank Exp-B.txt";
        // Banknames
        private static BankNames bankUser;
        private static BankNames bankA;
        private static BankNames bankB;
        private static BankNames bankC;
        private static BankNames bankGM;
        private static BankNames bankExpA;
        private static BankNames bankExpB;
        // Patchname MATRIX
        private static readonly string[] bankNamesArray = new string[7];
        private static readonly string[][] namesArray = new string[7][];
        public static string[] BankNamesArray
        {
            get
            {
                return bankNamesArray;
            }
        }
        public static string[][] NamesArray
        {
            get
            {
                return namesArray;
            }
        }

        // Load data from files and prepare name matrix
        public static void LoadData()
        {
            defaultPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "InstrumentList\\Roland\\XP50\\Txt");

            bankNamesArray[0] = "USER";
            bankNamesArray[1] = "A";
            bankNamesArray[2] = "B";
            bankNamesArray[3] = "C";
            bankNamesArray[4] = "GM";
            bankNamesArray[5] = "Exp-A";
            bankNamesArray[6] = "Exp-B";

            bankUser = new BankNames(bankNamesArray[0]);
            bankA = new BankNames(bankNamesArray[1]);
            bankB = new BankNames(bankNamesArray[2]);
            bankC = new BankNames(bankNamesArray[3]);
            bankGM = new BankNames(bankNamesArray[4]);
            bankExpA = new BankNames(bankNamesArray[5]);
            bankExpB = new BankNames(bankNamesArray[6]);

            bankUser.Load(Path.Combine(defaultPath, bankUserFileName));
            bankA.Load(Path.Combine(defaultPath, bankAFileName));
            bankB.Load(Path.Combine(defaultPath, bankBFileName));
            bankC.Load(Path.Combine(defaultPath, bankCFileName));
            bankGM.Load(Path.Combine(defaultPath, bankGMFileName));
            bankExpA.Load(Path.Combine(defaultPath, bankExpAFileName));
            bankExpB.Load(Path.Combine(defaultPath, bankExpBFileName));

            FillBankByNames(0, bankUser);
            FillBankByNames(1, bankA);
            FillBankByNames(2, bankB);
            FillBankByNames(3, bankC);
            FillBankByNames(4, bankGM);
            FillBankByNames(5, bankExpA);
            FillBankByNames(6, bankExpB);

            loaded = true;
        }
        // Fill patchname matrix
        private static void FillBankByNames(int bankIndex, BankNames bank)
        {
            int count = bank.Count;
            namesArray[bankIndex] = new string[count];
            for (int i = 0; i < count; i++)
            {
                namesArray[bankIndex][i] = string.Format("{0:000} ", (i + 1)) + bank[i];
            }
        }
        // Reload User Bank names
        public static void ReloadUserBank(string defaultPath, string bankUserFileName)
        {
            bankUser.Load(Path.Combine(defaultPath, bankUserFileName));
        }

        // Get Patch Program From MSB, LSB, Patch
        public static Program GetPatchProgram(int MSB, int LSB, int patchIndex)
        {
            int bank = 0;
            int patch = patchIndex;

            switch (MSB)
            {
                case 0x50:
                    if (LSB == 0) bank = 0;
                    break;

                case 0x51:
                    switch (LSB)
                    {
                        case 0x00:
                            bank = 1;
                            break;
                        case 0x01:
                            bank = 2;
                            break;
                        case 0x02:
                            bank = 3;
                            break;
                        case 0x03:
                            bank = 4;
                            break;
                    }
                    break;

                case 0x54:
                    switch (LSB)
                    {
                        case 0x00:
                            bank = 5;
                            break;
                        case 0x01:
                            bank = 5;
                            patch += 128;
                            break;
                        case 0x02:
                            bank = 6;
                            break;
                        case 0x03:
                            bank = 6;
                            patch += 128;
                            break;
                        case 0x04:
                            bank = 7;
                            break;
                        case 0x05:
                            bank = 7;
                            patch += 128;
                            break;
                        case 0x06:
                            bank = 8;
                            break;
                        case 0x07:
                            bank = 8;
                            patch += 128;
                            break;
                    }
                    break;
            }

            return new Program(bank, patch);
        }
        // Get Patch Program From byte[]
        public static Program GetPatchProgram(byte[] buffer)
        {
            int patchIndex = (buffer[2] << 4) + buffer[3];
            int bank = 0;

            switch (buffer[0])
            {
                case 0:
                    switch (buffer[1])
                    {
                        case 1:
                            bank = 0;
                            break;

                        case 3:
                            bank = 1;
                            break;

                        case 4:
                            bank = 2;
                            break;

                        case 5:
                            bank = 3;
                            break;

                        case 6:
                            bank = 4;
                            break;
                    }
                    break;

                case 2:
                    switch (buffer[1])
                    {
                        case 1:
                            bank = 5;
                            break;

                        case 4:
                            bank = 6;
                            break;
                    }
                    break;

                default:
                    bank = 0;
                    break;
            }

            return new Program(bank, patchIndex);
        }

        // Get Patch Name From MSB, LSB, Patch
        public static string GetPatchName(int MSB, int LSB, int patchIndex)
        {
            return GetPatchName(GetPatchProgram(MSB, LSB, patchIndex));
        }
        // Get Patch Name From byte[]
        public static string GetPatchName(byte[] buffer)
        {
            return GetPatchName(GetPatchProgram(buffer));
        }
        // Get Patch Name From Program Structure
        public static string GetPatchName(Program program)
        {
            return GetPatchName(program.bank, program.patch);
        }
        // Get Patch Name From Indexes
        public static string GetPatchName(int bank, int patch)
        {
            return string.Format("{0}{1:000} ({2})", BankNamesArray[bank], patch + 1, namesArray[bank][patch]);
        }

        // Next Program
        public static Program NextProgram(byte[] buffer)
        {
            Program program = GetPatchProgram(buffer);
            if (program.patch < BankNameConvertor.namesArray[program.bank].Length - 1)
            {
                program.patch++;
            }
            else if (program.bank < BankNameConvertor.namesArray.Length - 1)
            {
                program.bank++;
                program.patch = 0;
            }
            return program;
        }
        // Prev  Program
        public static Program PrevProgram(byte[] buffer)
        {
            Program program = GetPatchProgram(buffer);
            if (program.patch > 0)
            {
                program.patch--;
            }
            else if (program.bank > 0)
            {
                program.bank--;
                program.patch = BankNameConvertor.namesArray[program.bank].Length - 1;
            }
            return program;
        }

        // Program -> byte[]
        public static byte[] GetBufferFromProgram(Program program)
        {
            byte[] buf = new byte[4];
            byte patch = (byte)program.patch;
            buf[3] = (byte)(patch & 0x0F);
            buf[2] = (byte)((patch & 0xF0) >> 4);
            switch (program.bank)
            {
                case 0:
                    buf[1] = 1;
                    buf[0] = 0;
                    break;
                case 1:
                    buf[1] = 3;
                    buf[0] = 0;
                    break;
                case 2:
                    buf[1] = 4;
                    buf[0] = 0;
                    break;
                case 3:
                    buf[1] = 5;
                    buf[0] = 0;
                    break;
                case 4:
                    buf[1] = 6;
                    buf[0] = 0;
                    break;
                case 5:
                    buf[1] = 1;
                    buf[0] = 2;
                    break;
                case 6:
                    buf[1] = 4;
                    buf[0] = 2;
                    break;
            }

            return buf;
        }
        // Next
        public static byte[] Next(byte[] buffer)
        {
            return GetBufferFromProgram(NextProgram(buffer));
        }
        // Prev
        public static byte[] Prev(byte[] buffer)
        {
            return GetBufferFromProgram(PrevProgram(buffer));
        }

        // MSB, LSB, patchIndex -> byte[]
        public static byte[] ChannelCommandToBuffer(int MSB, int LSB, int patchIndex)
        {
            byte[] buf = new byte[4];

            switch (MSB)
            {
                case 0x50:
                    if (LSB == 0)
                    {
                        buf[0] = 0;
                        buf[1] = 1;
                    }
                    break;

                case 0x51:
                    switch (LSB)
                    {
                        case 0x00:
                            {
                                buf[0] = 0;
                                buf[1] = 3;
                            }
                            break;
                        case 0x01:
                            {
                                buf[0] = 0;
                                buf[1] = 4;
                            }
                            break;
                        case 0x02:
                            {
                                buf[0] = 0;
                                buf[1] = 5;
                            }
                            break;
                        case 0x03:
                            {
                                buf[0] = 0;
                                buf[1] = 6;
                            }
                            break;
                    }
                    break;

                case 0x54:
                    switch (LSB)
                    {
                        case 0x00:
                            {
                                buf[0] = 2;
                                buf[1] = 1;
                            }
                            break;
                        case 0x01:
                            {
                                buf[0] = 2;
                                buf[1] = 1;
                                patchIndex += 128;
                            }
                            break;
                        case 0x02:
                            {
                                buf[0] = 2;
                                buf[1] = 4;
                            }
                            break;
                        case 0x03:
                            {
                                buf[0] = 2;
                                buf[1] = 4;
                                patchIndex += 128;
                            }
                            break;
                    }
                    break;
            }

            buf[2] = (byte)((patchIndex & 0xF0) >> 4);
            buf[3] = (byte)(patchIndex & 0xF);

            return buf;
        }
        // Is Loaded
        public static bool IsLoaded
        {
            get { return loaded; }
        }
    }

    //---------------------------------  Class containing bank name and patch names  ----------------------------------------
    public class BankNames
    {
        // Patch Name List
        private readonly List<string> names = new List<string>();

        // Bank Name
        private readonly string bankName = "";

        // Indexator
        public string this[int index]
        {
            get { return names[index]; }
        }

        // Patch count in Bank
        public int Count
        {
            get { return names.Count; }
        }

        // Receive Bank Name
        public string BankName
        {
            get { return bankName; }
        }

        // Patch names -> String Array
        public string[] ToStringArray()
        {
            return names.ToArray();
        }

        // Constructor
        public BankNames(string name)
        {
            bankName = name;
        }

        // Load Data from File
        public void Load(string filename)
        {
            names.Clear();
            StreamReader sr = new StreamReader(filename);
            string name;
            while ((name = sr.ReadLine()) != null)
            {
                names.Add(name);
            }
            sr.Close();
        }
    }
}
