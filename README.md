# SandBox Simulator 4

![Splash](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/7698041f-ecb1-420e-bd94-154bf1bdaf4d)

SandBox Simulator is an educational (and fun!) 3D physics simulation engine. It let's you play around with different Newtonian physics concepts and visualize them.

I originally developed this application in 2008 as a fun side project. At the time there was nothing that lets you quickly visualize many types of physical interations. My goal was a couple of mouse clicks on a form and you're seeing the results right away; no math and no programming required.

It was originally designed to give aproximate visual solutions to n-body problems of point masses, but it now supports much more:

**Forces**
- Newtonian Gravity
- Electostatic Force
- Uniform Acceleration Fields
- Uniform Fluid Drag Force
  - Configurable Fluid Density
  - Configurable Fluid Viscosity
  - Configurable Object Drag Coefficient
- Elastic & Inelastic Collisions
- Fragmentation on Impact
  - Gaussian Distribution for Endurance
  - Gaussian Distribution for Fragment Count

**Methods of Integration for Calculations**
- 1st order - Euler
- 2nd order - Verlet
- 4th order - Symplectic
- 6th order - Symplectic

**Rendering Options**
- DirectX 9 Hardware Accelerated
- DirectX 9 Software Renderer
- Homegrown Raytracing Engine
- Object Path Tracing
- Wireframe Rendering
 
**Objects**
- Point Mass Spheres
- Bounding Boxes
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
- Prodcedure Generation of All Object Attributes!
  - Even Distribution
  - Gaussian Distribution
  - Random Distribution
  - Polynomial Distribution
- Per-Object Interaction Control
- Groupings of Objects

**Lighting Types**
- Directional Lights
- Point Lights
- Spot Lights
- Ambient Lighting
- Highlight Intensity Control
- Range and Attenuation Control
- Conic Falloff (Spot Lights)

# Requirements
- Microsoft .Net Framework version 3.5
- Windows XP SP2 or higher.
- A DirectX 9 compatible GPU.
- A screen resolution of 1024 x 768 or higher.
- A modern graphics accelerator card is strongly recommened. SandBox Simulator will run with integrated graphics but performance will be significantly reduced.
- A dual-core CPU is strongly recommended.

# Visualization Controls
- The keyboard keys W, A, S, D can be used to rotate camera around the central point.
- The keyboard Up & Down arrows can be used to control the camera position in & out (zoom).
- The keyboard Space key can be used to pause and resume the simulation.

Note that repositioning of the camera clears the trace history of the objects when object path tracing is enabled.

# Performance Notes
- SandBox Simulator takes advantage of multithreading and will run best on Dual-Core or Quad-Core processors. This allows all rendering and overhead to run on one core while calculations run on the other.
- The sample simulations in the Test Simulations directory may run at different speeds depending on your machine. You can change the speed of a simulation by increasing or decreasing the time step, often at the expense of accuracy. As a reference, the sample Figure 8, included in the Simulations folder, runs at about 2 400 000 calculations per second on a Core 2 Duo E6600 (2.4GHz).
- Reducing time step and increasing the number of calculations per second does not always improve accuracy due to the limitations of floating point numbers.
- Since SandBox Simulator is calculation heavy, its performance is based primarily on the performance of the floating point unit of the processor. This means that overall performance tends to vary linearly with the clock speed of the processor more than anything else.

# Know Limitations
- Simulation files (.PR files) made on a computer using one language may produce an error when loaded on a computer using an other language. This is due to different regional and language formats not being taken into consideration. If you encounter this problem, set the regional and language format in your computer's control panel to "English Canada".
- Bounding box rendering is broken with the ray-tracing render setting.

# Screenshots




# Some Pretty Pictures

Here are some examples of visualizations.

![01](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/925be17a-3b91-46f9-90a7-03a9ac5d9caf)

![11](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/2db572a6-d740-4eae-bde1-131972e33720)

![12](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/5b9c1045-9b13-423f-b6f1-764a2cb5a4dc)

![17](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/aa09f87f-9e44-4aaf-a03d-641b47020d84)

![Screenshot 2024-04-26 011228](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/b97475c9-0014-436f-a739-d0c42be5529d)

![Screenshot 2024-04-26 012336](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/a2aa92f6-591d-4d77-ac22-377c09d572b1)

![18](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/c46e7094-aec1-44c4-b8d9-c5ac0577c07a)

![19](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/d315fde7-38c5-43d2-80f4-d4b3b8983824)

![20](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/baabe0ef-39c5-4ac6-8fff-2b3b9b4e21f7)

![21](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/cc0506ef-c55a-49a2-a0b6-b8839e4dc2e7)

![22](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/a036dcf1-6fea-4e82-abfb-ef50cf704a58)

![23](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/9aa2c187-dd34-4ed7-a46e-3e39c3ec94c2)

![13](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/aa9091c6-3cdf-46bd-b40f-0137662007ac)

![15](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/23aeec83-af87-4ea9-819c-f45249848996)

![16](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/56fbfeb2-acca-4b74-8cea-a685a5a9429e)

![10](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/4520e4a8-27b0-40c6-bf85-1871a15d8242)

![09](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/c98caba0-d63c-4421-bd23-28cef554b29d)

![08](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/11c79903-39a2-4dce-9248-3093911bfdb2)

![07](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/335c55bd-1bff-4252-b9e5-93c4778d913e)

![06](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/09a2118e-c044-497d-a190-752e4c6b6cdd)

![05](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/d8cfcede-6c03-4550-bb88-fe0946719c23)

![04](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/7a954dbf-efdd-4aad-882b-06524b6e7f6e)

![02](https://github.com/dbeaudoinfortin/SandBoxSimulator/assets/15943629/80e3d4df-34f2-4131-aec4-ce8425dd3f2c)
