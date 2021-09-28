# -*- coding: utf-8 -*-
"""
Created on Fri Sep 24 12:44:31 2021

@author: Benjamin Roesdal
"""

from Connection import *

#This function sends the 'Show ip interface brief' command to the router, and outputs in result in console.
def ShowAllInterfaces():
    with CreateConnection() as net_connect:
            command = "show ip interface brief"
            output = net_connect.send_command(command,use_textfsm=True)
            net_connect.disconnect
            return output

#This function takes 3 arguments, InterfaceName, IpAdr and Subnet mask
#All commands are already prepared, so the user input is only appended to the prepared commands.
def ConfigureIpAddressOnInterface(interfaceName,ipAddress,subnetMask):
    with CreateConnection() as net_connect:
            ipaddress = ipAddress + " " + subnetMask
            commands = ["interface " + interfaceName, "ip address " + ipaddress]
            output = net_connect.send_config_set(commands)
            output += net_connect.save_config()
            net_connect.disconnect
            return output