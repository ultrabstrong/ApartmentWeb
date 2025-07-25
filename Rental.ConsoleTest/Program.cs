﻿using Rental.Domain.Core;
using Rental.Domain.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Rental.ConsoleTest;

partial class Program
{
#pragma warning disable IDE0052 // Remove unread private members
    static readonly string DesktopLoc = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
    static readonly string DownloadsLoc = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";
#pragma warning restore IDE0052 // Remove unread private members

    static void Main()
    {
        try
        {
            TestHTMLtoPDF();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception caught:{Environment.NewLine}{ex}");
        }
        Console.WriteLine("Program finished. Press any key to exit");
        Console.ReadKey();
    }

    static void TestEmailRegex()
    {
        var reg = EmailTestRegex();
        var email = "ultrabstrong@gmail.com";
        Console.WriteLine(reg.IsMatch(email));
    }

    static void TestHTMLtoPDF()
    {
        var filepath = $"{DownloadsLoc}sample.html";
        var outpath = $"{DownloadsLoc}sample.pdf";
        var html = File.ReadAllText(filepath);
        var pdfBytes = HtmlToPdfConverter.GetPdfBytes(html, "Rental.WebApp.ConsoleTest", "Sample PDF", "This is a sample PDF generated from HTML");

        if (File.Exists(outpath))
        { File.Delete(outpath); }
        using (FileStream fs = new(outpath, FileMode.Create, FileAccess.ReadWrite))
        {
            fs.Write(pdfBytes, 0, pdfBytes.Length);
            fs.Flush();
        }
    }


    static void TestMail()
    {
        MailSettings settings = new()
        {
            SMTPServer = "",
            SMTPUsername = "",
            SMTPPw = "",
            SMTPPort = 587,
            SMTPTo = ""
        };

        using (var smtpClient = new SmtpClient(settings.SMTPServer)
        {
            Port = settings.SMTPPort,
            Credentials = new NetworkCredential(settings.SMTPUsername, settings.SMTPPw),
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network
        })
        {
            MailMessage message = new()
            {
                Subject = $"test subject",
                From = new MailAddress(settings.SMTPUsername),
                Body = $"test body",
                IsBodyHtml = false,
                To = { settings.SMTPTo }
            };

            smtpClient.Send(message);
        }
    }

    [GeneratedRegex(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
    private static partial Regex EmailTestRegex();
}
