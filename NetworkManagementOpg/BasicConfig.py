# -*- coding: utf-8 -*-
"""
Created on Fri Sep 24 12:37:36 2021

@author: Benjamin Roesdal
"""

from Connection import *

#Configures hostname with a prepared command, which gets user input appended to it.
#Saves config
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
        
#Configures banner motd with user input appended to the first command, the last # then gets appended after
# user input is done, to ensure the syntax is correct
#Saves config
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

#Configures console password with user input appended to the 'password' command
#Also sends 'login' command after password command has been entered.
#Saves config aswell
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