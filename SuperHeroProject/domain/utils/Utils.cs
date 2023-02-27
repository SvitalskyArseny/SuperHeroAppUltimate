using System;

namespace SuperHeroProject.domain.utils
{
    public static class Utils
    {
        public static string GetNewId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}