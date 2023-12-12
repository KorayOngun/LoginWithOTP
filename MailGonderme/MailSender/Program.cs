using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Net.Mail;
using System.Net;
using System.Runtime;
using System.Text;
using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 5672
        };
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        channel.QueueDeclare("Email", exclusive: false, autoDelete: false);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += Consumer_Received;

        while (true)
        {
            channel.BasicConsume(queue:"Email", consumer:consumer);
        }


        void Consumer_Received(object? sender, BasicDeliverEventArgs e)
        {
            var body = e.Body.ToArray();
            var strData = Encoding.UTF8.GetString(body);
            var data = JsonSerializer.Deserialize<OtpClaimWithMail>(strData);
            Console.WriteLine(strData);
            SendMail(data.EMail, data.Otp.ToString());
            channel.BasicAck(e.DeliveryTag, false);
        }

        void SendMail(string to,string message)
        {
            using (SmtpClient client = new SmtpClient())
            using (MailMessage mailMessage = new MailMessage())
            {
                client.Credentials = new NetworkCredential("-", "-");
                client.Port = 587;
                client.Host = "smtp.office365.com";
                client.EnableSsl = true;

                mailMessage.From = new MailAddress("botgg28@hotmail.com");
                mailMessage.Subject = "OTP";
                mailMessage.Body = message;
                mailMessage.To.Add(to);

                client.Send(mailMessage);
            }
        }
    }

    
}
public class OtpClaimWithMail
{
    public string EMail { get; set; }
    public int Otp { get; set; }
}
