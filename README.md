# FlashForgeMonitor
Monitoring &amp; control software for FlashForge 3D Printers


# Features
-  Supports all (wifi capable) FlashForge printers, allowing full control from any computer without proprietary software
-  Supports stock FlashForge firmware, as well as Klipper (through Moonraker)
-  Starting, Pausing, and Resuming prints, as well as displaying various print information (temps, time elapsed/left, filament used, fan speeds, etc.)
-  Can be used stand-alone as a simple monitor/control panel, or used to build your own UI or API (ai failure detection, discord notifications, etc.)

# Tested Printers / Support
For Klipper firmware, this is designed to work with [unofficial firmware](https://github.com/xblax/flashforge_ad5m_klipper_mod). Support for other custom klipper firmwares can be added upon request

For FlashForge firmware, most should work without any modifications. Some gcodes may differ between versions/editions. 

If your printer cannot communicate wirelessly, this won't work for you.

- Adventurer 5M/Pro : Full support


# Credits
https://github.com/Slugger2k/FlashForgePrinterApi - A good portion of the stock firmware API is based off this work

https://reprap.org/wiki/G-code - Great documentation of 3D printer gcodes

# Examples
Basic Moonraker control panel
![moonrakerui](https://github.com/CopeTypes/FlashForgeMonitor/assets/106415648/20bb9753-a780-4520-a7fb-73f9fe75ef44)
