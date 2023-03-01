﻿using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Common
{
    public class EmailGenerator
    {
        public static void SendEmail(string to, string subject, string message, bool IsHtml)
        {
            try
            {

                MailAddress from = new MailAddress("anastinashalomi@gmail.com", "Ceat");
                MailAddress toNew = new MailAddress(to);


                MailMessage mail = new MailMessage(from, toNew);
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = IsHtml;


                using (SmtpClient sc = new SmtpClient("smtp.gmail.com", 587))
                {

                    sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                    sc.Credentials = new NetworkCredential("anastinashalomi@gmail.com", "1969020506*");
                    sc.EnableSsl = true;
                    sc.UseDefaultCredentials = false;

                    sc.Send(mail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static string getTitle()
        {
            //if (orderStatus == "2")
            //{
            //    return "Dear " + Cname + ", Your Order Is Being Processed";
            //}
            //else if (orderStatus == "3")
            //{
            //    return "Dear " + Cname + ", Your Order Is Ready To Pickup";
            //}
            //else if (orderStatus == "4")
            //{
            //    return "Dear " + Cname + ", Your Order Was Successfully Dispatched";
            //}
            //else if (orderStatus == "5")
            //{
            //    return "Dear " + Cname + ", Your Order Has Been Delivered";
            //}
            //else
            //{
            return "Dear customer You can reset password using this link";
            //}

        }

        public static StringBuilder getEmailBody()
        {
            StringBuilder EmailBody = new StringBuilder();

            EmailBody.Append("<center><table width='620' cellspacing='0' cellpadding='10' border='3' style='border-color: rgb(97, 97, 97); align='center'><tbody><tr><td align='center'><div><img src='");
            EmailBody.Append("http://webuat-sathosa.lankasathosa.lk/images/logo.png");
            EmailBody.Append("'");

            //if (orderStatus == 2)
            //{

            //    /*image*/
            //    EmailBody.Append("alt='img' height='150' width='auto'></div></td></tr><tr><td align='center'><div><img src='");
            //    EmailBody.Append("http://webuat-sathosa.lankasathosa.lk/images/EmailIcons/1st%20step.svg");
            //    EmailBody.Append("'");
            //    EmailBody.Append("alt='img' height='150' width='auto'></div></td></tr><tr>");
            //    /*message */
            //    EmailBody.Append("<td valign='middle' height='50' align='left' style='text-align:center; background-color:#0aa1cf'><h1 style='font-family:arial,sans-serif;'>");
            //    EmailBody.Append("Your Order Is Being Processed");
            //    EmailBody.Append("</h1></td></tr><tr>");
            //    /*footer*/
            //    EmailBody.Append("<td width='465' valign='middle' height='50' align='left' style='background-color:#f0c176 '>");
            //    EmailBody.Append("<p style='font-weight:normal;font-size:20px;color:rgb(90, 90, 90);margin-left:6px;font-family:arial,sans-serif; text-align:center'>");
            //    EmailBody.Append("This email was sent by: orders@lankasathosa.org <br> For any questions please send an email to orders@lankasathosa.org");
            //    EmailBody.Append("</p></td></tr></tbody></table></center>");

            //    return EmailBody;
            //}

            //else if (orderStatus == 3)
            //{
            //    /*@*image *@*/
            //    EmailBody.Append("alt='img' height='150' width='auto'></div></td></tr><tr><td align='center'><div><img src='");
            //    EmailBody.Append("http://webuat-sathosa.lankasathosa.lk/images/EmailIcons/2nd%20step.svg");
            //    EmailBody.Append("'");
            //    EmailBody.Append("alt='img' height='150' width='auto'></div></td></tr><tr>");
            //    /*@*message *@*/
            //    EmailBody.Append("<td valign='middle' height='50' align='left' style='text-align:center; background-color:#0aa1cf'><h1 style='font-family:arial,sans-serif;'>");
            //    EmailBody.Append("Your Order Is Ready To Pickup");
            //    EmailBody.Append("</h1></td></tr><tr>");
            //    /*@*footer *@*/
            //    EmailBody.Append("<td width='465' valign='middle' height='50' align='left' style='background-color:#f0c176 '>");
            //    EmailBody.Append("<p style='font-weight:normal;font-size:20px;color:rgb(90, 90, 90);margin-left:6px;font-family:arial,sans-serif; text-align:center'>");
            //    EmailBody.Append("This email was sent by: orders@lankasathosa.org <br> For any questions please send an email to orders@lankasathosa.org");
            //    EmailBody.Append("</p></td></tr></tbody></table></center>");

            //    return EmailBody;

            //}
            //else if (orderStatus == 4)
            //{
            //    /*@*image *@*/
            //    EmailBody.Append("alt='img' height='150' width='auto'></div></td></tr><tr><td align='center'><div><img src='");
            //    EmailBody.Append("http://webuat-sathosa.lankasathosa.lk/images/EmailIcons/3rd%20step.svg");
            //    EmailBody.Append("'");
            //    EmailBody.Append("alt='img' height='150' width='auto'></div></td></tr><tr>");
            //    /*@*message *@*/
            //    EmailBody.Append("<td valign='middle' height='50' align='left' style='text-align:center; background-color:#0aa1cf'><h1 style='font-family:arial,sans-serif;'>");
            //    EmailBody.Append("Your Order Successfully Dispached");
            //    EmailBody.Append("</h1></td></tr><tr>");
            //    /*@*footer *@*/
            //    EmailBody.Append("<td width='465' valign='middle' height='50' align='left' style='background-color:#f0c176 '>");
            //    EmailBody.Append("<p style='font-weight:normal;font-size:20px;color:rgb(90, 90, 90);margin-left:6px;font-family:arial,sans-serif; text-align:center'>");
            //    EmailBody.Append("This email was sent by: orders@lankasathosa.org <br> For any questions please send an email to orders@lankasathosa.org");
            //    EmailBody.Append("</p></td></tr></tbody></table></center>");

            //    return EmailBody;
            //}
            //else if (orderStatus == 5)
            //{
            //    /*@*image *@*/
            //    EmailBody.Append("alt='img' height='150' width='auto'></div></td></tr><tr><td align='center'><div><img src='");
            //    EmailBody.Append("http://webuat-sathosa.lankasathosa.lk/images/EmailIcons/4th%20step.svg");
            //    EmailBody.Append("'");
            //    EmailBody.Append("alt='img' height='150' width='auto'></div></td></tr><tr>");
            //    /*@*message *@*/
            //    EmailBody.Append("<td valign='middle' height='50' align='left' style='text-align:center; background-color:#0aa1cf'><h1 style='font-family:arial,sans-serif;'>");
            //    EmailBody.Append("Your Order Successfully Delivered");
            //    EmailBody.Append("</h1></td></tr><tr>");
            //    /*@*footer *@*/
            //    EmailBody.Append("<td width='465' valign='middle' height='50' align='left' style='background-color:#f0c176 '>");
            //    EmailBody.Append("<p style='font-weight:normal;font-size:20px;color:rgb(90, 90, 90);margin-left:6px;font-family:arial,sans-serif; text-align:center'>");
            //    EmailBody.Append("This email was sent by: orders@lankasathosa.org <br> For any questions please send an email to orders@lankasathosa.org");
            //    EmailBody.Append("</p></td></tr></tbody></table></center>");

            //    return EmailBody;
            //}

            //else
            //{
            /*@*image *@*/
            EmailBody.Append("alt='img' height='150' width='auto'></div></td></tr><tr><td align='center'><div><img src='");
            EmailBody.Append("http://webuat-sathosa.lankasathosa.lk/images/logo.png");
            EmailBody.Append("'");
            EmailBody.Append("alt='img' height='150' width='auto'></div></td></tr><tr>");
            /*@*message *@*/
            EmailBody.Append("<td valign='middle' height='50' align='left' style='text-align:center; background-color:#0aa1cf'><h1 style='font-family:arial,sans-serif;'>");
            EmailBody.Append("http://ceat-uat-api.melstasoft.com/swagger/ui/index#!/CustomerApi/CustomerApi_updateCustomer");
            EmailBody.Append("</h1></td></tr><tr>");
            /*@*footer *@*/
            EmailBody.Append("<td width='465' valign='middle' height='50' align='left' style='background-color:#f0c176 '>");
            EmailBody.Append("<p style='font-weight:normal;font-size:20px;color:rgb(90, 90, 90);margin-left:6px;font-family:arial,sans-serif; text-align:center'>");
            EmailBody.Append("This email was sent by: orders@lankasathosa.org <br> For any questions please send an email to orders@lankasathosa.org");
            EmailBody.Append("</p></td></tr></tbody></table></center>");

            return EmailBody;
            //}



        }

        public static StringBuilder getEmailBodyForResetPassword(string verificationCode)
        {
            StringBuilder EmailBody = new StringBuilder();
            EmailBody.Append("<p>Dear user,</p>\r\n    <p> Your verification code is:</p>\r\n    <h1 style=\"font-size: 36px; font-weight: bold; color: #007bff;\">");
            EmailBody.Append(verificationCode);
            EmailBody.Append("</h1>\r\n    <p>Please enter this code on the verification page to complete your password reset process.</p>\r\n    <p>Thank you,</p>\r\n    <p>The CEAT Team</p>");
            return EmailBody;
        }
    }
}
