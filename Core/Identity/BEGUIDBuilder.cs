using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace KUBC.DAYZ.Identity;

/// <summary>
/// Строитель BEGUID игрока
/// </summary>
public class BEGUIDBuilder
{
    /// <summary>
    /// Рассчитать BEGUID
    /// </summary>
    /// <param name="steamId">SteamID игрока</param>
    /// <returns></returns>
    public static Guid Build(Int64 steamId)
    {
        byte[] parts = { 0x42, 0x45, 0, 0, 0, 0, 0, 0, 0, 0 };
        byte counter = 2;
        do
        {
            parts[counter++] = (byte)(steamId & 0xFF);
        } while ((steamId >>= 8) > 0);

        MD5 md5 = MD5.Create();
        byte[] beHash = md5.ComputeHash(parts);
        var sb = new StringBuilder();
        for (int i = 0; i < beHash.Length; i++)
            sb.Append(beHash[i].ToString("x2"));
        return Guid.Parse(sb.ToString());
    }
}
