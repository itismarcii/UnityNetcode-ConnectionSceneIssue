# UnityNetcode-ConnectionSceneIssue
Burgreport for "Unity Netcode for GameObjects"

Open the Project. 

In the Menu Scene select Server or Client on the NetworkSetupConfig Gameobject ( Recommend to build Server and run Client on editor !!! )

Start in Editor mode the Game with an server build running ( Use for the server build the default build inside the ServerBuild folder )

Client will connect to the Server

Server will connect the Client and spawn an extra Prefab object.

The Prefab object will on Start Debug the current Active Scene.

On Client the current Active Scene with the Bug issue should show the ClientScene ( if this is the case, the bug did occure )

Should this be not the case, redo that process. In most cases the Prefab object should spawn inside the ClientScene.


PS: Without bug issue the Prefab object should wait for the Client Scene switch and spawn the object correctly inside the WorldScene
