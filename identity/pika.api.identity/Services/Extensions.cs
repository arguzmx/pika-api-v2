﻿using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace pika.api.identity.Services
{
    public static class Extensions
    {

        /// <summary>
        /// Genera dos certificados con duraci+on de 10 año s sin cotnraseña para la firma y certificación de JWT
        /// </summary>
        /// <param name="SigningCertificate"></param>
        /// <param name="EncryptionCertificate"></param>
        public static void GeneraClaves(string SigningCertificate, string EncryptionCertificate)
        {
            EncryptionKey(EncryptionCertificate);
            SigningKey(SigningCertificate);
        }

        /// <summary>
        /// Genera el certificado para el cifrado de JWT
        /// </summary>
        /// <param name="EncryptionCertificate"></param>
        /// <returns></returns>
        private static string EncryptionKey(string EncryptionCertificate)
        {
            
            using var algorithm = RSA.Create(keySizeInBits: 2048);

            var subject = new X500DistinguishedName("CN=PIKA Identity Encryption Certificate");
            var request = new CertificateRequest(subject, algorithm, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.KeyEncipherment, critical: true));

            var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(10));

            File.WriteAllBytes(EncryptionCertificate!, certificate.Export(X509ContentType.Pfx, string.Empty));

            return EncryptionCertificate!;
        }


        /// <summary>
        /// Genera el certificado para la firma de JWT
        /// </summary>
        /// <param name="SigningCertificate"></param>
        /// <returns></returns>
        private static string SigningKey(string SigningCertificate)
        {
            
            using var algorithm = RSA.Create(keySizeInBits: 2048);

            var subject = new X500DistinguishedName("CN=PIKA Identity Signing Certificate");
            var request = new CertificateRequest(subject, algorithm, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            request.CertificateExtensions.Add(new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature, critical: true));

            var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(10));

            File.WriteAllBytes(SigningCertificate!, certificate.Export(X509ContentType.Pfx, string.Empty));

            return SigningCertificate!;
        }
    }
}
