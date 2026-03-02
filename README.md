# ServerTime Plugin for CounterStrikeSharp / CS2
<img width="551" height="190" alt="image" src="https://github.com/user-attachments/assets/fb9b8862-1f78-49a7-9ed2-a3bacdd3d110" />
 
**Version:** 1.0.0  
**Minimum CSS API Version:** 360  

## Description

ServerTime is a simple CounterStrikeSharp plugin that displays the server’s current time in chat.  
It supports multiple commands, configurable time format, and colored chat messages with a visible prefix.

- Shows the server’s real time (dedicated machine time)
- Works on Linux and Windows
- Supports custom commands and messages
- Displays separators for visibility

## Features

- Multiple commands: !time, !ora, !thetime  
- Customizable message with {time} placeholder  
- Chat colors: [ServerTime] green, time yellow  
- Optional separators in chat

## Installation

1. Download plugin to your server.  
```addons/counterstrikesharp/plugins/ServerTime/```

3. Start or restart the server.  
4. The config JSON is automatically created at:
 ```addons/counterstrikesharp/configs/ServerTimePlugin.json```

## Configuration

Default `ServerTimePlugin.json`:

```json
{
  "Commands": ["css_time","css_ora","css_thetime"],
  "TimeZone": "",
  "TimeFormat": "HH:mm:ss",
  "Message": "Server time: {time}",
  "Version": 1
}
```
- Commands – list of commands players can use
- TimeZone – leave empty to show server’s real time
- TimeFormat – .NET DateTime format
- Message – text with {time} placeholder
- Version – config version
