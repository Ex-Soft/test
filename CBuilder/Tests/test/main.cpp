#include <iostream.h>
#include <string.h>
#include <stdio.h>
#include <conio.h>

int main()
{
   char str[100],slovo[100];
   int i,j,z=0;
   bool flag=false;

   cout<<"vvedit radok sliv: \n";
   cin.getline(str,100);
   for(i=0;i<strlen(str);i++)
      {
        if((str[i]>='a' && str[i]<='z') || (str[i]>='A' && str[i]<='Z'))
        {
           if(!flag)
           {
              flag=true;
              j=0;
           }
           slovo[j++]=str[i];

           continue;
        }

        if(flag)
        {
           flag=false;
           slovo[j]='\x0';
           if(strlen(slovo)%2==0)
             cout<<slovo<<"\n";
        }

        if(str[i]=='.' || str[i]==',' || str[i]==';' || str[i]==':')
          z++;
      }

   if(flag)
   {
      slovo[j]='\x0';
      if(strlen(slovo)%2==0)
        cout<<slovo<<"\n";
   }

   if(z!=0)
     cout<<"kilkist rozdilovyh znakiv: "<<z<<"\n";

   getch();
}
