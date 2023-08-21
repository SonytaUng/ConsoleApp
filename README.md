# ConsoleApp
Console app is used to process admission letters and scholarship letters which will be sent to students

+ algorithm:
- read all .txt files from the folder input directory ( directory format)
- move all .txt files to folder Archive ( directory format)
- generate all .txt files in the achive folder (.txt files)
- get all student id ( #######)
- read if the student id occur twice then read file to combine those files by calling the CombineTwoLetters method, then write the result of merging content to output folder, then remove those file that has the same student id in the archive folder
- in the output folder, read the file name then generate the report, store report in the output folder
- for testing, replace the combine folder directory for example "C:\Users\sonit\OneDrive\Desktop\UIOWA\ConsoleApp\CombinedLetters01\Input\", replace with the directory path in the input file in your computer
- gernerate the number of file to currentDate.txt in the output folder


Task CheckList
1- Link to Git Repository: https://github.com/SonytaUng/ConsoleApp
2- Number of estimation: 4 hour, actual time 8 hour
3-  Comments:
    - assuming the file in the directory is in ascending order
    - assuming only admission and scholarships folders contain .txt files
    - when  running the program, it will generate all file in the input folder that has .txt extension file
    - to run, go to program.cs the right click, select open terminal, use command dotnet build to buid the program, dotnet 
    - run to run the program
    - replace the file path combinedLetter path in your local

1- If a person accidentally run the Console app before or after the schedual, it will read all the remaining .txt files in the Input folder (assume only admission and scholarship folder contain .txt files) then generate a report of date of pressing console app
2- If Console app wasn't run previous day, it will generate report combine with the remaining file that have in the admission and scholarship folder, the repost will dispay only the day press the Console App. 
