# BeltTest

## Episode 20 - The New Dojo Development Flow: WiX Toolset + GitHub

> :movie_camera: [Youtube](https://www.youtube.com/watch?v=M0i9Ug4pjyU)

In this episode the `BeltTest` project gets set up for later development. See branch `ep20` for work done in this episode.

## Episode 21 - Enhancing the Environment with WiX v4

> :movie_camera: [Youtube](https://www.youtube.com/watch?v=0ApAkl4HKxw)

* Fix the `build.yml` to save the artifacts of the `BeltTestPackage`

### Environment variables

To execute our installed app regardless of working directory in a shell, we'll add our installed directory to the PATH of the machine.

```xml
<Environment Name="PATH" System="yes" Value="C:\Program Files\Deployment Dojo Belt Test" Action="set" Part="last" />
```

We can do one better and use the `INSTALLFOLDER` variable.

```xml
<Environment Name="PATH" System="yes" Value="[INSTALLFOLDER]" Action="set" Part="last" />
```

> :warning: When using folder variables, windows installer will automatically add the last trailing slash.


## Episode 22 - Taking a Shortcut using WiX v4

> :movie_camera: [Youtube](https://www.youtube.com/watch?v=U7MQCF5AZcw)

We add a simple WinForms app which does the same thing as the console app. 
This is an example to show-case shortcuts.

```xml
<File Source="WinFormsApp1.exe">
    <Shortcut Directory="DesktopFolderb" Name="Deployment Dojo Windows Forms App 1" />
</File>	
```
