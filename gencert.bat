@echo off
set OPENSSL_CONF=C:\Program Files\OpenSSL-Win64\bin\openssl.cfg   

echo Generate CA key:
openssl genrsa -passout pass:grpcDemo -des3 -out ca.key 4096

echo Generate CA certificate:
openssl req -passin pass:grpcDemo -new -x509 -days 365 -key ca.key -out ca.crt -subj  "/C=US/ST=CA/L=Cupertino/O=YourCompany/OU=YourApp/CN=MyRootCA"

echo Generate server key:
openssl genrsa -passout pass:grpcDemo -des3 -out server.key 4096

echo Generate server signing request:
openssl req -passin pass:grpcDemo -new -key server.key -out server.csr -subj  "/C=US/ST=CA/L=Cupertino/O=YourCompany/OU=YourApp/CN=%COMPUTERNAME%"

echo Self-sign server certificate:
openssl x509 -req -passin pass:grpcDemo -days 365 -in server.csr -CA ca.crt -CAkey ca.key -set_serial 01 -out server.crt

echo Remove passphrase from server key:
openssl rsa -passin pass:grpcDemo -in server.key -out server.key

echo Generate client key
openssl genrsa -passout pass:grpcDemo -des3 -out client.key 4096

echo Generate client signing request:
openssl req -passin pass:grpcDemo -new -key client.key -out client.csr -subj  "/C=US/ST=CA/L=Cupertino/O=YourCompany/OU=YourApp/CN=%CLIENT-COMPUTERNAME%"

echo Self-sign client certificate:
openssl x509 -passin pass:grpcDemo -req -days 365 -in client.csr -CA ca.crt -CAkey ca.key -set_serial 01 -out client.crt

echo Remove passphrase from client key:
openssl rsa -passin pass:grpcDemo -in client.key -out client.key