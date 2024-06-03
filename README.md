# BeltTest

## Episode 20 - The New Dojo Development Flow: WiX Toolset + GitHub

> :movie_camera: [YouTube](https://www.YouTube.com/watch?v=M0i9Ug4pjyU)

In this episode the `BeltTest` project gets set up for later development. See branch `ep20` for work done in this episode.

## Episode 21 - Enhancing the Environment with WiX v4

> :movie_camera: [YouTube](https://www.YouTube.com/watch?v=0ApAkl4HKxw)

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

> :movie_camera: [YouTube](https://www.YouTube.com/watch?v=U7MQCF5AZcw)

We add a simple WinForms app which does the same thing as the console app. 
This is an example to show-case shortcuts.

```xml
<File Source="WinFormsApp1.exe">
    <Shortcut Directory="DesktopFolderb" Name="Deployment Dojo Windows Forms App 1" />
</File>	
```

## Episode 23 - A less short look into Advertised Shortcuts using WiX v4

> :movie_camera: [YouTube](https://www.YouTube.com/watch?v=x-E7g5H_1TA)

### Advertising

It's possible to advertise an app. This means creating a shortcut for your app that installs on initial click.

These shortcuts will also repair your program if files get deleted, but the repair will be localized to the feature the shortcut is in.

```xml
<Shortcut Directory="ProgramMenuFolder" Name="Deployment Dojo Windows Forms App 1" Advertise="yes" />
```

### Shortcut icon

:speech_balloon: The `id` of the icon should have the same extension as the file it is pointing to.

```xml
<Component>
	<File Source="WinFormsApp1.exe" />				
	<Shortcut Directory="ProgramMenuFolder" Name="Deployment Dojo Windows Forms App 1" Advertise="yes" Icon="logo.exe" />
</Component>

<!-- Inside fragment -->
<Icon Id="logo.exe" SourceFile="logo.ico" />
```

### Installer icon

It's also possible to change the installer icon, but not the MSI icon.
This icon will show up in the 'Add/Remove programs' window.

Add following inside `package.wxs`:

```xml
<Property Id="ARPPRODUCTICON" Value="logo.exe" />

<Icon Id="logo.exe" SourceFile="logo.ico" />
```

## Episode 24 - To Shortcut or Not to Shortcut? That is the Question for WiX v4.

> :movie_camera: [YouTube](https://www.YouTube.com/watch?v=1kV4gk3tTzg)

Each `Component` needs a `File` or a `RegistryValue`, otherwise it can't generate `KeyPath` values.

### Condition

It's possible to install a `Component` through the `Condition` attribute.

```xml
<Component Id="DesktopIcon" Directory="DesktopFolder" Condition="ENABLEDESKTOPSHORTCUT">
    <!-- content -->
</Component>
```

When set from the command line like `msiexec /i setup.msi ENABLEDESKTOPSHORTCUT=anything`, this component will be installed.
It does not matter what is set, only that it is set.

If you want to enable it when it has a specific value, you can use following:

```xml
Condition="ENABLEDESKTOPSHORTCUT=1"
```

The value supplied on the command line should now be '1' to enable the shortcut.


## Episode 25 - At Your Service. Installing Windows Service with WiX v4.

> :movie_camera: [YouTube](https://www.YouTube.com/watch?v=vZRZeDOTPZQ)

### Installing the service

```xml
<ServiceInstall Name="DeploymentDojoCounting" DisplayName="~Deployment Dojo Counting Service" Type="ownProcess" Start="auto" ErrorControl="normal" />
```

### Controlling the service from the (un)installer

```xml
<ServiceControl Name="DeploymentDojoCounting" Start="install" Stop="uninstall" Remove="uninstall" />
```

## Episode 26 - AMA - The WiX v4 RTM Celebration

> :movie_camera: [YouTube](https://www.YouTube.com/watch?v=UJrD-9N_PVg)

This video is mostly an AMA video with stories about the history of WiX.

## Episode 27 - Cleaning up the mess we left with WiX v4.

> :movie_camera: [YouTube](https://www.youtube.com/watch?v=6stVQvcIdzA)

### Stuff left behind

There are 3 types of data:
1. Application data
2. User data
3. Configuration data

The counting file in our project is 'Application data'. This should be removed
on uninstall. 'User data' should not be removed on uninstall.

### Removing files

Following xml code is used to remove a file:

```xml
<RemoveFile Name="WindowsService1.txt" On="both" />
```

### Local account

Use the local service account to only access this machine. This is better than running as admin.

```xml
<ServiceInstall 
    Account="NT AUTHORITY\LocalService"
    Name="DeploymentDojoCounting"
    Description="This is the description" 
    DisplayName="~Deployment Dojo Counting Service" 
    Type="ownProcess" 
    Start="auto" 
    ErrorControl="normal" />
```

## Episode 28: Permission to come aboard using the LocalService in WiX v4

> :movie_camera: [YouTube](https://www.youtube.com/watch?v=DslwxSg5fPw)

