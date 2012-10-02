using System;

namespace QuickWin.Cms.Util.Security.Interfaces
{
    public interface IHashHelper
    {
        String HashString(String input);
        Boolean VerifyHash(String plainText, String hashedText);
    }
}