# SandBox Simulator 4

<p align="center">
<img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/7698041f-ecb1-420e-bd94-154bf1bdaf4d"/>
</p>

SandBox Simulator is an educational (and fun!) 3D rigid body physics simulation engine. It lets you play around with different Newtonian physics concepts and visualize them.

I initially developed this application in **2007** as a fun hobby project. My goal was to learn about computational physics, numerical analysis, 3D rendering and ray tracing from the basics. For that reason, I chose to write everything from scratch, even though plenty of physics libraries existed. At that time, I couldn't find any simple GUI-based applications that allowed for the quick visualization of various physical interactions. My aim was to enable the user to see results with just a few clicks — no math or coding necessary. I recently revived version 4.0, and have implemented many significant updates in version 4.1 to bring it up to date (details below).

Originally designed to give approximate visual solutions to n-body problems of point masses, SandBox Simulator now supports much more:

**Forces**
- Newtonian Gravity
- Electrostatic Force
- Uniform Acceleration Field
- Uniform Fluid Drag Force
  - Configurable Fluid Density
  - Configurable Fluid Viscosity
  - Configurable Object Drag Coefficient (Global)
- Elastic & Inelastic Collisions
  - Configurable Global Coefficient of Restitution
  - Configurable Interpolation Between Time Steps
- Fragmentation on Impact
  - Gaussian Distribution of Probability for Endurance
  - Gaussian Distribution of Probability for Fragment Count

**Methods of Integration for Calculations**
- 1st order - Euler
- 2nd order - Verlet
- 4th order - Symplectic
- 6th order - Symplectic

**Rendering Options**
- DirectX 9 Hardware Accelerated
- DirectX 9 Software Renderer
- Homegrown Software Ray Tracing Engine
  - Configurable Render Thread Count
  - Shadow Rendering
- Object Path Tracing
- Wireframe Rendering
- Vertex Point Rendering
- Selectable Background Colour

**Camera Controls**
- Keyboard Controls During Runtime
- Configurable Movement Speed
- Target
- Position
- Orientation
- Field of View
 
**Objects**
- Point Mass Spheres
- Boxes
- Finite Planes
- Infinite Planes
- Physical Attributes
  - Mass
  - Charge
  - Coefficient of Restitution
  - Radius
  - Position
  - Velocity
- Visual Attributes
  - Color
  - Highlights
  - Reflectivity
  - Transparency
  - Refractive Index
- Procedural Generation of All Object Attributes!
  - Even Distribution
  - Gaussian Distribution
  - Random Distribution
  - Polynomial Distribution
- Per-Object Interaction Control (Which Affects What and Which is Affected by What)
- Groupings of Objects (With Procedural Generation of Quantity)

**Lighting Types**
- Directional Lights
- Point Lights
- Spot Lights
- Ambient Lighting
- Highlight Intensity Control
- Range Control
- Attenuation Control
- Conic Falloff (Spot Lights)

# Requirements
As part of resurrecting this project from the dead, I have made several technology upgrades. The current (version 4.1) requirements are the following:
- Microsoft .Net 8.0
- Windows 7 or higher.
- A DirectX 9 compatible GPU.
- A screen resolution of 1920 x 1080 or higher.
- Any modern GPU with hardware vertex processing (2006+), integrated or discrete.
- Any modern x86-64 CPU.

The original 2007-era system requirements were:
- Microsoft .Net Framework version 2.0
- Windows XP or higher.
- A DirectX 9 compatible GPU.
- A screen resolution of 1024 x 768 or higher.
- A modern graphics accelerator card is strongly recommended. SandBox Simulator will run with integrated graphics but performance will be significantly reduced.
- A dual-core CPU is strongly recommended.

# Visualization Controls
- The keyboard keys W, A, S, D can be used to rotate camera around the central point.
- The keyboard Up & Down arrows can be used to control the camera position in & out (zoom).
- The keyboard Space key can be used to pause and resume the simulation.

Note that repositioning of the camera clears the trace history of the objects when object path tracing is enabled.

# Performance Notes

