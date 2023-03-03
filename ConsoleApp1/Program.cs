using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

var client = new HttpClient();
var sequence = File.ReadAllText("sequence.txt");
var signatureBase64 = File.ReadAllText("signature.txt.base64");
var signatureBytes = Convert.FromBase64String(signatureBase64);
var content = new MultipartFormDataContent();
content.Add(new StringContent(sequence));
content.Add(new ByteArrayContent(signatureBytes), "signature", "signature.bin");
var response = await client.PostAsync("https://staging-a-bon.aircash.eu/rest/api/CashRegister/CreateCoupon", content);

if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Succesful post");
}
else
{
    Console.WriteLine($"Failed post\n {response.StatusCode}");
}
Console.WriteLine(response);
Console.ReadLine();
