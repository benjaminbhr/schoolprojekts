# -*- coding: utf-8 -*-
"""
Created on Fri Sep 24 12:44:31 2021

@author: Benjamin Roesdal
"""

from Connection import *

def ShowAllInterfaces():
    with CreateConnection() as net_connect:
            command = "show ip interface brief"
            output = net_connect.send_command(command,use_textfsm=True)
            net_connect.disconnect
            return output

def ConfigureIpAddressOnInterface(interfaceName,ipAddress,subnetMask):
    with CreateConnection() as net_connect:
            ipaddress = ipAddress + " " + subnetMask
            commands = ["interface " + interfaceName, "ip address " + ipaddress]
            output = net_connect.send_config_set(commands)
            net_connect.disconnect
            return output