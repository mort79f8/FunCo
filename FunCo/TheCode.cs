using System;
using System.Collections.Generic;
using System.Text;

namespace FunCo
{
    // det kald som kommer fra WPF
    //private void ButtonOpg10_Click(object sender, RoutedEventArgs e)
    //{
    //    CB.CryptText(textBoxMain, textBoxResult);
    //}
    class TheCode
    {
        Random ran = new Random();
        private int intJump = 3;
        private List<string> listKeyLocal = new List<string> { "T", "O", "R", "S", "K", "E", "M", "U", "N", "D" };
        string[] dummyArray = { "A", "C", "B", "$", "Q", "-", "Æ", "½", ":", "G", "*", "H", "&", "J", "§", "L", "P", "<", "Z", ">", "F", "{", "Å", "¤" };

        public TheCode()
        {

        }

        public void CryptText(TextBox textBoxIn, TextBox textBoxOut)
        {
            intJump = 3;
            Encoding enc8 = Encoding.GetEncoding(1252);
            byte[] asciiBytes = enc8.GetBytes(textBoxIn.Text);
            string res = MakeDummyString();
            foreach (char asciiNO in asciiBytes)
            {
                res += MakeKodeOfChar(asciiNO);
            }
            textBoxOut.Text = res;
        }


        private string MakeKodeOfChar(char inChar)
        {
            string res = "";
            int intChar = inChar;
            int charInt = 0;
            string strChar = intChar.ToString();
            foreach (char no in strChar)
            {
                string charString = no.ToString();
                charInt = Convert.ToInt32(charString);
                //for (int i = 1; i <= intJump; i++)
                //{
                charInt += intJump;
                if (charInt >= 10)
                {
                    charInt -= 10;
                }

                //}
                res += listKeyLocal[charInt];
                intJump++;
                if (intJump >= 10)
                {
                    intJump -= 10;
                }

            }
            return res + MakeDummyString();
        }

        private string MakeDummyString()
        {
            string res = "";
            int x = ran.Next(200, 1001);
            x = x / 100;
            for (int i = 0; i < x; i++)
            {
                int no = ran.Next(0, 24);
                res += dummyArray[no];
            }
            return res;
        }
    }
}
