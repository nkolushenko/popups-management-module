INSTALLATION:

1. Create a new Unity project.
2. Install VContainer via the Package Manager or by adding to `manifest.json`:
   "jp.hadashikick.vcontainer": "https://github.com/hadashiA/VContainer.git?path=VContainer/Assets/VContainer#1.16.9"
<img width="954" alt="Screenshot 2025-07-10 at 03 20 13" src="https://github.com/user-attachments/assets/96f0dc70-1bb0-4c63-b7c0-6840fb5dde5b" />
<img width="953" alt="Screenshot 2025-07-10 at 03 20 56" src="https://github.com/user-attachments/assets/ceea658a-de58-473d-ba74-ef90dddd2964" />


3. Add this package "https://github.com/nkolushenko/popups-management-module.git"
<img width="943" alt="Screenshot 2025-07-10 at 03 22 41" src="https://github.com/user-attachments/assets/798126eb-ff66-4444-b402-bf85fc54c5aa" />



4. Open `Window → Package Manager`, locate **Popups Management Module**.
5. In the Samples section, click **Import** next to `DemoSample`.
<img width="955" alt="Screenshot 2025-07-10 at 03 23 27" src="https://github.com/user-attachments/assets/16eddc32-3b87-4321-8c3d-1e20b6b72ead" />


## RUNNING THE DEMO:

1. Import TextMeshPro (if needed):  
   `Window → TextMeshPro → Import TMP Essentials`
   <img width="650" alt="Screenshot 2025-07-10 at 03 26 17" src="https://github.com/user-attachments/assets/bd269461-7673-4251-ab57-c6aba0aaacf5" />


3. Open the demo scene:  
   `Assets/Samples/Popups Management Module/1.0.0/DemoSample/Scenes/DemoScene.unity`
<img width="919" alt="Screenshot 2025-07-10 at 03 24 53" src="https://github.com/user-attachments/assets/e5a72309-98c0-42aa-a460-a9e6c5de407a" />



4. Enter Play Mode.
<img width="769" alt="Screenshot 2025-07-10 at 03 32 47" src="https://github.com/user-attachments/assets/cfa8b31b-7194-4a37-bbd1-032ab01d74e3" />

**Note:**  
The UI is tested for **portrait (1080*2400) orientation**. 

<img width="450" alt="Screenshot 2025-07-10 at 03 25 52" src="https://github.com/user-attachments/assets/4433a525-d331-4699-9a9e-0b1332cec21d" />



## POPUP CONFIGURATION:

Popup configurations are located in the `Configurations` folder.  
⚠️ **Do not rename or delete these assets** — they are referenced by name at runtime.

Each popup has an associated config asset that defines how it is located and instantiated.
<img width="972" alt="Screenshot 2025-07-10 at 03 40 03" src="https://github.com/user-attachments/assets/398c1f63-3a2d-4f6d-a1cb-cb9347ce8230" />



### Each config contains:
<img width="459" alt="Screenshot 2025-07-10 at 03 40 30" src="https://github.com/user-attachments/assets/d97d9604-67f5-4801-9ab6-dae362dece43" />

1. `windowPath`:  
  Path to the popup prefab inside the `Resources` folder.  
  Used for loading the popup via `Resources.Load`.

2. `lifecycleMode`:  
  Determines how the popup is created, reused, or managed:
-  None - Not used
-  Scene - Popup already exists in the scene
-  Pool - Popup is reused via pooling
-  Instantiate - Popup is instantiated from Resources


## How to use lifecycle modes:
  1. Pool:
  Place the required popup prefab in a specific folder under Resources/, using the exact path defined in windowPath.
  Set lifecycleMode to Pool in the config.
  The system will automatically load and manage the popup via pooling.
  2. Scene:
  Add the popup prefab directly to the scene.
  It must be placed as a child of the Canvas_UI object — this is the root container for all UI elements.
  Set lifecycleMode to Scene in the config.
  3. Instantiate:
  Similar to Pool, but the popup will be loaded via Resources.Instantiate without pooling.


  










