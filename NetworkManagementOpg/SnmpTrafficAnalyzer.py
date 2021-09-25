# -*- coding: utf-8 -*-
"""
Created on Fri Sep 24 12:51:41 2021

@author: Benjamin Roesdal
"""

from pysnmp import hlapi
import matplotlib.pyplot as plt
import keyboard
from datetime import datetime
import time

#This function is used to get the oid values from the device.
def get(target, oids, credentials, port=161, engine=hlapi.SnmpEngine(), context=hlapi.ContextData()):
    handler = hlapi.getCmd(
        engine,
        credentials,
        hlapi.UdpTransportTarget((target, port)),
        context,
        *construct_object_types(oids)
    )
    return fetch(handler, 1)[0]

#Uses hlapi to construct the correct object types
def construct_object_types(list_of_oids):
    object_types = []
    for oid in list_of_oids:
        object_types.append(hlapi.ObjectType(hlapi.ObjectIdentity(oid)))
    return object_types

#used to fetch the desired data, 
def fetch(handler, count):
    result = []
    for i in range(count):
        try:
            error_indication, error_status, error_index, var_binds = next(handler)
            if not error_indication and not error_status:
                for var_bind in var_binds:
                    result.append(cast(var_bind[1]))
            else:
                raise RuntimeError('Got SNMP error: {0}'.format(error_indication))
        except StopIteration:
            break
    return result

#trying to cat to a desired value, in my case i know it will always be an int
def cast(value):
    try:
        return int(value)
    except (ValueError, TypeError):
        try:
            return float(value)
        except (ValueError, TypeError):
            try:
                return str(value)
            except (ValueError, TypeError):
                pass
    return value


#This function creates a get call to a device on a specific OID which provides an integer
#describing the delivered datagram inputs, and plots this into a graph.
#It is possible to exit this loop by holding down "C"
def MonitorTrafficOnRouter():
    running = True
    # X axis values:
    x = []
    # Y axis values:
    y = []
    while running :
        if keyboard.is_pressed('c'):
            running = False
        trafficValue = int(get('10.10.1.1', ['.1.3.6.1.2.1.4.9.0'], hlapi.CommunityData('cisco')))
        timeint = datetime.now()
        currentTime = datetime.strftime(timeint, "%H:%M:%S")
        x.append(currentTime)
        y.append(trafficValue)
        plt.plot(x, y)
        plt.show()
        time.sleep(0.5)