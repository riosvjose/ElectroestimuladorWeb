using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace ElectroestimuladorWeb
{
    // Funciones para el Servicio Web de la aplicacion
    public class Funciones
    {
        public string EliminarCaracteresEspeciales(string pwd)
        {
            string ax;
            ax = pwd.Replace(" ", "");
            ax = ax.Replace("%", "");
            ax = ax.Replace("&", "");
            ax = ax.Replace("'", "");
            ax = ax.Replace("|", "");
            ax = ax.Replace("\"", "");
            return ax;
        }

        public bool CumpleTipoPermitido(int intTipoPersona, int intTipoPermitido)
        {
            bool blCumpleTipo = false;

            if (intTipoPermitido > 0)
            {
                if (((Convert.ToInt16(Math.Pow(2, intTipoPermitido))) & intTipoPersona) == Convert.ToInt16(Math.Pow(2, intTipoPermitido)))
                    blCumpleTipo = true;
            }
            else
                blCumpleTipo = true;

            return blCumpleTipo;
        }

        public static string Encriptar(string texto)
        {
            try
            {
                string key = "csUCBIonicApp#4m1$#94%#"; //llave para encriptar datos
                byte[] keyArray;
                byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(texto);
                //Se utilizan las clases de encriptación MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                //Algoritmo TripleDES
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
                tdes.Clear();
                //se regresa el resultado en forma de una cadena
                texto = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
            }
            catch (Exception)
            {
                texto = string.Empty;
            }
            return texto;
        }

        public static string Desencriptar(string textoEncriptado)
        {
            try
            {
                string key = "csUCBIonicApp#4m1$#94%#"; //llave para desencriptar datos
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(textoEncriptado);

                //algoritmo MD5
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
                tdes.Clear();
                textoEncriptado = UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception)
            {
                textoEncriptado = string.Empty;
            }
            return textoEncriptado;
        }
        /*
         * HorariosMateria
         */
        public string CambiarMinutosChar(int minutos)
        {
            if (minutos <= 0)
                return "00:00";
            else
                return (Math.Truncate(minutos / (double)60)).ToString().PadLeft(2, '0') + ":" + Math.Round((((minutos / (double)60) - Math.Truncate(minutos / (double)60)) * 60), 0).ToString().PadLeft(2, '0');
        }

        public string getMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            Byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            int i;
            for (i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

    }
}