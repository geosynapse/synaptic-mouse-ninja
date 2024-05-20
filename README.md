# Mouse Ninja: The Mouse Jiggler Reimagined

## Overview

Welcome to **Synaptic Mouse Ninja**—a cheeky evolution of the venerable [Mouse Jiggler](https://github.com/arkane-systems/mousejiggler) by the legendary *arkane-systems*. This isn't just a mere fork; it's a whole new beast. We've taken the core idea, given it a fresh coat of WPF, refactored the heck out of it, and tossed out the ancient User32 dependency. The result? A sleeker, more secure, and less detectable solution for your mouse-jiggling needs.

Kudos and unending praise to *arkane-systems* for the original brilliance. We stand on the shoulders of giants.

## Warning

Mouse Ninja is dark hack code for **educational purposes only**. Seriously, don't use this in an office environment unless you're really itching for a conversation with your IT department. Use responsibly!

## Features

- **WPF Magic**: Enjoy the modern, pretty interface that only WPF can provide.
- **No User32**: We've exorcised the old User32 dependency, making Mouse Ninja more secure and stealthy.
- **Same Great Functionality**: Keeps your screen awake and idle detectors at bay, just like the original.

## Installation

Getting started with Mouse Ninja is simple:

1. **Clone the Repo**:
   ```
   git clone https://github.com/geosynapse/synaptic-mouse-ninja.git
   ```
2. **Build the Solution**: Open the solution in Visual Studio and hit that build button.

## Usage

Fire up Mouse Ninja and keep your mouse in perpetual motion. Here's the rundown:

1. **Run the App**: Launch `GeoSynapse.Ninja.exe`.
2. **Start Jiggling**: Check the "Jiggling?" checkbox to begin.
3. **Zen Mode**: Enable "Zen jiggle?" to jiggle the mouse without actually moving the pointer. (Warning: May not work with all idle detection systems).

Command-line options are also available for the power users out there:

```
Usage:
  GeoSynapse.MouseNinja [options]

Options:
  -j, --jiggle               Start with jiggling enabled.
  -m, --minimized            Start minimized. [default: False]
  -z, --zen                  Start with zen jiggling enabled. [default: False]
  -s, --seconds <seconds>    Set jiggle interval in seconds. [default: 1]
  --version                  Show version information.
  -?, -h, --help             Show help and usage information.
```

## Bugs & Quirks

- **Command-line Help**: If you encounter issues with command-line help when installed via certain methods, refer to our detailed [installation guide](#installation).

## Not Happening

To save you some time, here are features you won't find in Mouse Ninja:

- **Autorun on Startup**: Use the Startup folder or Task Scheduler.
- **Timed Startup/Shutdown**: That's what Task Scheduler is for, folks.

## Support

Mouse Ninja is a labor of love, offered as-is, without warranty or support. If it breaks, you get to keep both pieces.

## License

Mouse Ninja is licensed under the MIT License. See `LICENSE.md` for more details.


MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.