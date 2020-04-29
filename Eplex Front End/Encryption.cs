using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Eplex_Front_End
{
    public class Encryption
    {
        public string EncryptionKey = "Verde";

        public byte[] IVe = new byte[15];
        public byte[] IVd = new byte[15];
        public Aes encryptor;
        public Rfc2898DeriveBytes pdb;

        Random rand = new Random();

        public  string AesEncryptor(string payload, EplexLockManagement ParentForm, bool EncryptIt = true )
        {
            //*************************************************************************************************
            //* Encrypt a string
            //*************************************************************************************************
            if (EncryptIt == false)
            {
                return payload;
            }
            using (var aesAlg = Aes.Create())
            {
                //*************************************************************************************************
                //* Load a random number for the encryprion key base
                //*************************************************************************************************
                rand.NextBytes(IVe);
                //                byte[] IVe = Convert.FromBase64String("12345678901234567890");
                //*************************************************************************************************
                //* Get an encryption key
                //*************************************************************************************************
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, IVe);
                aesAlg.Key = pdb.GetBytes(32);
                aesAlg.IV = pdb.GetBytes(16);
                //*************************************************************************************************
                //* Convert the payload string to an array of bytes
                //*************************************************************************************************
                byte[] cipherBytes = Encoding.Unicode.GetBytes(payload);

                //*************************************************************************************************
                //* Set the encryption parameters
                //*************************************************************************************************
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                //*************************************************************************************************
                //* Invoke encryption
                //*************************************************************************************************
                var encrypted = encryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

                //*************************************************************************************************
                //* Get the encrypted bytes in a local variable
                //*************************************************************************************************
                var BytesOut = aesAlg.IV.Concat(encrypted).ToArray();
                //*************************************************************************************************
                //* Convert the encrypted bytes to a string
                //*************************************************************************************************
                string ReturnStr = Convert.ToBase64String(IVe) + Convert.ToBase64String(BytesOut.ToArray());
                return ReturnStr;
            }
        }
        public  string AesDecryptor(string payload, string encryptionTestString, ref bool IsDataEncrypted, EplexLockManagement ParentForm)
        {
            //*************************************************************************************************
            //* Decrypt a string
            //*************************************************************************************************
            //*************************************************************************************************
            //* This looks for the field delimiter in the payload. If it's there, the file is not encrypted
            //*************************************************************************************************
            if (payload.IndexOf(encryptionTestString) > -1)
            {
                IsDataEncrypted = false;
                return payload;
            }
            //*************************************************************************************************
            //* Set the encryption flag for the caller
            //*************************************************************************************************
            IsDataEncrypted = true;
            using (var aesAlg = Aes.Create())
            {
                //*************************************************************************************************
                //* Pull the encryption key out of the first 20 bytes of the payload data
                //*************************************************************************************************
                byte[]IVe = Convert.FromBase64String(payload.Substring(0, 20));
                //*************************************************************************************************
                //* Get rid of the encryption key base out of the payload data
                //*************************************************************************************************
                string cipherText = payload.Substring(20).Replace(" ", "+");
                //*************************************************************************************************
                //* Convert the payload from a string to an array of bytes
                //*************************************************************************************************
                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                
                //*************************************************************************************************
                //* Build the encryiption key
                //*************************************************************************************************
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, IVe);
                aesAlg.Key = pdb.GetBytes(32);
                aesAlg.IV = pdb.GetBytes(16);

                //*************************************************************************************************
                //* Set the encryption parameters
                //*************************************************************************************************
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;
                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                //*************************************************************************************************
                //* Invoke encryption
                //*************************************************************************************************
                var BytesOut = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                //*************************************************************************************************
                //* Convert the encrypted bytes to a string
                //*************************************************************************************************
                string ReturnStr = Encoding.Unicode.GetString(BytesOut.ToArray());
                //*************************************************************************************************
                //* Had to get rid of 8 bytes of junk. Don't understand it, or I'd explain further
                //*************************************************************************************************
                ReturnStr = ReturnStr.Substring(8);
                return ReturnStr;
            }
        }
    }
}
