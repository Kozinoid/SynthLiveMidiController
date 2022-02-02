using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SynthLiveMidiController.InstrumentList.Roland.XP50
{
    //-----------------------------  Static class containing all names of banks and patches  --------------------------------
    public static class BankNameConvertor
    {
        // TXt Filenames
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
        // Get Patch name 1
        public static string GetPatchName(int MSB, int LSB, int patchIndex)
        {
            string bankName = "";

            switch (MSB)
            {
                case 0x50:
                    if (LSB == 0) bankName = "USER:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankUser[patchIndex] + ")";
                    break;

                case 0x51:
                    switch (LSB)
                    {
                        case 0x00:
                            bankName = "A:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankA[patchIndex] + ")";
                            break;
                        case 0x01:
                            bankName = "B:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankB[patchIndex] + ")";
                            break;
                        case 0x02:
                            bankName = "C:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankC[patchIndex] + ")";
                            break;
                        case 0x03:
                            bankName = "GM:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankGM[patchIndex] + ")";
                            break;
                    }
                    break;

                case 0x54:
                    switch (LSB)
                    {
                        case 0x00:
                            bankName = "Exp-A:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankExpA[patchIndex] + ")";
                            break;
                        case 0x01:
                            bankName = "Exp-A:" + string.Format("{0:000}", patchIndex + 129) + "(" + bankExpA[patchIndex + 128] + ")";
                            break;
                        case 0x02:
                            bankName = "Exp-B:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankExpB[patchIndex] + ")";
                            break;
                        case 0x03:
                            bankName = "Exp-B:" + string.Format("{0:000}", patchIndex + 129) + "(" + bankExpB[patchIndex + 128] + ")";
                            break;
                        case 0x04:
                            bankName = "Exp-C:" + string.Format("{0:000}", patchIndex + 1);
                            break;
                        case 0x05:
                            bankName = "Exp-C:" + string.Format("{0:000}", patchIndex + 129);
                            break;
                        case 0x06:
                            bankName = "Exp-D:" + string.Format("{0:000}", patchIndex + 1);
                            break;
                        case 0x07:
                            bankName = "Exp-D:" + string.Format("{0:000}", patchIndex + 129);
                            break;
                    }
                    break;
            }

            return bankName;
        }
        // Get Patch name 2
        public static string GetPatchName(byte[] buffer)
        {
            string bankName = "";
            int patchIndex = (buffer[2] << 4) + buffer[3];

            switch (buffer[0])
            {
                case 0:
                    switch (buffer[1])
                    {
                        case 1:
                            bankName = "USER:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankUser[patchIndex] + ")";
                            break;

                        case 3:
                            bankName = "A:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankA[patchIndex] + ")";
                            break;

                        case 4:
                            bankName = "B:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankB[patchIndex] + ")";
                            break;

                        case 5:
                            bankName = "C:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankC[patchIndex] + ")";
                            break;

                        case 6:
                            bankName = "GM:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankGM[patchIndex] + ")";
                            break;
                    }
                    break;

                case 2:
                    switch (buffer[1])
                    {
                        case 1:
                            bankName = "Exp-A:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankExpA[patchIndex] + ")";
                            break;

                        case 4:
                            bankName = "Exp-B:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankExpB[patchIndex] + ")";
                            break;
                    }
                    break;

                default:
                    bankName = "Unknown:" + string.Format("{0:000}", patchIndex + 1) + "(" + bankExpB[patchIndex] + ")";
                    break;
            }

            return bankName;
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
