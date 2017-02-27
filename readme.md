# Tension Tester
An open source solution for the automated testing of 3D printer filament through the use of force probes. This is a WPF application written in C# by Samuel Lehmann, at the University of Alberta, based on the [Adhesion Tester] project. 

#### Setup
This github repository includes an installer that will install the necessary files for the application on your system. Once you have done this, all you need to do is adjust the settings to correctly identify the channels for the normal and shear force, along with identifying the com port that the motor controller uses. ![Settings][Settings] **This program was designed to communicate with an [ESP 301 Motor controller], and an [NI USB-6289] data acquisition hub. However**, if you do not wish to use these devices, this program can still be useful to you. All that is necessary is the replacement of either the espManager or DAQ classes with classes that communicate with the device of your choice.

### Licensing
This application is distributed under the [MIT License]. We would however greatly appreciate it if you provide a link to this page or in any future versions of this software you choose to release or any scientific articles that you publish. The reason for this is that an acknowledgement, while not necessary would allow a greater number of scientists to discover this resource.

### Development information
This is a WPF application, available for Windows. Unfortunately, this project does not support Linux or Mac. This application uses [OxyPlot] to aid in graphing of data, and  [Mahapps.Metro] to aid in the UI design. This application also uses [NI-DAQmx] to aid in communication with the National Instruments USB hub, whereas communication with the ESP-301 motor controller is implemented by myself.

[dataCollection]: https://raw.githubusercontent.com/slehmann1/adhesion_tester/master/res/dynamicGraphs.gif
[linearTrial]:https://raw.githubusercontent.com/slehmann1/adhesion_tester/master/res/mainPage.png
[radialTrial]:https://raw.githubusercontent.com/slehmann1/adhesion_tester/master/res/radial%20trial.gif
[radialGraphs]:https://raw.githubusercontent.com/slehmann1/adhesion_tester/master/res/radialGraphs.jpg
[setAndForget]:https://raw.githubusercontent.com/slehmann1/adhesion_tester/master/res/linear%20trial.gif
[paper]: http://www.insertPaperhere.com
[settings]: https://raw.githubusercontent.com/slehmann1/adhesion_tester/master/res/settings.png
[ESP 301 Motor controller]: https://www.newport.com/f/esp301-3-axis-dc-and-stepper-motion-controller
[NI USB-6289]: http://sine.ni.com/nips/cds/view/p/lang/en/nid/209154
[OxyPlot]: http://www.oxyplot.org/
[Mahapps.Metro]: http://mahapps.com/
[NI-DAQmx]: http://www.ni.com/download/ni-daqmx-15.1.1/5665/en/
[MIT License]: https://opensource.org/licenses/MIT
[Adhesion Tester]: https://github.com/slehmann1/adhesion_tester