- SandBox Simulator takes advantage of multi-threading and will run best on multi-core processors. This allows all rendering and overhead to run on one core while calculations run on the other. Ray-trace rendering makes use of alternate frame rendering and, as of version 4.1, scales fairly well with CPU core counts up to 64 cores. 
- The sample simulations in the Test Simulations directory may run at different speeds depending on your machine. You can change the speed of a simulation by increasing or decreasing the time step, often at the expense of accuracy. As a reference, ~~the sample Figure 8, included in the Simulations folder~~ (note: I have since lost this file), runs at about 2 400 000 calculations per second on a Core 2 Duo E6600 (2.4GHz).
- Reducing time step and increasing the number of calculations per second does not always improve accuracy due to the limitations of floating point numbers.
- Since SandBox Simulator is calculation heavy, its performance is based primarily on the performance of the floating point unit of the processor. This means that overall performance tends to vary linearly with the clock speed of the processor more than anything else.

# Known Limitations

- Simulation files (.PR files) made on a computer using one language may produce an error when loaded on a computer using an other language. This is due to different regional and language formats not being taken into consideration. If you encounter this problem, set the regional and language format in your computer's control panel to "English Canada". I plan to eventually get around to fixing this.
- Box and plane rendering is broken with the ray tracing render setting. The objects always show up a spheres.
- Sphere to box collisions cannot handle situations where the sphere makes clean contact with only an edge of the box. This is a work in progress.
- The interpolation between time steps for collision detection is only implemented for sphere to sphere collisions. Again, this is work in progress.
- Box to box and box to plane collisions have not been implemented.
- Due to the use of fixed-function vertex lighting instead of pixel shaders, large flat surfaces (planes and boxes) may not render nicely in DirectX 9 mode when using only non-directional lighting (spot or point lights). This is because the light may be shining in regions of the object mesh that have no vertices. In order to improve this, I'm tessellating (1:16) the triangles of the mesh to increase the number of vertices when there are non-directional lights present, but the results may still be less than ideal.

# Changes in Version 4.1

The first version, 1.0, was created in 2007 and the last version, 4.0, was abandoned in 2008. In 2024 I resurrected this projects, increased the version number to 4.1 and made the following changes:
- Upgraded from the .Net Framework 2.0 to .Net 8.0.
- Moved from Visual Studio 2005 to Visual Studio 2022.
- Upgraded from 32bit to 64bit.
- Migrated from the Managed DirectX 1.1 library to SharpDX 4.2.0 for DirectX 9 rendering.
- Restored support for non-sphere object types (box, finite plane, infinite plane). I had lost the code for these at some point.
- Improved the implementation object attributes that are assigned a distribution function.
- Implemented DirectX rendering of transparent objects.
- Support for high DPI monitors.
- The control panel form can now be resized with the form controls automatically adjusting.
- Greatly improved multi threading. Lower thread contention and better scaling with high core count CPUs.
- Greatly improved ray tracing performance.
- Improved frame rate limiter.
- Improved camera responsiveness and smoothness.
- Improved form painting speed.
- Lots of refactoring and code clean-up

# Implementation Details

- Implemented in VB .Net. I originally chose VB because I wanted a simple drag-and-drop UI designer for Windows forms and a simple way to make use of DirectX, at the expense of the performance of the calculations themselves. The goal was to build something for fun and to get going quickly. At the time, I felt that Visual Studio's feature set for VB was better than that of C#. 
- Requires Visual Studio 2022.
- DirectX rendering makes use of the DirectX 9 implementation from the SharpDX library.
- Ray traced rendering is built from scratch by myself. Rays are traced using the usual "backwards" approach of projecting them out of the camera, through the screen, to the objects, and then bouncing them to the lights. Once the colour of a pixel is calculated, it is written to a byte buffer. At the end of the frame, that buffer is written to a texture and texture is drawn in the scene using DirectX 9. Each thread renders their frame independently, and the frames are presented alternately in a first-come-first-served manner.
- The physics engine is also built from scratch by myself. The numerical analysis makes use of several forms of numerical integration, which you can choose from.
- For both object-to-object collisions and ray tracing, I have chosen to dissect the boxes into 6 individual planes and perform the intersection calculations on the 6 planes, rather than take an oriented bounding box (OBB) approach. I believe this is more efficient in my case because the box rotation is not dynamic and thus the rotation of each of the planes can be calculated before starting the simulation. At some point, I'd like to introduce rotational velocities so that the objects can "tumble". I will probably benefit from switching to an OBB approach since my current approach would require recalculating the rotations of all 6 planes on every iteration.
- The solution contains a second project called CS Compatibility. The purpose of this project is to build a DLL that sits between SandBox Simulator and a handful of calls to SharpDX, as a work-around for some of the language incompatibilities between C# and VB .Net. Since SharpDX is no longer under development, and VB .Net's popularity continues to fall, I doubt the compatibility issues will get resolved. I also don't feel it's worth rewriting Sandbox Simulator in another language since its just a fun side project. I'm also using this class to make direct calls to the unmanaged DirextX9 DLLs for access to functions that are not present in the SharpDX library.
-The random number generator is seeded with a value calculated from the configuration of the simulation. The idea is to always produce the same seed on every run, so long as the configuration doesn't change, so that we have consistent, predictable results.

