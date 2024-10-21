using System.ServiceModel;
using Microsoft.AspNetCore.Authentication;
using SoapApi;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddSingleton<IMySoapService, MySoapService>();
builder.Services.AddMvc();

// Add basic authentication
builder.Services.AddAuthentication("BasicAuthentication")
        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
    
var app = builder.Build();



app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<AuthenticationCheckMiddleware>();

app.UseSoapEndpoint<IMySoapService>(path: "/ServicePath.asmx", 
    encoder: new SoapEncoderOptions()
    // caseInsensitivePath: false
    // serializer: SoapSerializer.DataContractSerializer, 
    // soapModelBounder: null
    // wsdlFileOptions: null
    // indentXml: true, 
    // omitXmlDeclaration: true
);



app.Run();
