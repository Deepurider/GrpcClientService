using Grpc.Net.Client;
using GrpcService1;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder().
    SetBasePath(Directory.
    GetCurrentDirectory()).
    AddJsonFile("appsettings.json").Build();
var httpHandler = new HttpClientHandler();
// Return `true` to allow certificates that are untrusted/invalid  
httpHandler.ServerCertificateCustomValidationCallback =
    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

string serviceUrl = config.GetSection("ServiceUrl").Value ?? "";
var channel = GrpcChannel.ForAddress(serviceUrl , new GrpcChannelOptions() { HttpHandler = httpHandler});


var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(new HelloRequest { Name = "Patel Deep" });
Console.WriteLine(reply.Message);

var submitClient = new Submit.SubmitClient(channel);
var submitReply = await submitClient.RunSubmitAsync(new SubmitRequest() {Message = "This is from client with submit request" });
Console.WriteLine(submitReply.Message);
Console.ReadKey();  
