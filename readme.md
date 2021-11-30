# Instruction on how to set-up github repo on your machine 
  ## For Chakir
  
  ### set up your account 
  
  ##### Then run:

    git config --global github.user YOUR_USERNAME
    git config --global github.token YOURTOKEN

  refere to [this link](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token) to get an idea on how to create a personal token (password are not acceptable anymore by github)
  ### - clone 

1. clone the repo : 

         git clone https://github.com/ossamasgr/Store.git 

2. go to your repo : 

        cd Store 

  ### - if you want to add files : 
  1. add the files or update the code in your cloned repo (local machine )
  2. when you're finished push the files/code to the remote repo : 
         
         git pull origin master #to get updates
         git add . # to add file 
         git commit -m "name of commit" # commit the add 
         git push origin master # push the changes to github
      
                                
                                
   # Architecture 
   ![arch](/architecture/store.png)
   ## Technical aproach 
- **programming language && db solution : C# (ADO.NET)** (ADO.NET is a data access technology from the Microsoft .NET Framework that provides communication between relational and non-relational systems through a common set of components.)
-  **DB**  : Sql Server (Microsoft SQL Server is a relational database management system developed by Microsoft. As a database server, it is a software product with the primary function of storing and retrieving data as requested by other software applications—which may run either on the same computer or on another computer across a network)
-  **programming env** (Microsoft Visual Studio is an integrated development environment from Microsoft. It is used to develop computer programs, as well as websites, web apps, web services and mobile apps)
-  **UX Design** : Figma (Figma is a vector graphics editor and prototyping tool which is primarily web-based, with additional offline features enabled by desktop applications for macOS and Windows. The Figma Mirror companion apps for Android and iOS allow viewing Figma prototypes in real-time on mobile devices)
