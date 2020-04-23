Cashcat : The "Ransomware" Simulator
==================
A little "ransomware-like" simulator for Windows that will rename .TXT files to .LOCKY to simulate ransomware behavior for demos and testing various file monitoring tools and response systems. 

## VERY IMPORTANT NOTE
THIS IS **NOT** REAL RANSOMWARE! IT LITERALLY DOES NOT MATCH ANY REAL DEFINITION OF RANSOMWARE! ALL IT DOES IS RENAME files with the extension of .TXT to .LOCKY to test file activity monitoring tools. Nothing gets Encrypted!

## Requirements
+ Tested on Windows 7, 10, Server 2012R2, 2016+ 
+ Requires at least .NET 4.6.1

## Configuration
CashCat has some basic configuration options! Simply place a json file named "BlueAngel.Json" in the directory alongside the executable to unlock a number of functions:

```
{
    "webHookEnabled":  0,
    "webHookURI":  "http://URIGORESHERE.COM",
    "catMode":  0
}

```
**Options**
* webHookEnabled - instructs CashCat to execute a GET webhook execution on open
* webHookURI - Webhook URI to be called