# Future Plans
There are a number of additions that I have been meaning to implement (one of these days...):

- Bounding volume hierarchies of objects to improve ray-tracing performance.
- Bounding volume hierarchies of objects to improve collision detection performance.
- Increased use of SIMD accelerated .Net types (vectors, matrices, etc.)
- Support for DirectX 11 & 12. Possibly Vulkan.
- Right now nearly everything uses double precision floats. I'd like to try splitting up the code to use single precision for rendering calculations and double precision for physics calculations. Though I'm not sure how much of a difference in performance this will actually make now that I have moved from 32bits to 64bits.
- Support for object rotational velocities.
- Support for per-object constant acceleration, instead of just a global setting that applies to all objects.
- Ray traced render enhancements: transparency, refractive index, reflectivity, etc.
- Ray tracing depth control to limit object interactions and improve performance.

# Screenshots

<p align="center">
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/6dd2e880-be1a-4f61-8ad9-701a32754b5f" width="500" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/58a134e3-915f-49a4-9aba-8569c31e5977" width="500" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/1b1be0b8-0a4b-4a61-9674-7ce3642be3d4" width="500" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/fefe38b9-5d68-422c-b445-f158c1515878" width="500" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/a55dcb95-cf00-42e1-a5fe-182439e71707" width="500" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/d15321e6-e3c2-4cf5-a613-b142f9ce7a65" width="500" />
</p>


# Some Pretty Pictures

Here are some examples of visualizations.

<p align="center">
  
  <video src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/1881aecd-40bf-4f04-820c-efdfc1f741a6"></video>
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/925be17a-3b91-46f9-90a7-03a9ac5d9caf" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/2db572a6-d740-4eae-bde1-131972e33720" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/d5b129ba-a3bd-4e6c-889b-6edff1b166c9" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/c522fc0f-9248-4f53-8814-90420aa5bb6b" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/5b9c1045-9b13-423f-b6f1-764a2cb5a4dc" width="400" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/aa09f87f-9e44-4aaf-a03d-641b47020d84" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/b97475c9-0014-436f-a739-d0c42be5529d" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/a2aa92f6-591d-4d77-ac22-377c09d572b1" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/c46e7094-aec1-44c4-b8d9-c5ac0577c07a" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/d315fde7-38c5-43d2-80f4-d4b3b8983824" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/baabe0ef-39c5-4ac6-8fff-2b3b9b4e21f7" width="400" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/cc0506ef-c55a-49a2-a0b6-b8839e4dc2e7" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/a036dcf1-6fea-4e82-abfb-ef50cf704a58" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/9aa2c187-dd34-4ed7-a46e-3e39c3ec94c2" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/aa9091c6-3cdf-46bd-b40f-0137662007ac" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/23aeec83-af87-4ea9-819c-f45249848996" width="400" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/56fbfeb2-acca-4b74-8cea-a685a5a9429e" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/4520e4a8-27b0-40c6-bf85-1871a15d8242" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/c98caba0-d63c-4421-bd23-28cef554b29d" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/11c79903-39a2-4dce-9248-3093911bfdb2" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/335c55bd-1bff-4252-b9e5-93c4778d913e" width="400" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/09a2118e-c044-497d-a190-752e4c6b6cdd" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/d8cfcede-6c03-4550-bb88-fe0946719c23" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/7a954dbf-efdd-4aad-882b-06524b6e7f6e" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/8f2428ee-b8ab-4a07-96d5-ccd4f45647ea" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/80e3d4df-34f2-4131-aec4-ce8425dd3f2c" width="800" />
  
  <img src="https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/05ec1778-2183-4e9b-808f-98c2b12405b1" width="800" />
</p>


## Legal Stuff

Copyright (c) 2007 David Fortin

This software is provided by David Fortin under the MIT License, meaning you are free to use it however you want, as long as you include the original copyright notice (above) and license notice in any copy you make. You just can't hold me liable in case something goes wrong. License details can be read [here](https://github.com/dbeaudoinfortin/SandBoxSimulator?tab=MIT-1-ov-file)
