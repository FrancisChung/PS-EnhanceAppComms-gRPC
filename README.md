# PS-EnhanceAppComms-gRPC
Pluralsight - Enhance Application Communications with gRPC (https://www.pluralsight.com/courses/grpc-enhancing-application-communication)


Extra bits you may need to get it running :

1) Code Gen (Server / Don't forget to replace <<Your User Name>> in the arguments)
  
protoc -I ..\..\pb --csharp_out Messages ..\..\pb\messages.proto --grpc_out Messages --plugin=protoc-gen-grpc="C:\Users\<<Your User Name>>\.nuget\packages\grpc.tools\2.25.0\tools\windows_x64\grpc_csharp_plugin.exe"


2) Certs : OpenSSL Certs
https://stackoverflow.com/questions/37714558/how-to-enable-server-side-ssl-for-grpc/37739265#37739265
