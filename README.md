
# One Click Zip
by: Ryan Seth Roldan

![Angels Software](https://i.imgur.com/YAHNVMc.png?1)

A GUI application that will let you able to design your own Zip Files individually or filter/dynamic base contents.

After you design your own Zip Files content, you can make a shortcut of your design project that will let you execute it anywhere to launch the program that directly proceed zipping your designed Zip Files Content. It will by pass the Designer GUI and proceed automating your Zip Files content.

# Features
 At the surface, this program is like the major Zip File utility programs. 
 You create folders and place files on it. 
 As you place your folders and files on it, it is already zipped on the fly.
 To compare, this program will let you design first your Zip File structures before committing to Zip It. 
  
  Here are the following features this program offers 
 **1. Dynamic Zip File Name.**
 - Useful to prevent overwriting the same zip file if you want to maintain a series of backup
 
 **2. Dynamic Zip Folder Content**
 - If your target folder ever increasing on files, you can filter out which of which will be included on the final Zip File.
 - It is capable of including sub folder from the target folder
 - It will let you filter the files including sub directories files using GLOB like syntax
 - It will let you filter the files base on its size and date
 - For dynamic folders, It will let you exclude those folder that doesn't contains any files on it. Typical Zip Utility will include all sub folders regardless of what it contains or just an empty folder. 
 
 **3. Rename added files before putting on the Zipped File**
 - You can rename the original folders and files you selected before putting it on the Zip File 
 
 **4. Create a "One Click Zip" short cut file, to perform zipping your designed folders and files on fly.**
- A very handy feature that will perform Zipping your designed zip file structure anywhere

 **5. Place your Zip File in your target folder .**
 - Zipping your zip file structure will place the output Zip File into your own choice of folder. This feature will let you organize your files base of your categorization of its content.

## When to use this tool?

Wondering when to use this tool to take it advantages?
Here are some of the scenario's I think where it can be useful...


1. Gaming Save file backup
- Im using the tool [GameSave Manager](https://www.gamesave-manager.com/) to make a backup of the games save files I've played.
- If you ever had an increasing files count of your gaming save backup, you can make a dynamic folder filter on it and make a Zip File out of it.
- You may ever think you can right click on the backup folder and zip it? Mind not, because, this tool also offer to let you include only those files like 
(example given out base on the tool capability)

-- Files recently created within 7 days

-- Files which had an actual game save, usually file size exceed let's say 100 bytes 

![GameSave Manager output](https://i.imgur.com/WbNbn9J.png)

2. I'm using this tool to manage my backup of my Password Utility Program called [Keepass Password Safe](https://keepass.info/). Using the Major Zip Utility program, I can make a zip backup of my password manager database. However, I need to do a follow up actions after zipping it:
- Rename the file uniquely
- Maintains several copies of the back up for historical reason. (There are times you can't quite remember what you did and some entries are missing. You can track the missing entries on those historical backups)
- Place this backup to Cloud sync folder, to solidify my backup routine.   
![Keepass Password Utility Program](https://i.imgur.com/z8oFnrX.png)


3. Same reason with #2, I'm using this tool to make a backup of my accounting database. I'm using the Utility Program called [GNU Cash Org](https://www.gnucash.org/)
![GNU Cash Database](https://i.imgur.com/lagGvI5.png)


4. If you had a meme collections and you are loving it so much, and you want your copies to have a back up, using this tool, you may opt to do the following.
- Zip up normally the current Meme collection folder as your snapshot backup.
- Create a new Zip File Designs. This will target the new files going into your collections.
- In the Project Zip Designer, add a Dynamic Folder, and filter only those files are recently added in your collections. Let say, files that are recently written within a day, within 7 days, a week or a month. 
- Place your target folder to place the Zip File Output
- Create a One Click Zip shortcut
- You may run/execute the shortcut everyday, or every week, depending on your intent.


As times goes by, people are creative enough to create new memes, and you don't have a good excuse not to love it, thus your collections increases, and the need to back those up will prompt you to do something about it, thus this tool was for you.
![Memes collections](https://i.imgur.com/Dr9QZfU.png)


## Installation

1. Download and extract the latest Installer released on the [One Click Zip Github Release site](https://github.com/AngelsCheeseBurgerOrg/OneClickZip/releases/)
![Release Site](https://i.imgur.com/4c3yKHj.png)


2. Extract the release Zip File and execute the file as highlighted below
![Main Installer](https://i.imgur.com/LlzgyfY.png)


The installer setup is straight forward like any other installers out there.
![Setup](https://i.imgur.com/45IAwoJ.png)
![Setup](https://i.imgur.com/BlUFrwz.png)

3. Configuring the File Association. Below is the file association of the program on the File System.

![File Association on the File System](https://i.imgur.com/14sDavq.png)

To associate the One Click Zip extension on the file System, open the program and 

Click the File Association menu option. 
![File Association](https://i.imgur.com/1RfwDaB.png)
![File Association](https://i.imgur.com/CUmbC6Z.png)
![File Association](https://i.imgur.com/7xjBGbK.png)
![File Association](https://i.imgur.com/XAO7bjX.png)




## File Association

This icon represents the Zip File Designer format file. 

 ![One Click Zip Designer](https://i.imgur.com/1xPzHhd.png)


This icon represents the One Click Zip shortcut that can be executed anywhere to produce your **Designed Zipped File** to an actual **Zip File**.

![One Click Batch File](https://i.imgur.com/nX9nuC3.png)

This is how it seen on the file System
![File Association seen on the File System](https://i.imgur.com/14sDavq.png)
## How to use the application - Documentation
Please refer to the release documentation.
This will serve you a simple guideline how to navigate the application and test your first One Click Zip designer and batch save file.

![enter image description here](https://i.imgur.com/6g7FGjU.png)


## New Features
1. Make several copies of the Zip File targeting different folder locations. This will make a handy feature if you had in mind to set the output to those cloud back up auto sync. Examples are making a copies of the zip file to put it automatically on the location as of the following
- One Drive sync folder
- Drop Box Sync folder
- iCloud Sync folder
- Google Drive sync folder
- External HDD #1 (external HDD's in case you didnt setup this one as RAID like behavior)
- External HDD #2
- External HDD #3
- External HDD #4
- Mapped drive
2. Add **Check for latest Updates** option
3. Improve system caching of Zip File Designer, so that insane number of files will not let the tool choke up.

## TODO's
Here are the things I think in improving of this tool...
1. Making copies to several targeted locations as mention on #1, will include the capability to place a prefix or suffix on the file name of your choice. It will help you to determine and categorize the file as intent.
2. Add the selected folder as "Dynamic Filter Folder" which enable the user not to manually add a single folder and include all of its content dynamically.
3. During installation, ensure the file association will set in...
4. Improve the operation and process of saving the designer and one click batch
5. imrpove the operation surrounding the "Dynamic Folder" when archiving when involving a super large result set that it will consume more memories.

## Technologies

1. [Visual Studio Community Edition 2019](https://visualstudio.microsoft.com/downloads/)
2. C#
3. [.NET Framework 4.7](https://dotnet.microsoft.com/download/dotnet-framework/net47)
4. [ExpTreeLib 3.2.0](https://www.nuget.org/packages/ExpTreeLib/3.2.0?_src=template) 
5. [Glob 1.1.8](https://www.nuget.org/packages/Glob/1.1.8?_src=template)
6. [Gimp](https://www.gimp.org/)
7. [DotNetZip](https://github.com/haf/DotNetZip.Semverd)


## Development

You are welcome.
Just message me here in Github...

## License

CC0-1.0 License

## Author

by: Ryan Seth Roldan

**Free Angelic Software, Yeah! **
