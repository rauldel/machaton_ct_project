## Cloud Runner

For having general information about the game itself, please see the [pitch document](https://docs.google.com/document/d/1gELOK22b05mSELnKYVzXFEXDErqKeonqcn_sIRyogYM/edit).

## Installation

The game is developed using Unity engine, one of the most used engines in the industry.

The version used for this development is 2019.4.39f1.

First, go to [Unity's website](https://unity3d.com/get-unity/download) and download `Unity Hub`.

Unity Hub is a Unity version manager that will allow you to manage installation easily. Install the executable file, and create a Unity account, if asks you, choose the free plan.

Then, in the left menu of Unity's Hub, click  `Installs` button to see current Unity versions installed in your system. Once on `Installs` view, in the top-right part of the window there's a `Install Editor` button, click on it and select version 2019.4.39f1.
![image](https://user-images.githubusercontent.com/6830824/168660854-ab9746ac-15ef-4600-b025-726a46422f9a.png)

Once the engine is installed, go to the `Projects` button in the left panel, and open the folder where you downloaded the repo.
![image](https://user-images.githubusercontent.com/6830824/168660990-a7adfb32-84a6-4016-8331-a51310ee3413.png)


In the right part of the `Open` button, you'll be able to `Add Project from Disk` and select the folder.

Once the project is being displayed in the list, make sure that the edition version is the proper one and then double click in the name column in order to open the Unity project.

## Playing the game

In order to play the scene, first make sure that you are in the game sub-window and the virtual display is set to 16:9. See the following image:
![image](https://user-images.githubusercontent.com/6830824/168661465-f0c7e330-2841-41d8-8c5b-4b346acdddac.png)

Then, click the Play button on the top center of the engine window.


## Errors
If you have any errors and the game won't start, it could be because you have to set the API Compatibility Level with a good value. So, you go to `Edit > Project Settings` from the top menu in the window.

Then, in the new window, click in the `Player` item in the left panel, and look for API Compatibility Level and select `.NET 4.x`, more or less like the following image:
![image](https://user-images.githubusercontent.com/6830824/168662291-ee38b7d8-a5b4-43f0-9095-c7fb65db016e.png)

Once that, close the `Project Settings` and try to run the game again.

If you see any other errors, please ping me to help you.

Note that for WebGL building, we also have to set the API Compatibility Level to `.NET 4.x`, see in the following image where you can change the tab for displaying WebGL build options:
![image](https://user-images.githubusercontent.com/6830824/169413493-c0c9c974-61de-4de2-b87f-3717e4c8d2cd.png)



