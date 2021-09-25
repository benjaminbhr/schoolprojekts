# -*- coding: utf-8 -*-
"""
Created on Tue Sep 21 12:14:11 2021

@author: Benjamin Roesdal
"""

from BasicConfig import *
from InterfaceConfig import *
from SnmpTrafficAnalyzer import *

def TextFSMToObject(textfsm):
    objects = []
    for x in textfsm:
        intObj = InterfaceObj(x["intf"], x["ipaddr"], x["status"], x["status"])
        objects.append(intObj)
    return objects

class InterfaceObj():
    def __init__ (self, name,ipAdd,status,proto):
        self.name = name
        self.ipAdd = ipAdd
        self.status = status
        self.proto = proto

def BasicConfiguration():
    running = True
    while running:
        print("Welcome To basic Router Config")
        print("Press (1) To configure hostname")
        print("Press (2) To configure banner MOTD")
        print("Press (3) To configure console password")
        print("Press (9) To Exit the program")
        userInput = input()
        if userInput == "1":
            print(ConfigureHostname())
            input("Press 'Enter' to return to the menu")
        elif userInput == "2":
            print (ConfigureBannerMotd())
            input("Press 'Enter' to return to the menu")
        elif userInput == "3":
            print (ConfigureConsolePassword())
            input("Press 'Enter' to return to the menu")
        elif userInput == "9":
            running = False
            
def InterfaceConfiguration():
    running = True
    while running:
        print("Welcome to Interface config")
        print("Press (1) to see all interfaces")
        print("Press (2) to configure an interface")
        print("Press (9) to exit")
        userInput = input()
        if userInput == "1":
            objs = TextFSMToObject(ShowAllInterfaces())
            for y in objs:
                print(y.name,y.ipAdd,y.proto,y.status)
        elif userInput == "2":
            objs = TextFSMToObject(ShowAllInterfaces())
            for y in objs:
                print("[" + str(objs.index(y)) + "] ",y.name,y.ipAdd,y.proto,y.status)
            interfaceIndex = int(input("Enter the number to the left of the interface you want to configure: "))
            ipAddress = input("Enter the IpAddress you would like on this interface: ")
            subnet = input("Enter the Subnet mask you would like on this interface: ")
            output = ConfigureIpAddressOnInterface(objs[interfaceIndex].name, ipAddress, subnet)
            print(output)
        elif userInput == "9":
            running = False
            

running = True
while running:
    print("Welcome to Router Configuration Program")
    print("Press (1) to enter basic router config")
    print("Press (2) to enter interface config")
    print("Press (3) to see traffic on router")
    print("Press (9) to exit")
    userInput = input()
    if userInput == "1":
        BasicConfiguration()
    elif userInput == "2":
        InterfaceConfiguration()
    elif userInput == "3":
        print("Hold 'C' to stop")
        MonitorTrafficOnRouter()
    elif userInput == "9":
        running = False
    