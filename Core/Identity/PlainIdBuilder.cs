using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace KUBC.DAYZ.Identity;

/// <summary>
/// Инструмент расчета PlainID
/// </summary>
public class PlainIdBuilder
{
    /// <summary>
    /// Построить идентификатор игрока в DAYZ
    /// </summary>
    /// <param name="steamId">Идентификатор в STEAM</param>
    /// <returns>DAYZ ID</returns>
    public static string Build(Int64 steamId)
    {
        string sID = steamId.ToString();
        var chars = sID.ToCharArray();
        byte[] bytes = new byte[chars.Length];
        for (int i = 0; i < chars.Length; i++)
            bytes[i] = (byte)chars[i];

        var sha = SHA256.Create();


        var binaryData = sha.ComputeHash(bytes);
        long arrayLength = (long)((4.0d / 3.0d) * binaryData.Length);
        if (arrayLength % 4 != 0)
        {
            arrayLength += 4 - arrayLength % 4;
        }
        char[] base64CharArray = new char[arrayLength];
        System.Convert.ToBase64CharArray(binaryData,
                            0,
                            binaryData.Length,
                            base64CharArray,
                            0);
        string DAYZID = string.Empty;
        foreach (var c in base64CharArray)
        {
            DAYZID += c switch
            {
                '+' => '-',
                '/' => "_",
                _ => c,
            };
        }
        return DAYZID;
    }
}
