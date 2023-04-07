using System.Security.Cryptography;

namespace QueryHub.Application.Utilities.Security;

public abstract class PasswordHelper
{
    private const int SaltSize = 16; // 128 bits
    private const int HashSize = 32; // 256 bits
    private const int Iterations = 10000; // Number of iterations for PBKDF2

    // Hashes a password with a random salt
    public static string HashPassword(string password)
    {
        var salt = GenerateRandomSalt();
        var hash = HashPasswordWithSalt(password, salt);
        return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
    }

    // Verifies a password against a stored hash
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var parts = hashedPassword.Split(':');
        var salt = Convert.FromBase64String(parts[0]);
        var storedHash = Convert.FromBase64String(parts[1]);

        var hash = HashPasswordWithSalt(password, salt);
        return AreByteArraysEqual(storedHash, hash);
    }

    // Hashes a password with a given salt using PBKDF2
    private static byte[] HashPasswordWithSalt(string password, byte[] salt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
        return pbkdf2.GetBytes(HashSize);
    }

    // Generates a random salt using the RandomNumberGenerator class
    private static byte[] GenerateRandomSalt()
    {
        var salt = new byte[SaltSize];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(salt);
        return salt;
    }

    // Compares two byte arrays for equality
    private static bool AreByteArraysEqual(IReadOnlyCollection<byte> arr1, IReadOnlyList<byte> arr2)
    {
        if (arr1.Count != arr2.Count)
        {
            return false;
        }

        return !arr1.Where((t, i) => t != arr2[i]).Any();
    }
}