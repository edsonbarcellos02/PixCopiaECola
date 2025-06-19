using System;
using System.Text;

public class QRCode
{
    public static string CalculaCRC16(string value)
    {
        ushort resultado = 0xFFFF;
        byte[] bytes = Encoding.ASCII.GetBytes(value);

        foreach (byte b in bytes)
        {
            resultado ^= (ushort)(b << 8);
            for (int j = 0; j < 8; j++)
            {
                if ((resultado & 0x8000) != 0)
                {
                    resultado = (ushort)((resultado << 1) ^ 0x1021);
                }
                else
                {
                    resultado <<= 1;
                }
                resultado &= 0xFFFF;
            }
        }
        return resultado.ToString("X4");
    }
}