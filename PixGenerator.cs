using System;
using System.Globalization;
using System.Text;

class PixGenerator
{
    static string FormataCampo(string id, string valor)
    {
        return id + valor.Length.ToString("D2") + valor;
    }

    public static string GeraPix(string chave, string idTx = "", decimal valor = 0.00m)
    {
        StringBuilder resultado = new StringBuilder("000201");
        resultado.Append(FormataCampo("26", "0014br.gov.bcb.pix" + FormataCampo("01", chave)));
        resultado.Append("52040000"); // Código fixo
        resultado.Append("5303986");  // Moeda (Real)
        if (valor > 0)
        {
            resultado.Append(FormataCampo("54", valor.ToString("F2", CultureInfo.InvariantCulture)));
        }
        resultado.Append("5802BR"); // País
        resultado.Append("5901N");  // Nome
        resultado.Append("6001C");  // Cidade
        resultado.Append(FormataCampo("62", FormataCampo("05", string.IsNullOrEmpty(idTx) ? "***" : idTx)));
        resultado.Append("6304"); // Início do CRC16
        resultado.Append(QRCode.CalculaCRC16(resultado.ToString())); // Adiciona o CRC16 ao final
        return resultado.ToString();
    }    
}
