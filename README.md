# PS-EnhanceAppComms-gRPC
Pluralsight - Enhance Application Communications with gRPC


Code Gen (Server / Don't forget to replace <<Your User Name>> in the arguments)
  
protoc -I ..\..\pb --csharp_out Messages ..\..\pb\messages.proto --grpc_out Messages --plugin=protoc-gen-grpc="C:\Users\<<Your User Name>>\.nuget\packages\grpc.tools\2.25.0\tools\windows_x64\grpc_csharp_plugin.exe"


Certs : OpenSSL Certs
https://stackoverflow.com/questions/37714558/how-to-enable-server-side-ssl-for-grpc/37739265#37739265
