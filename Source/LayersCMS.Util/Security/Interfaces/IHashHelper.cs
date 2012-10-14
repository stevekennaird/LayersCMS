using System;

namespace LayersCMS.Util.Security.Interfaces
{
    public interface IHashHelper
    {
        String HashString(String input);
        Boolean VerifyHash(String plainText, String hashedText);
    }
}