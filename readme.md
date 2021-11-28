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
  
         git push origin master

  ### - updating repo after a while 
  
   ###### NOTE : you want to pull the repo before updating to check any updates from the other devs 
     
      git pull origin master 
     
