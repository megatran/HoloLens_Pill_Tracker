# HoloLens Pill Tracker
A mixed reality app that helps users track their pill consumption and find their medicine bottles indoor

Video: https://www.youtube.com/watch?v=2TDfm4LK--I

# Inspiration
Managing medication can be a burden for the elderly and could lead to medication non-adherence. This augmented reality application helps the seniors find the whereabouts of their medication inside the home and track when to take it.

# Flow
When the users put on the Microsoft HoloLens and run the application, they can look around to first save the location of the pill bottles. Once saved, the bottles can be found using the “Find Item” button. Users can use the “Track Marker” button on the right to toggle the AR markers tracking on/off. Turning off this feature increases the frame rate and saves a significant amount of battery.

When the users approach the pill bottle, the application will recognize the markers and display a virtual panel with relevant text such as suggested use, schedule, and save new location. 

When the users select an item and click the button “Find Item”, the application will generate a path directly to that item using the A* algorithm (enabled by UnityEngine.AI’s NavMesh and NavMeshAgent components). A virtual agent will also move along the path to lead the users to the item they’re looking for. 

# Implementation
I developed this application using 
Unity 2018.3
HoloToolKit v2017.4.3.0: https://github.com/microsoft/MixedRealityToolkit-Unity/
HoloLensARToolKit: https://github.com/qian256/HoloLensARToolKit
3D Model of virtual agent/character: https://unity-chan.com/download/releaseNote.php?id=SDUnityChan
Microsoft HoloLens 1 headset

I used the gesture API from HoloToolKit to enable virtual object manipulation in the application. Users can then perform the air-tap gesture and interact with virtual contents such as selecting buttons or moving blocks around. Additionally, I used the SpatialMapping feature from the same library so the app can find and generate planes based on the spatial mapping data. 

To generate a path in 3D space, I use UnityEngine.AI’s NavMesh and NavMeshAgent components. NavMesh essentially feeds in data from HoloToolkit’s spatial mapping component and denotes areas where a virtual agent can and cannot move (e.g., walkable paths, walls, and obstacles). The NavMeshAgent component utilizes A* path planning algorithm so given two points A and B in a 3D space, it can generate animations so that users see a moving virtual agent leading them from A to B. To visualize the pink path, I use Unity’s LineRenderer.

I decided to track the pill bottles using the HoloLensARToolKit instead of Vuforia due to two reasons: 1) the HoloLensARToolKit has faster Aruco marker tracking and retains a relatively high frame rate. 2) Vuforia significantly slows down the application. 

Each pill bottle has a 60mm Aruco marker. When the HoloLens’ camera detects the marker, it will trigger the informational popup. Users then have the option to save the spatial location of the marker to the database. 

To build the project, open the main scene “PathFinding” in Assets\Scenes, select build UWP option in the Building Settings.
