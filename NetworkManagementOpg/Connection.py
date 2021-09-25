# -*- coding: utf-8 -*-
"""
Created on Fri Sep 24 12:43:22 2021

@author: Benjamin Roesdal
"""

from netmiko import ConnectHandler

def CreateConnection():
    cisco1 = {
        "device_type": "cisco_ios",
        "host": "10.10.1.1",
        "username": "cisco",
        "password": "class",
        "secret": "class"
    }
    
    deviceConnection = ConnectHandler(**cisco1)
    deviceConnection.enable()
    return deviceConnection