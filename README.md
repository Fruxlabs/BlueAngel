BlueAngel : The improved "Ransomware" Simulator
==================
Based on cashcat, this is an improvement over it and intends to make it a bit more sophisticated.

## VERY IMPORTANT NOTE
THIS IS **NOT** REAL RANSOMWARE! IT LITERALLY DOES NOT MATCH ANY REAL DEFINITION OF RANSOMWARE! ALL IT DOES IS RENAME files with the extension of .TXT to .LOCKY to test file activity monitoring tools. Nothing gets Encrypted!

## Requirements
+ Tested on Windows 7, 10, Server 2012R2, 2016+ 
+ Requires at least .NET 4.6.1

## Configuration
BlueAngel has some basic configuration options! Simply place a json file named "BlueAngel.Json" in the directory alongside the executable to unlock a number of functions:

```
{
    "webHookEnabled":  0,
    "webHookURI":  "http://URIGORESHERE.COM",
}

```
**Options**
* webHookEnabled - instructs BlueAngel to execute a GET webhook execution on open
* webHookURI - Webhook URI to be called
