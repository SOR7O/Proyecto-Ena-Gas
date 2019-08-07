using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PROJECT_ENA_GAS
{
    class EncriptarClass1
    {
        string key = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";

        public string EcryptKey(string str)
        {/*
             byte[] keyArray;
             byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena);
             MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
             keyArray = mD5CryptoServiceProvider.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
             mD5CryptoServiceProvider.Clear();
             TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
             tripleDESCryptoServiceProvider.Key = keyArray;
             tripleDESCryptoServiceProvider.Mode = CipherMode.ECB;
             tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
             ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
             byte[] arrayResultado = cryptoTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
             tripleDESCryptoServiceProvider.Clear();

             return Convert.ToBase64String(arrayResultado, 0, arrayResultado.Length);
         */
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}

