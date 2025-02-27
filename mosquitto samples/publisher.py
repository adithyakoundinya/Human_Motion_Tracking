#!/usr/bin/env python
# -*- coding: utf-8 -*-
""" 
Publish some messages to queue
"""
import paho.mqtt.publish as publish


msgs = [{'topic': "kids/yolo", 'payload': "jump"},
        {'topic': "sample/1", 'payload': "some photo"},
        {'topic': "sample/2", 'payload': "extra extra"},
        {'topic': "sample/2", 'payload': "super extra"}]

host = "localhost"


if __name__ == '__main__':
    # publish a single message
    publish.single(topic="kids/yolo", payload="just do it", hostname=host)

    # publish multiple messages
    publish.multiple(msgs, hostname=host)


# vi: set fileencoding=utf-8 :
