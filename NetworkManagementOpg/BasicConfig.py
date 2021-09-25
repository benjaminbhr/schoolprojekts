# -*- coding: utf-8 -*-
"""
Created on Fri Sep 24 12:37:36 2021

@author: Benjamin Roesdal
"""

from Connection import *

def ConfigureHostName():
    with CreateConnection() as net_connect:
            hostname = input("Indtast et hostname: ")
            command = "hostname " + hostname
            commands = []
            command += hostname
            commands.append(command)
            output = net_connect.send_config_set(commands,cmd_verify = False)
            output += net_connect.save_config()
            net_connect.disconnect
            return output
        
def ConfigureBannerMotd():
    with CreateConnection() as net_connect:
            banner = input("Indtast det ønskede Banner MOTD: ")
            command = "banner motd #"
            commands = []
            command += banner + "#"
            commands.append(command)
            output = net_connect.send_config_set(commands, cmd_verify = False)
            output += net_connect.save_config()
            net_connect.disconnect
            return output

def ConfigureConsolePassword():
    with CreateConnection() as net_connect:
            pw = input("Indtast det ønskede Console Password: ")
            command = "password "
            commands = ["line console 0"]
            command += pw
            commands.append(command)
            commands.append("login")
            output = net_connect.send_config_set(commands, cmd_verify = False)
            output += net_connect.save_config()
            net_connect.disconnect
            return output